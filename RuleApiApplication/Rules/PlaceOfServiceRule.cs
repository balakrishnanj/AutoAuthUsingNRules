using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class PlaceOfServiceRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.PlaceOfService))
            {
                return
                    autoAuthContract =>
                        string.Equals(autoAuthContract.PlaceOfService, rule.PlaceOfService,
                            StringComparison.CurrentCultureIgnoreCase);
            }
            return null;
        }
    }
}