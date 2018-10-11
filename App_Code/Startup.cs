using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BargainBaubles.Startup))]
namespace BargainBaubles
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
