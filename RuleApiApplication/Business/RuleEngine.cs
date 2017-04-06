using System;
using System.Threading.Tasks;
using NRules;
using NRules.Diagnostics;
using RuleApiApplication.Messages;

namespace RuleApiApplication.Business
{
    public class RuleEngine
    {
        public static readonly Lazy<ISessionFactory> sessionFactory = new Lazy<ISessionFactory>(() => new AutoAuthorizationRuleRepository().Compile());
        public async Task ExecuteRuleAsync(AutoAuthorizationContract autoAuthRequest)
        {
            await Task.Factory.StartNew(() =>
            {
                ISessionFactory sessionFactory = new AutoAuthorizationRuleRepository().Compile();
                var session = sessionFactory.CreateSession();
                session.Events.RuleFiredEvent += OnRuleFired;
                session.Insert(autoAuthRequest);
                session.Fire();
            });
        }

        private void OnRuleFired(object sender, AgendaEventArgs e)
        {
           
        }

        public void ExecuteRule(AutoAuthorizationContract autoAuthorizationContract)
        {
            if(autoAuthorizationContract == null)throw new ArgumentNullException();
            var session = sessionFactory.Value.CreateSession();
            session.Events.RuleFiredEvent += OnRuleFired;
            session.Insert(autoAuthorizationContract);
            session.Fire();
        }
    }
}