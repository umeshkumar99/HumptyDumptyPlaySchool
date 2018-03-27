using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HumptyDumptyPlaySchool.Startup))]
namespace HumptyDumptyPlaySchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
