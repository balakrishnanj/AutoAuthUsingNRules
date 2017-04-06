using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Rules
{
    public class ProcedureCodeRuleBuilder: IAutoAuthorizationRuleBuilder
    {
        public Expression<Func<AutoAuthorizationContract, bool>> Build(AutoAuthorizationRule rule)
        {
            if (!string.IsNullOrWhiteSpace(rule.DiagnosisCode))
            {
                return autoAuthContract => String.Equals(autoAuthContract.ProcedureCode, rule.ProcedureCode, StringComparison.CurrentCultureIgnoreCase);
            }
            return null;
        }
    }
}