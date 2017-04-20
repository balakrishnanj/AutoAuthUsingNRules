using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NRules.RuleModel;
using RuleApiApplication.CustomAttributes;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class RuleBuilder
    {
        public static IRuleDefinition Build(DecisionRule decisionRule)
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
           
            builder.Name(decisionRule.RuleName);
            var propInfo = GetRuleProperties(decisionRule);
            foreach (var prop in propInfo)
            {
                //var name = prop.Name;
                //var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                //var value = prop.GetValue(decisionRule);
                //object safeValue = (value == null) ? null : Convert.ChangeType(value, type);
                //builder.Property(name,safeValue);
                builder.Property(prop.Name, prop.GetValue(decisionRule));
            }

            var autoAuthorizationPattern = builder.LeftHandSide()
                .Pattern(typeof (DecisionRuleRequest), "autoAuthContract");
            Expression<Func<DecisionRuleRequest, bool>> autoAuthExpression = autoAuthContract =>
                autoAuthContract.ClientId == decisionRule.ClientId &&
                autoAuthContract.LobId == decisionRule.LobId &&
                autoAuthContract.AuthTypeId == decisionRule.AuthTypeId;

            autoAuthExpression = autoAuthExpression
                .AppendRules(decisionRule);

            autoAuthorizationPattern.Condition(autoAuthExpression);
            return builder.Build();
        }

        public static List<PropertyInfo> GetRuleProperties<T>(T item) where T : new()
        {
            var type = item.GetType();
            var properties = type.GetProperties();
           
            var propInfo = new List<PropertyInfo>();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                propInfo.AddRange(from attribute in attributes where attribute.GetType() == typeof (RulePropertyAttribute) select property);
            }
            return propInfo;
        }
    }
}