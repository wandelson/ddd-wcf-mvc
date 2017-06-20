using Mvc;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
