using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalWard.Startup))]
namespace HospitalWard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
