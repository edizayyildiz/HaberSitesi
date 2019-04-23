using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HaberSitesi.Web.Startup))]
namespace HaberSitesi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
