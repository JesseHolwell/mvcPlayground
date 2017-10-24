using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcPlayground.Startup))]
namespace mvcPlayground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
