using System.Collections.Generic;

namespace RuleApiApplication.Messages
{
    public static class RuleStore
    {
        public static List<DecisionRule> Rules => new List<DecisionRule>
        {
            new DecisionRule
            {
                Name = "Rule1",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
               DiagnosisCodes = new HashSet<string>
                {
                    "X001","X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
            },
            new DecisionRule
            {
                Name = "Rule2",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                DiagnosisCodes = new HashSet<string>
                {
                    "X001","X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                MaxUnits = 500
            },
            new DecisionRule
            {
                Name = "Rule3",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                DiagnosisCodes = new HashSet<string>
                {
                    "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ProcedureCodes =  new HashSet<string>
                {
                    "K0011","K0012","K0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
            },
            new DecisionRule
            {
                Name = "Rule4",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                DiagnosisCodes = new HashSet<string>
                {
                    "X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ProcedureCodes =  new HashSet<string>
                {
                    "K002","K0011","K0012","K0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                PlaceOfService = "Hospital"
            },
            new DecisionRule
            {
                Name = "Rule5",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                 DiagnosisCodes = new HashSet<string>
                {
                    "X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ProcedureCodes =  new HashSet<string>
                {
                    "K002","K0011","K0012","K0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                PlaceOfService = "Hospital",
                RequestingProviderSpecialityCode = "X0002",
                IsRequestProviderInNetwork = true
            },
            new DecisionRule
            {
                Name = "Rule6",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                AgeLowerBound = 50,
                AgeUpperBound = 75,
                Gender = "M"
            },
            new DecisionRule
            {
                Name = "Rule7",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                DiagnosisCodes = new HashSet<string>
                {
                    "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ProcedureCodes =  new HashSet<string>
                {
                    "K0011","K0012","K0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                MaxUnits = 5000
            },
            new DecisionRule
            {
                Name = "Rule8",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                AgeLowerBound = 50,
                AgeUpperBound = 75,
                Gender = "F",
                PlaceOfService = "Emergency Room"
            },
            new DecisionRule
            {
                Name = "Rule9",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 1,
                DiagnosisCodes = new HashSet<string>
                {
                    "X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ProcedureCodes =  new HashSet<string>
                {
                    "K002","K0011","K0012","K0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                MaxUnits = 6000
            },
            new DecisionRule
            {
                Name = "Rule10",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 22
            },
            new DecisionRule
            {
                Name = "Rule11",
                ClientId = 10,
                LobId = 71,
                AuthTypeId = 2
            },
            new DecisionRule
            {
                Name = "Rule12",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 2,
                ReviewTypeId = 2
            },
            new DecisionRule
            {
                Name = "Rule13",
                ClientId = 22,
                LobId = 53,
                AuthTypeId = 2,
                DiagnosisCodes = new HashSet<string>
                {
                    "X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ReviewTypeId = 2
            },
            new DecisionRule
            {
                Name = "Rule14",
                ClientId = 10,
                LobId = 71,
                AuthTypeId = 2,
                DiagnosisCodes = new HashSet<string>
                {
                    "D0002","X002","X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                ProcedureCodes =  new HashSet<string>
                {
                    "P0001","K002","K0011","K0012","K0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022", "X0011","X0012","X0013","X0014","X0015","X0016","X0017","X0018","X0019"
                    ,"X0020","X0021","X0022"
                },
                PlaceOfService = "Inpatient Hospital"
            }
        };
    }
}