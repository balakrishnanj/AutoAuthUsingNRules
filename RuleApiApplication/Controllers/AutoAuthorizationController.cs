using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RuleApiApplication.Business;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Controllers
{
    public class AutoAuthorizationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Validate(AutoAuthorizationContract contract)
        {
            //var contract = new AutoAuthorizationContract
            //{
            //    ClientId = 22,
            //    LobId = 53,
            //    AuthTypeId = 1,
            //    Age = 100,
            //    Gender = "F",
            //    PlaceOfService = "Emergency Room"
            //};
            new RuleEngine().ExecuteRule(contract);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
