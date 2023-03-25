using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WedBanDungCuXayDung.Startup))]
namespace WedBanDungCuXayDung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
