using System;
using System.Linq.Expressions;
using RuleApiApplication.Business;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class VendorProviderSpecialityBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.RequestingProviderSpecialityCode))
            {
                Expression<Func<AutoAuthorizationContract, bool>> vendorProviderSpecialityExpression = autoAuthContract => String.Equals(autoAuthContract.VendorProviderSpecialityCode, rule.VendorProviderSpecialityCode, StringComparison.CurrentCultureIgnoreCase);
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