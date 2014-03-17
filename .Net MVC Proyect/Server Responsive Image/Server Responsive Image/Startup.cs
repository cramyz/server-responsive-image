using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Server_Responsive_Image.Startup))]
namespace Server_Responsive_Image
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
