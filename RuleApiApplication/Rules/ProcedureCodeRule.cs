using System;
using System.Linq;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class ProcedureCodeRule : IDecisionEngineRule
    {
        public Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule)
        {
            if (rule.ProcedureCodes != null && rule.ProcedureCodes.Any())
            {
                return autoAuthContract => rule.ProcedureCodes.Contains(autoAuthContract.ProcedureCode);
            }
            return null;
        }
    }
}