using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class PatientGenderRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.Gender))
            {
                return autoAuthContract => autoAuthContract.Gender == rule.Gender;
            }
            return null;
        }
    }
}