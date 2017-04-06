using System;
using System.Diagnostics;
using System.Linq.Expressions;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public static class RuleBuilder
    {
        public static IRuleDefinition Build(AutoAuthorizationRule autoAuthorizationRule)
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
            //builder.Repeatability(RuleRepeatability.NonRepeatable);
            builder.Name(autoAuthorizationRule.Name);

            var autoAuthorizationPattern = builder.LeftHandSide().Pattern(typeof(AutoAuthorizationContract), "autoAuthContract");
            Expression<Func<AutoAuthorizationContract, bool>> autoAuthExpression = autoAuthContract =>
               autoAuthContract.ClientId == autoAuthorizationRule.ClientId &&
               autoAuthContract.LobId == autoAuthorizationRule.LobId &&
               autoAuthContract.AuthTypeId == autoAuthorizationRule.AuthTypeId;

            autoAuthExpression = autoAuthExpression
                .AppendRules(autoAuthorizationRule);

            autoAuthorizationPattern.Condition(autoAuthExpression);
            Expression<Action<IContext>> result = (ctx) => Trace.WriteLine($"Success: {autoAuthorizationRule.Name}");
            builder.RightHandSide().Action(result);
            return builder.Build();
        }
    }
}