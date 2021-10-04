using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHomework.Startup))]
namespace MyHomework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
