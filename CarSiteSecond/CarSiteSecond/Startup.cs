using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarSiteSecond.Startup))]
namespace CarSiteSecond
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
