using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Helpers;
using Dapper;
using Newtonsoft.Json;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Repositories
{
    public interface IRulesRepository
    {
        IReadOnlyCollection<DecisionRule> Get(int clientId, int lobId);
    }
    public class RulesRepository : IRulesRepository
    {
        public IReadOnlyCollection<DecisionRule> Get(int clientId, int lobId)
        {
            var decisionRules = new List<DecisionRule>();
            var connectionString =
                "data source=.;initial catalog=UtilizationMgmt;Integrated Security=true;persist security info=True";
            //var getClientLobAutoDecisionSql = "SELECT JSON as [Rule] " +
            //                                  "FROM [UtilizationMgmt].[UMRef].[ClientLOBAutoDecision] cla " +
            //                                  "JOIN[UtilizationMgmt].[UMRef].[AutoDecisionRule] adr " +
            //                                  "ON  cla.RuleKey = adr.RuleKey " +
            //                                  "WHERE cla.ClientId = @clientId AND cla.LOBKey = @lobId AND cla.IsAutoDecisionEnabled = 1";

            var getClientLobAutoDecisionSql = "SELECT JSON as [Rule] " +
                                              "FROM [UtilizationMgmt].[UMRef].[AutoDecisionRule] adr" ;


            using (var dbConnection = GetConnection(connectionString))
            {
                var rules = dbConnection.Query<string>(getClientLobAutoDecisionSql, new { clientId, lobId }).ToList();
                if (rules.Count > 0)
                {
                    decisionRules.AddRange(rules.Select(JsonConvert.DeserializeObject<DecisionRule>));
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