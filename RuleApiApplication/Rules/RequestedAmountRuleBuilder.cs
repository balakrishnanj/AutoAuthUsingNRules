using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class RequestedAmountRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (rule.MaxUnits.HasValue)
            {
                return autoAuthContract => autoAuthContract.RequestedAmount <= rule.MaxUnits;
            }
            return null;
        }
    }
}