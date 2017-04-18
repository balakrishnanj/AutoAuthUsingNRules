using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NRules;
using NRules.Diagnostics;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class RuleEngine
    {
        private List<DecisionRuleResponse> _decisionRuleResponses;
        public List<DecisionRuleResponse> ExecuteRule(List<DecisionRuleRequest> autoAuthorizationDtos)
        {
            if (autoAuthorizationDtos == null) throw new ArgumentNullException();
            autoAuthorizationDtos.ForEach(r =>
            {
                var session = DecisionRuleBootstrapper.RuleSets["Test"].CreateSession();
                session.Insert(r);
                session.Fire(1);
            });
            return _decisionRuleResponses;
        }

        public List<DecisionRuleResponse> ExecuteRuleParllel(List<DecisionRuleRequest> autoAuthorizationDtos)
        {
            if (autoAuthorizationDtos == null) throw new ArgumentNullException();
            if (autoAuthorizationDtos.Count > 5)
            {
                var groupedDtos = autoAuthorizationDtos.Select((dto, index) => new {dto, index})
                    .GroupBy(x => x.index/5)
                    .Select(x => x.Select(y => y.dto).ToList())
                    .ToList();
                var tasksList = new List<Task>();
                groupedDtos.ForEach(gr =>
                {
                    gr.ForEach(r =>
                    {
                        tasksList.Add(Task.Factory.StartNew(() => FireRule(r)));
                    });
                });
               Task.WaitAll(tasksList.ToArray());
            }
            else
            {
                autoAuthorizationDtos.ForEach(FireRule);
            }
            return _decisionRuleResponses;
        }

        private void FireRule(DecisionRuleRequest r)
        {
            //var ruleStore = "{ ClientId = "+r.ClientId+", LobId = "+r.LobId+" }";
            //var ruleStore = "{ ClientId = 2, LobId = 71 }";
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
           
            _decisionRuleResponses = _decisionRuleResponses ?? new List<DecisionRuleResponse>();

            _decisionRuleResponses.Add(new DecisionRuleResponse
            {
                ReviewId = fact.ReviewId,
                ApprovedPayLevelId = (int?)ruleProperties["ApprovedPayLevelId"],
                ApprovalReasonId = (int)ruleProperties["ApprovalReasonId"],
                DecisionTypeId = (int)ruleProperties["DecisionTypeId"],
                RuleId = (int)ruleProperties["RuleId"],
                ApprovalRationale = (string)ruleProperties["ApprovalRationale"]
            });
        }
    }
}