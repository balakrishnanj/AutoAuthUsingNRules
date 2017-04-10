using Microsoft.Owin;
using Owin;
using RuleApiApplication;
using RuleApiApplication.Business;

[assembly: OwinStartup(typeof (Startup))]

namespace RuleApiApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DecisionRuleBootstrapper.Boostarp();
        }
    }
}