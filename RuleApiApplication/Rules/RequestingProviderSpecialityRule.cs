using System;
using System.Linq.Expressions;
using RuleApiApplication.Business;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class RequestingProviderSpecialityRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.RequestingProviderSpecialityCode))
            {
                Expression<Func<DecisionRuleRequest, bool>> requestProviderSpecialityExpression =
                    autoAuthContract =>
                        string.Equals(autoAuthContract.RequestingProviderSpecialityCode,
                            rule.RequestingProviderSpecialityCode, StringComparison.CurrentCultureIgnoreCase);
                if (rule.IsRequestProviderInNetwork.HasValue)
                {
                    requestProviderSpecialityExpression =
                        requestProviderSpecialityExpression.And(
                            autoAuthContract =>
                                autoAuthContract.IsRequestProviderInNetwork.HasValue &&
                                autoAuthContract.IsRequestProviderInNetwork.Value);
                }
                return requestProviderSpecialityExpression;
            }
            return null;
        }
    }
}