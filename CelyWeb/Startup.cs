using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CelyWeb.Startup))]
namespace CelyWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
