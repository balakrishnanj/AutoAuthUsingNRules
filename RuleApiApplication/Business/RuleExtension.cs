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
        private static List<IAutoAuthorizationRuleBuilder> _autoAuthorizationRuleBuilders;
        public static Expression<Func<AutoAuthorizationContract, bool>> AppendRules(this Expression<Func<AutoAuthorizationContract, bool>> autoAuthorizationExpression, AutoAuthorizationRule rule)
        {
            var authorizationRuleBuilderType = typeof (IAutoAuthorizationRuleBuilder);
            _autoAuthorizationRuleBuilders = _autoAuthorizationRuleBuilders ?? Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(ab => authorizationRuleBuilderType.IsAssignableFrom(ab) && ab.Name != typeof(IAutoAuthorizationRuleBuilder).Name)
                .Select(t => Activator.CreateInstance(t) as IAutoAuthorizationRuleBuilder).ToList();

            return _autoAuthorizationRuleBuilders
                .Select(autoAuthorizationRuleBuilder => autoAuthorizationRuleBuilder.Build(rule))
                .Aggregate(autoAuthorizationExpression, (current, ruleExpression) => ruleExpression == null ? current : current.And(ruleExpression));
        }
    }
}