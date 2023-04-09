using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StandBy.Startup))]
namespace StandBy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
