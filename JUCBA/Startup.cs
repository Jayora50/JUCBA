using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JUCBA.Startup))]
namespace JUCBA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
