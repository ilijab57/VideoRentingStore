using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoRentingStore.Startup))]
namespace VideoRentingStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
