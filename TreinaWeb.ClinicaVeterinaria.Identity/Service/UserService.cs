using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;



namespace TreinaWeb.ClinicaVeterinaria.Identity.Aplication
{
    public class UserService
    {

        public bool AddUser(UsuarioViewModel user) {

            var userStore = new UserStore<IdentityUser>( new ClinicaVeterinariaDB());
            var usermanager = new UserManager<IdentityUser>(userStore);

            var identityUser = new IdentityUser
            {
                UserName = user.Email,
                Email = user.Email
            };
            IdentityResult result = usermanager.Create(identityUser, user.Senha);

            if (result.Succeeded)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool LoginUser(UsuarioViewModel usuario)
        {
            var userStore = new UserStore<IdentityUser>(new ClinicaVeterinariaDB());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(usuario.Email, usuario.Senha);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                var authManager = HttpContext.Current.GetOwinContext().Authentication;
                authManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                },identity);

                return true;
            }
            else {
                return false;
            }
            
        }
        public void LogoffUser() {

            var authManager = HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
        }
    }
}
