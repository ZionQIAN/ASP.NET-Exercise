using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032Assignment1_ver2.Startup))]
namespace FIT5032Assignment1_ver2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
