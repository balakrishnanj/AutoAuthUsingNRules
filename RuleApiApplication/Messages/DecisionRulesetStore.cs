using System.Collections.Generic;
using NRules.RuleModel;

namespace RuleApiApplication.Messages
{
    public static class DecisionRulesetStore
    {
        public static List<IRuleSet> Rules { get; set; }
    }
}