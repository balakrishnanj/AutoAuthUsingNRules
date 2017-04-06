using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class ReviewTypeRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!rule.ReviewTypeId.HasValue)
            {
                return autoAuthContract => autoAuthContract.ReviewTypeId == rule.ReviewTypeId;
            }
            return null;
        }
    }
}