using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustDoIt.Startup))]
namespace JustDoIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
