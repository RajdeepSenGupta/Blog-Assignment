using Autofac;
using Blogging.Models;
using Microsoft.Owin;
using MySql.Data.Entity;
using Owin;
using System.Data.Entity;

[assembly: OwinStartup(typeof(Blogging.Startup))]
namespace Blogging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = AutoFac.Start();

            ConfigureAuth(app);
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            using (var context = container.Resolve<ApplicationDbContext>())
            {
                context.Database.Initialize(false);
            }
        }
    }
}
