using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class RequestedAmountRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (rule.MaxUnits.HasValue)
            {
                return autoAuthContract => autoAuthContract.RequestedAmount <= rule.MaxUnits;
            }
            return null;
        }
    }
}