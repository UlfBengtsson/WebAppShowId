using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppShowId.Startup))]
namespace WebAppShowId
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
