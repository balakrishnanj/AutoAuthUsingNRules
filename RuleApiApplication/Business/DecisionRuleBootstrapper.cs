using System.Collections.Generic;
using NRules;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public static class DecisionRuleBootstrapper
    {
        public static Dictionary<string, ISessionFactory> RuleSets { get; set; }

        public static void Boostarp()
        {
            RuleSets = new Dictionary<string, ISessionFactory>();
            var ruleFactory = new DecisionRuleRepository().Compile();
            var ruleSets = DecisionRuleRepository.RuleSets;
            foreach (var ruleSet in ruleSets)
            {
                RuleSets.Add(ruleSet.Name, ruleFactory);
            }
        }
    }
}