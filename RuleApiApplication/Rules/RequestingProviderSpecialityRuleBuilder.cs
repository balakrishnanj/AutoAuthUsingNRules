using System;
using System.Linq.Expressions;
using RuleApiApplication.Business;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class RequestingProviderSpecialityRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.RequestingProviderSpecialityCode))
            {
                Expression<Func<AutoAuthorizationContract,bool>> requestProviderSpecialityExpression = autoAuthContract => String.Equals(autoAuthContract.RequestingProviderSpecialityCode, rule.RequestingProviderSpecialityCode, StringComparison.CurrentCultureIgnoreCase);
                if (rule.IsRequestProviderInNetwork.HasValue)
                {
                    requestProviderSpecialityExpression = requestProviderSpecialityExpression.And(autoAuthContract => autoAuthContract.IsRequestProviderInNetwork.HasValue && autoAuthContract.IsRequestProviderInNetwork.Value);
                }
                return requestProviderSpecialityExpression;
            }
            return null;
        }
    }
}