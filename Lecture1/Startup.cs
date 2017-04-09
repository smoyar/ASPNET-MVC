using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lecture1.Startup))]
namespace Lecture1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
