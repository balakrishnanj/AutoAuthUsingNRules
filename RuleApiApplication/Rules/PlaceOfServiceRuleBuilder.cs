using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class PlaceOfServiceRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.PlaceOfService))
            {
                return autoAuthContract => String.Equals(autoAuthContract.PlaceOfService, rule.PlaceOfService, StringComparison.CurrentCultureIgnoreCase);
            }
            return null;
        }
    }
}