using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamingGuruBlog.Web.Startup))]
namespace GamingGuruBlog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
