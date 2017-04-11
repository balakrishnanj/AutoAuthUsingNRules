using System;
using System.Linq;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class VendorProviderSpecialityRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (rule.VendorProviderSpecialityCodes != null && rule.VendorProviderSpecialityCodes.Any())
            {
                return autoAuthContract => rule.VendorProviderSpecialityCodes.Contains(autoAuthContract.VendorProviderSpecialityCode);
            }
            return null;
        }
    }
}