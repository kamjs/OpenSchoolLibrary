using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenSchoolLibrary.Startup))]
namespace OpenSchoolLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
