using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SepApplication02.Startup))]
namespace SepApplication02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
