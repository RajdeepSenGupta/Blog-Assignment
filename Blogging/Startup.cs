using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blogging.Startup))]
namespace Blogging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
