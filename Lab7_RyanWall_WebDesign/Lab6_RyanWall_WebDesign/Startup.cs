using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab6_RyanWall_WebDesign.Startup))]
namespace Lab6_RyanWall_WebDesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
