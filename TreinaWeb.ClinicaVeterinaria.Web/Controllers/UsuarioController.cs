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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Authorize(Roles = "ADMIN")]
        public ActionResult AddUser() // pagina para cadastrar usuario
        { 
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UsuarioViewModel user) // action para cadastrar o usuario
        { // pagina para fazer login

            if (ModelState.IsValid)
            {
                var userApp = new UserService();

                if (userApp.AddUser(user))
                {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    return View(user);
                }
            }
            else {
                return View(user);
            }
            
        }
    }
}