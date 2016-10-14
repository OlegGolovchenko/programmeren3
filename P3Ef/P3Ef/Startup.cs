using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(P3Ef.Startup))]
namespace P3Ef
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
