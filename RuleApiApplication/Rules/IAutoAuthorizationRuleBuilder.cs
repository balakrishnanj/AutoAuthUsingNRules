using System;
using System.Linq.Expressions;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public interface IAutoAuthorizationRuleBuilder
    {
        Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule);
    }
}