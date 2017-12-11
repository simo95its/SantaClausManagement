using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SantaClausManagement.Startup))]
namespace SantaClausManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
