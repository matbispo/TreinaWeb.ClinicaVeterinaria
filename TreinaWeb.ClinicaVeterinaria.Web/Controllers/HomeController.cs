using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using TreinaWeb.ClinicaVeterinaria.Identity.Aplication;

namespace TreinaWeb.ClinicaVeterinaria.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Home() // pagina inicial da aplicacao
        {
            return View();
        }

        public ActionResult Index() // pagina inicial de logado *
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login() { // pagina para fazer login

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel user) // action para autenticar
        { // pagina para fazer login
            if (ModelState.IsValid)
            {
                var userApp = new UserService();
                if (userApp.LoginUser(user))
                {
                    return RedirectToAction("Index");
                }
                else {
                    // ModelState.AddModelError("erro", "usuario ou senha invalidos");
                     return View(user);
                }
            }
            else {
                return View(ModelState);
            }
        }

        public ActionResult Logoff() // acao de loff
        {
            var userApp = new UserService();
            userApp.LogoffUser();
            return RedirectToAction("Home");
        }


    }
}