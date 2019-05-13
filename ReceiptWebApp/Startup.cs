using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReceiptWebApp.Startup))]
namespace ReceiptWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
