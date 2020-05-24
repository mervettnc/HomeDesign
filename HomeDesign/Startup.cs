using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeDesign.Startup))]
namespace HomeDesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
