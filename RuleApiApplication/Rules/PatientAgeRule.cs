using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class PatientAgeRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
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