using System.Collections.Generic;
using RuleApiApplication.Repositories;

namespace RuleApiApplication.Messages
{
    public static class RuleStore
    {
        private static List<DecisionRule> CreateRules()
        {
            var decisionRules = new List<DecisionRule>();

            var vendorProviderSpecialityCodes = new HashSet<string>();
            var diagnosisCodes = new HashSet<string>();
            var procedureCodes = new HashSet<string>();

            for (int i = 1; i < 100; i++)
            {
                diagnosisCodes.Add("D" + i);
                procedureCodes.Add("P" + i);
                vendorProviderSpecialityCodes.Add("Vendor" + i);
            }
            for (int i = 1; i < 1001; i++)
            {
                var rule = new DecisionRule
                {
                    RuleId = i,
                    Name = "Rule " + i,
                    ClientId = 22,
                    LobId = 53,
                    AuthTypeId = 2,
                    DiagnosisCodes = diagnosisCodes,
                    ProcedureCodes = procedureCodes,
                    VendorProviderSpecialityCodes = vendorProviderSpecialityCodes,
                    PlaceOfService = "Hospital " + i,
                    ReviewTypeId = i,
                    ApprovalRationale = "Diagnosis match",
                    ApprovalReasonId = i,
                    ApprovedPayLevelId = i,
                    DecisionTypeId = i
                };

                //var ageRule = new DecisionRule
                //{
                //    Name = "Rule2 " + i,
                //    ClientId = 22,
                //    LobId = 53,
                //    AuthTypeId = 1,
                //    AgeLowerBound = 50,
                //    AgeUpperBound = 100,
                //    DiagnosisCodes = diagnosisCodes,
                //    ProcedureCodes = procedureCodes,
                //    VendorProviderSpecialityCodes = vendorProviderSpecialityCodes,
                //    PlaceOfService = "Hospital " + i,
                //    ReviewTypeId = i
                //};

                //var maxUnitsRule = new DecisionRule
                //{
                //    Name = "Rule2 " + i,
                //    ClientId = 22,
                //    LobId = 53,
                //    AuthTypeId = 1,
                //    MaxUnits = 1000,
                //    DiagnosisCodes = diagnosisCodes,
                //    ProcedureCodes = procedureCodes,
                //    VendorProviderSpecialityCodes = vendorProviderSpecialityCodes,
                //    PlaceOfService = "Hospital " + i,
                //    ReviewTypeId = i
                //};
                decisionRules.AddRange(new List<DecisionRule> { rule });
            }
            //var rules = JsonConvert.SerializeObject(decisionRules);
            //Trace.WriteLine(rules);
            return decisionRules;
        }

        public static IReadOnlyCollection<DecisionRule> Rules => new RulesRepository().Get(22, 53);

    }
}
