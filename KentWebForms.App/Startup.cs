using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KentWebForms.App.Startup))]
namespace KentWebForms.App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
