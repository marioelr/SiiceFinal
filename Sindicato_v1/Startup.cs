using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Sindicato_v1.Startup))]

namespace Sindicato_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
