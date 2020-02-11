using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsuariosRoles.Startup))]
namespace UsuariosRoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
