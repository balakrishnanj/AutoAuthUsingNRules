using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NRules;
using NRules.Diagnostics;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class RuleEngine
    {
        private readonly List<DecisionRuleResponse> _decisionRuleResponses = new List<DecisionRuleResponse>();
        public async Task ExecuteRuleAsync(DecisionRuleRequest autoAuthRequest)
        {
            await Task.Factory.StartNew(() =>
            {
                var sessionFactory = new DecisionRuleRepository().Compile();
                var session = sessionFactory.CreateSession();
                session.Insert(autoAuthRequest);
                session.Fire();
            });
        }

        //public void WhenRuleFires(IContext context, DecisionRule decisionRule, DecisionRuleRequest request)
        //{
        //    Trace.WriteLine($"Success. Done executing rule {decisionRule.Name}");
        //    _decisionRuleResponses = _decisionRuleResponses ?? new List<DecisionRuleResponse>();
        //    _decisionRuleResponses.Add(new DecisionRuleResponse
        //    {
        //        ReviewId = request.ReviewId,
        //        ApprovedPayLevelId = decisionRule.ApprovedPayLevelId,
        //        ApprovalReasonId = decisionRule.ApprovalReasonId,
        //        DecisionTypeId = decisionRule.DecisionTypeId,
        //        RuleId = decisionRule.RuleId,
        //        ApprovalRationale = decisionRule.ApprovalRationale ?? string.Empty
        //    });
        //}

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
                        var task = Task.Factory.StartNew(() => FireRule(r));
                        tasksList.Add(task);
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
            var session = DecisionRuleBootstrapper.RuleSets["Test"].CreateSession();
            session.Events.RuleFiredEvent += OnRuleFiredEvent;
            session.Insert(r);
            session.Fire(1);
        }

        private void OnRuleFiredEvent(object sender, AgendaEventArgs e)
        {
            Trace.WriteLine($"Rule fired {e.Rule.Name}");
            var fact = (DecisionRuleRequest)e.Facts.First().Value;
            var rule = e.Rule.Properties;
           
            var data = new DecisionRuleResponse
            {
                ReviewId = fact.ReviewId,
                ApprovedPayLevelId = (int?)rule["ApprovedPayLevelId"],
                ApprovalReasonId = (int)rule["ApprovalReasonId"],
                DecisionTypeId = (int)rule["DecisionTypeId"],
                RuleId = (int)rule["RuleId"],
                ApprovalRationale = (string)rule["ApprovalRationale"]
            };
            _decisionRuleResponses.Add(data);
        }
    }
}