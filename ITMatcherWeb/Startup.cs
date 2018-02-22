using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITMatcherWeb.Startup))]
namespace ITMatcherWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
