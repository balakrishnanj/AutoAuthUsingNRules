using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public interface IDecisionEngineRule
    {
        Expression<Func<DecisionRuleRequest, bool>> Build(DecisionRule rule);
    }
}