using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventBoard.Presentation.Startup))]
namespace EventBoard.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
