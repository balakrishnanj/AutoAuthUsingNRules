using System.Collections.Generic;

namespace RuleApiApplication.Messages
{
    public static class RuleStore
    {
        public static List<AutoAuthorizationRule> Rules => new List<AutoAuthorizationRule>
        {
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule1",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X001",
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule2",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X001",
            //    MaxUnits = 500
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule3",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X002",
            //    ProcedureCode = "K002"
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule4",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X002",
            //    ProcedureCode = "K002",
            //    PlaceOfService = "Hospital"
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule5",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X002",
            //    ProcedureCode = "K002",
            //    PlaceOfService = "Hospital",
            //    RequestingProviderSpecialityCode = "X0002",
            //    IsRequestProviderInNetwork = true
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule6",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    AgeLowerBound = 50,
            //    AgeUpperBound = 75,
            //    Gender = "M",
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule7",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X003",
            //    ProcedureCode = "K004",
            //    MaxUnits = 5000
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule8",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    AgeLowerBound = 50,
            //    AgeUpperBound = 75,
            //    Gender = "F",
            //    PlaceOfService = "Emergency Room"
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule9",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    DiagnosisCode = "X006",
            //    ProcedureCode = "K0010",
            //    MaxUnits = 6000
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule10",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //},
            new AutoAuthorizationRule
            {
                Name = "Rule11",
                ClientId = 10,
                LobId = 71,
                AuthTypeId = 2,
            },
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule12",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 2,
            //    ReviewTypeId = 2
            //},
            //new AutoAuthorizationRule
            //{
            //    Name = "Rule13",
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 2,
            //    DiagnosisCode = "X002",
            //    ReviewTypeId = 2
            //},
            new AutoAuthorizationRule
            {
                Name = "Rule14",
                ClientId = 10,
                LobId = 71,
                AuthTypeId = 2,
                DiagnosisCode = "D0002",
                ProcedureCode = "P0001",
                PlaceOfService = "Inpatient Hospital"
            }
        };
    }
}