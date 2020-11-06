using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessWeb30086701.Startup))]
namespace FitnessWeb30086701
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
