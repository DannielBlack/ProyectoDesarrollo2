using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProyectoMVC.Models;

[assembly: OwinStartupAttribute(typeof(ProyectoMVC.Startup))]
namespace ProyectoMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CrearRolUsuario();
        }
        /*private void CrearRolUsuario()
         {
             ApplicationDbContext db = new ApplicationDbContext();

             var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
             var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
             if (!roleManager.RoleExists("Admin"))
             {
                 var role = new IdentityRole();
                 role.Name = "Admin";
                 roleManager.Create(role);
                 var user = new ApplicationUser();
                 user.UserName = "admin@desarrollo.com";
                 user.Email = "admin@desarrollo.com";
                 string userPWD = "Admin123.";
                 userManager.Create(user, userPWD);
                 userManager.AddToRole(user.Id, "Admin");
             }
             if (!roleManager.RoleExists("Usuario"))
             {
                 var role = new IdentityRole();
                 role.Name = "Usuario";
                 roleManager.Create(role);
                 var user = new ApplicationUser();
                 user.UserName = "sergio@desarrollo.com";
                 user.Email = "sergio@desarrollo.com";
                 string userPWD = "Usuario123.";
                 userManager.Create(user, userPWD);
                 userManager.AddToRole(user.Id, "Usuario");

             }

         }*/
    }
}
