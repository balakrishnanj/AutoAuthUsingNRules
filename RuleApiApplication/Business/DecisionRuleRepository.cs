using System.Collections.Generic;
using System.Linq;
using NRules.RuleModel;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class DecisionRuleRepository : IRuleRepository
    {
        public static List<IRuleSet> RuleSets { get; set; }
        public IEnumerable<IRuleSet> GetRuleSets()
        {
            var result = RuleStore.Rules.GroupBy(r => new { r.ClientId, r.LobId });
            RuleSets = new List<IRuleSet>();

            foreach (var group in result)
            {
                var ruleSetName = "AutoDecision_" + group.Key.ClientId + "_" + group.Key.LobId;
                var ruleSet = new RuleSet(ruleSetName);
                var ruleDefinitions = group.Select(RuleBuilder.Build).ToList();
                ruleSet.Add(ruleDefinitions);
                RuleSets.Add(ruleSet);
            }
            return RuleSets;
        }
    }
}