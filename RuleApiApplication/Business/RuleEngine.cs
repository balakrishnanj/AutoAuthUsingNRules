using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NRules.Diagnostics;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class RuleEngine
    {
        private List<DecisionRuleResponse> _decisionRuleResponses = new List<DecisionRuleResponse>();

        public List<DecisionRuleResponse> ExecuteRuleParllel(List<DecisionRuleRequest> autoAuthorizationDtos)
        {
            if (autoAuthorizationDtos == null) throw new ArgumentNullException();
            var tasksList = new List<Task>();
            if (autoAuthorizationDtos.Count > 5)
            {
                var groupedDtos = autoAuthorizationDtos.Select((dto, index) => new { dto, index })
                    .GroupBy(x => x.index / 5)
                    .Select(x => x.Select(y => y.dto).ToList())
                    .ToList();
                groupedDtos.ForEach(gr =>
                {
                    gr.ForEach(r =>
                    {
                        tasksList.Add(Task.Factory.StartNew(() => FireRule(r)));
                    });
                });
            }
            else
            {
                autoAuthorizationDtos.ForEach(FireRule);
            }

            Task.WaitAll(tasksList.ToArray());
            Trace.WriteLine("Returning response");
            return _decisionRuleResponses;
        }

        private void FireRule(DecisionRuleRequest r)
        {
            var ruleStore = "AutoDecision_" + r.ClientId + "_" + r.LobId;
            var session = DecisionRuleBootstrapper.RuleSets[ruleStore].CreateSession();
            session.Events.RuleFiredEvent += OnRuleFiredEvent;

            session.Insert(r);
            session.Fire(1);
        }

        private void OnRuleFiredEvent(object sender, AgendaEventArgs e)
        {
            Trace.WriteLine($"Rule fired {e.Rule.Name}");
            var fact = (DecisionRuleRequest)e.Facts.First().Value;
            var ruleProperties = e.Rule.Properties;

            var decisionRuleResponse = JsonConvert.DeserializeObject<DecisionRuleResponse>
                                            (ruleProperties["ResponseJson"] as string);
            decisionRuleResponse.ReviewId = fact.ReviewId;
            decisionRuleResponse.RuleId = (int)ruleProperties["RuleId"];

            _decisionRuleResponses.Add(decisionRuleResponse);

            Trace.WriteLine($"Rule fired {e.Rule.Name} complete");
        }
    }
}