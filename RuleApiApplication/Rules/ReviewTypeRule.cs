using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class ReviewTypeRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (!rule.ReviewTypeId.HasValue)
            {
                return autoAuthContract => autoAuthContract.ReviewTypeId == rule.ReviewTypeId;
            }
            return null;
        }
    }
}