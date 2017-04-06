using System.Collections.Generic;
using System.Linq;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class AutoAuthorizationRuleRepository: IRuleRepository
    {
        public static void LoadRuleSets()
        {
            AutoAuthorizationRulesetStore.Rules = new RuleSet("Test");
            int count = 100;
            while (count > 0)
            {
                var ruleDefinitions = RuleStore
                    .Rules
                    .Select(autoAuthorizationRule => RuleBuilder.Build(autoAuthorizationRule)).ToList();
                AutoAuthorizationRulesetStore.Rules.Add(ruleDefinitions);
                count--;
            }
        }

        public IEnumerable<IRuleSet> GetRuleSets()
        {
            return new List<IRuleSet> { AutoAuthorizationRulesetStore.Rules };
        }
    }
}