using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RuleApiApplication.Business;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Controllers
{
    public class AutoAuthorizationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Validate(List<DecisionRuleRequest> contracts)
        {
            var responses = new RuleEngine().ExecuteRule(contracts);
            return Request.CreateResponse(responses);
        }
    }
}