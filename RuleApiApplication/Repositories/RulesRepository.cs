using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Newtonsoft.Json;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Repositories
{
    public interface IRulesRepository
    {
        IReadOnlyCollection<DecisionRule> Get();
    }
    public class RulesRepository : IRulesRepository
    {
        public IReadOnlyCollection<DecisionRule> Get()
        {
            var decisionRules = new List<DecisionRule>();
            var connectionString =
                "data source=.;initial catalog=UtilizationMgmt;Integrated Security=true;persist security info=True";

            var getClientLobAutoDecisionSql = "SELECT [RuleKey] as RuleId ,[Rule] as RuleName ,[IsActive]  ,[JSON] as [RuleJson] ,[ResponseJSON] as ResponseJson " +
                                              "FROM[UtilizationMgmt].[UMRef].[AutoDecisionRule] WHERE IsActive = 1";


            using (var dbConnection = GetConnection(connectionString))
            {
                var rules = dbConnection.Query<DecisionRule>(getClientLobAutoDecisionSql).ToList();
                foreach (var r in rules)
                {
                    var result = JsonConvert.DeserializeObject<DecisionRule>(r.RuleJson);
                    result.RuleName = r.RuleName;
                    result.RuleId = r.RuleId;
                    result.ResponseJson = r.ResponseJson;
                    result.RuleJson = r.RuleJson;
                    decisionRules.Add(result);
                }
            }
            return decisionRules.AsReadOnly();
        }

        private IDbConnection GetConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Connection string not found.");
            }

            var sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while opening connection to the database.", exception);
            }

            return sqlConnection;
        }
    }
}