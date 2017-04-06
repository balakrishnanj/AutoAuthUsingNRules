using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class DiagnosisCodeRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.DiagnosisCode))
            {
                return autoAuthContract => String.Equals(autoAuthContract.DiagnosisCode, rule.DiagnosisCode, StringComparison.CurrentCultureIgnoreCase);
            }
            return null;
        }
    }
}