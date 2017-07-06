using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prototipo_1._3.Startup))]
namespace prototipo_1._3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
