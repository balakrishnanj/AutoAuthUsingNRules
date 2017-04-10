using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NRules;
using NRules.RuleModel;
using RuleApiApplication.Messages;
using WebGrease.Css.Extensions;

namespace RuleApiApplication.Business
{
    public class RuleEngine
    {
        private List<DecisionRuleResponse> _decisionRuleResponses;
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

        public void WhenRuleFires(IContext context,DecisionRule decisionRule)
        {
            Trace.WriteLine($"Success. Done executing rule {decisionRule.Name}");
            _decisionRuleResponses = _decisionRuleResponses ?? new List<DecisionRuleResponse>();
            _decisionRuleResponses.Add(new DecisionRuleResponse
            {
                ApprovedPayLevelId = decisionRule.ApprovedPayLevelId,
                ApprovalReasonId = decisionRule.ApprovalReasonId,
                DecisionTypeId = decisionRule.DecisionTypeId,
                RuleId = decisionRule.RuleId,
                ApprovalRationale = decisionRule.ApprovalRationale ?? string.Empty
            });
            context.Halt();
        }

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
    }
}