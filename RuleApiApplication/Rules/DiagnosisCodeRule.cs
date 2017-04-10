using System;
using System.Linq;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class DiagnosisCodeRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (rule.DiagnosisCodes != null && rule.DiagnosisCodes.Any())
            {
                return autoAuthContract => rule.DiagnosisCodes.Contains(autoAuthContract.DiagnosisCode);
            }
            return null;
        }
    }
}