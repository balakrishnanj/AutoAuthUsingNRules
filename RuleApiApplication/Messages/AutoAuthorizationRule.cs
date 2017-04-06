namespace RuleApiApplication.Messages
{
    public class AutoAuthorizationRule
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int LobId { get; set; }
        public int AuthTypeId { get; set; }
        public string Gender { get; set; }
        public int? AgeLowerBound { get; set; }
        public int? AgeUpperBound { get; set; }
        public string DiagnosisCode { get; set; }
        public string PlaceOfService { get; set; }
        public string ProcedureCode { get; set; }
        public string RequestingProviderSpecialityCode { get; set; }
        public bool? IsRequestProviderInNetwork { get; set; }
        public string VendorProviderSpecialityCode { get; set; }
        public bool? IsVendorProviderInNetwork { get; set; }
        public int? ReviewTypeId { get; set; }
        public int? MaxUnits { get; set; }
    }
}