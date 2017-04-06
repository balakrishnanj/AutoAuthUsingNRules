using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class PatientAgeRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (rule.AgeLowerBound.HasValue && rule.AgeUpperBound.HasValue)
            {
               return 
                    autoAuthContract =>
                        autoAuthContract.Age > rule.AgeLowerBound.Value &&
                        autoAuthContract.Age < rule.AgeUpperBound.Value;
            }

            return null;
        }
    }
}