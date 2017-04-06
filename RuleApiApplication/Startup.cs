using Microsoft.Owin;
using Owin;
using RuleApiApplication.Business;

[assembly: OwinStartup(typeof(RuleApiApplication.Startup))]

namespace RuleApiApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoAuthorizationRuleRepository.LoadRuleSets();
        }
    }
}
