using System;
using System.Linq.Expressions;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public static class RuleBuilder
    {
        public static IRuleDefinition Build(DecisionRule decisionRule)
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
            builder.Repeatability(RuleRepeatability.NonRepeatable);
            builder.Name(decisionRule.Name);

            var autoAuthorizationPattern = builder.LeftHandSide()
                .Pattern(typeof (DecisionRuleRequest), "autoAuthContract");
            Expression<Func<DecisionRuleRequest, bool>> autoAuthExpression = autoAuthContract =>
                autoAuthContract.ClientId == decisionRule.ClientId &&
                autoAuthContract.LobId == decisionRule.LobId &&
                autoAuthContract.AuthTypeId == decisionRule.AuthTypeId;

            autoAuthExpression = autoAuthExpression
                .AppendRules(decisionRule);

            autoAuthorizationPattern.Condition(autoAuthExpression);
            Expression<Action<IContext>> result = (ctx) => new RuleEngine().WhenRuleFires(ctx, decisionRule);
            builder.RightHandSide().Action(result);
            return builder.Build();
        }
    }
}