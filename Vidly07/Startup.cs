using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly07.Startup))]
namespace Vidly07
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
