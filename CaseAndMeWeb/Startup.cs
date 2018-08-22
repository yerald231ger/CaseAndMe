using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaseAndMeWeb.Startup))]
namespace CaseAndMeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
