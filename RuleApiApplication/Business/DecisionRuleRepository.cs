using System.Collections.Generic;
using System.Linq;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class DecisionRuleRepository : IRuleRepository
    {
        public IEnumerable<IRuleSet> GetRuleSets()
        {
            return new List<IRuleSet> {DecisionRulesetStore.Rules};
        }

        public static void LoadRuleSets()
        {
            DecisionRulesetStore.Rules = new RuleSet("Test");
            var count = 100;
            while (count > 0)
            {
                var ruleDefinitions = RuleStore
                    .Rules
                    .Select(autoAuthorizationRule => RuleBuilder.Build(autoAuthorizationRule)).ToList();
                DecisionRulesetStore.Rules.Add(ruleDefinitions);
                count--;
            }
        }
    }
}