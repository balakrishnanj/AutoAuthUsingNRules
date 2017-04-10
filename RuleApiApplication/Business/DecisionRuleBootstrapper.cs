using System.Collections.Generic;
using NRules;

namespace RuleApiApplication.Business
{
    public static class DecisionRuleBootstrapper
    {
        public static Dictionary<string, ISessionFactory> RuleSets { get; set; }

        public static void Boostarp()
        {
            RuleSets = new Dictionary<string, ISessionFactory>();
            DecisionRuleRepository.LoadRuleSets();
            var ruleFactory = new DecisionRuleRepository().Compile();
            RuleSets.Add("Test", ruleFactory);
        }
    }
}