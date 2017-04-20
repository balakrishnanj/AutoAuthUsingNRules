using System.Collections.Generic;
using RuleApiApplication.CustomAttributes;

namespace RuleApiApplication.Messages
{
    public class DecisionRule
    {
        public int ClientId { get; set; }
        public int LobId { get; set; }
        public int AuthTypeId { get; set; }
        public string Gender { get; set; }
        public int? AgeLowerBound { get; set; }
        public int? AgeUpperBound { get; set; }
        public HashSet<string> DiagnosisCodes { get; set; }
        public string PlaceOfService { get; set; }
        public HashSet<string> ProcedureCodes { get; set; }
        public string RequestingProviderSpecialityCode { get; set; }
        public bool? IsRequestProviderInNetwork { get; set; }
        public HashSet<string> VendorProviderSpecialityCodes { get; set; }
        public bool? IsVendorProviderInNetwork { get; set; }
        public int? ReviewTypeId { get; set; }
        public int? MaxUnits { get; set; }
        [RuleProperty]
        public int RuleId { get; set; }
        [RuleProperty]
        public string ResponseJson { get; set; }
        public string RuleJson { get; set; }
        public string RuleName { get; set; }
    }
}