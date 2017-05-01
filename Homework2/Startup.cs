using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework2.Startup))]
namespace Homework2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
