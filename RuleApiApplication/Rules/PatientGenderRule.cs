using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class PatientGenderRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.Gender))
            {
                return autoAuthContract => autoAuthContract.Gender == rule.Gender;
            }
            return null;
        }
    }
}