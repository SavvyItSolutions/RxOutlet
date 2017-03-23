using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RxOutlet.Startup))]
namespace RxOutlet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
