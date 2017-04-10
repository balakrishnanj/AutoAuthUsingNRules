using System;
using System.Linq.Expressions;
using RuleApiApplication.Business;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class VendorProviderSpeciality : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.RequestingProviderSpecialityCode))
            {
                Expression<Func<DecisionRuleRequest, bool>> vendorProviderSpecialityExpression =
                    autoAuthContract =>
                        string.Equals(autoAuthContract.VendorProviderSpecialityCode, rule.VendorProviderSpecialityCode,
                            StringComparison.CurrentCultureIgnoreCase);
                if (rule.IsVendorProviderInNetwork.HasValue)
                {
                    vendorProviderSpecialityExpression =
                        vendorProviderSpecialityExpression.And(
                            autoAuthContract =>
                                autoAuthContract.IsVendorProviderInNetwork.HasValue &&
                                autoAuthContract.IsVendorProviderInNetwork.Value);
                }
                return vendorProviderSpecialityExpression;
            }
            return null;
        }
    }
}