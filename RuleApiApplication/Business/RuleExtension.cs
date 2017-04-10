using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using RuleApiApplication.Messages;
using RuleApiApplication.Rules;

namespace RuleApiApplication.Business
{
    public static class RuleExtension
    {
        private static List<IDecisionEngineRule> _autoAuthorizationRuleBuilders;

        public static Expression<Func<DecisionRuleRequest, bool>> AppendRules(
            this Expression<Func<DecisionRuleRequest, bool>> autoAuthorizationExpression, DecisionRule rule)
        {
            var authorizationRuleBuilderType = typeof (IDecisionEngineRule);
            _autoAuthorizationRuleBuilders = _autoAuthorizationRuleBuilders ?? Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(
                    ab =>
                        authorizationRuleBuilderType.IsAssignableFrom(ab) &&
                        ab.Name != typeof (IDecisionEngineRule).Name)
                .Select(t => Activator.CreateInstance(t) as IDecisionEngineRule).ToList();

            return _autoAuthorizationRuleBuilders
                .Select(autoAuthorizationRuleBuilder => autoAuthorizationRuleBuilder.Build(rule))
                .Aggregate(autoAuthorizationExpression,
                    (current, ruleExpression) => ruleExpression == null ? current : current.And(ruleExpression));
        }
    }
}