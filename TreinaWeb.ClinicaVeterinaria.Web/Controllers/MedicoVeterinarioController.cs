using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;

namespace TreinaWeb.ClinicaVeterinaria.Web.Controllers
{
    public class MedicoVeterinarioController : Controller
    {
        private readonly IMedicoVetAplication _medicoVetApp;

        public MedicoVeterinarioController(IMedicoVetAplication medicoVetApp)
        {
            _medicoVetApp = medicoVetApp;
        }
        // GET: MedicoVeterinario
        public ActionResult Index()
        {
            var listMedicoVet = _medicoVetApp.SearchAll();
            return View(listMedicoVet);
        }

        public ActionResult AddMedicoVet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedicoVet(MedicoVetViewModel medicoVet)
        {
            if (ModelState.IsValid)
            {
                _medicoVetApp.Add(medicoVet);
                return RedirectToAction("Index");
            }
            else {
                return null;
            }        
        }

        public ActionResult UpdateMedicoVet(int id)
        {
            var medicoVet = _medicoVetApp.SearchById(id);
            return View(medicoVet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMedicoVet(MedicoVetViewModel medicoVet)
        {
            if (ModelState.IsValid)
            {
                _medicoVetApp.Update(medicoVet);
                return RedirectToAction("DetailsMedicoVet",new {@id= medicoVet.MedicoVetId });
            }
            else {
                return null;
            }
        }

        public ActionResult DetailsMedicoVet(int id)
        {
            var medicoVet = _medicoVetApp.SearchById(id);
            return View(medicoVet);
        }

        public ActionResult DeleteMedicoVet(int id)
        {
            _medicoVetApp.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SearchByNameMedicoVet(string name)
        {
            var medicoVet = _medicoVetApp.SearchByName(name);
            return View(medicoVet);
        }
    }
}