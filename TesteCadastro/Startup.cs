using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteCadastro.Startup))]
namespace TesteCadastro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
