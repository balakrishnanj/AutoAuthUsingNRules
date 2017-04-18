using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class RuleBuilder
    {
        public static IRuleDefinition Build(DecisionRule decisionRule)
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
           
            builder.Name(decisionRule.Name);
            builder.Properties(new List<RuleProperty>
            {
                new RuleProperty("ApprovedPayLevelId",decisionRule.ApprovedPayLevelId),
                new RuleProperty("ApprovalReasonId", decisionRule.ApprovalReasonId),
                new RuleProperty("DecisionTypeId", decisionRule.DecisionTypeId),
                new RuleProperty("RuleId", decisionRule.RuleId),
                new RuleProperty("ApprovalRationale", decisionRule.ApprovalRationale)
            });

            var autoAuthorizationPattern = builder.LeftHandSide()
                .Pattern(typeof (DecisionRuleRequest), "autoAuthContract");
            Expression<Func<DecisionRuleRequest, bool>> autoAuthExpression = autoAuthContract =>
                autoAuthContract.ClientId == decisionRule.ClientId &&
                autoAuthContract.LobId == decisionRule.LobId &&
                autoAuthContract.AuthTypeId == decisionRule.AuthTypeId;

            autoAuthExpression = autoAuthExpression
                .AppendRules(decisionRule);

            autoAuthorizationPattern.Condition(autoAuthExpression);
            return builder.Build();
        }
    }
}