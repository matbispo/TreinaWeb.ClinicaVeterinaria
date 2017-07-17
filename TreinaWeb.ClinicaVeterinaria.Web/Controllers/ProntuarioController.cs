using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;

namespace TreinaWeb.ClinicaVeterinaria.Web.Controllers
{
    [Authorize]
    public class ProntuarioController : Controller
    {
        private readonly IProntuarioAplication _prontuarioApp;


        public ProntuarioController(IProntuarioAplication prontuarioApp)
        {
            _prontuarioApp = prontuarioApp;
        }
        // GET: Prontuario
        public ActionResult Index()
        {
            var listProntuarios = _prontuarioApp.SearchAll();
            return View(listProntuarios);
        }

        [Authorize(Roles = "MEDICOVET")]
        public ActionResult AddProntuario()
        {
            var listAnimaisMedicos = _prontuarioApp.getAnimalMedico();

            SelectList dropMedicos = new SelectList(listAnimaisMedicos.medicoVeterinarios, "MedicoVetId","Nome");
            SelectList dropanimais = new SelectList(listAnimaisMedicos.animais, "AnimalId", "Nome");
            ViewBag.dropMedicos = dropMedicos;
            ViewBag.dropanimais = dropanimais;

            return View();
        }

        [Authorize(Roles ="MEDICOVET")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProntuario(ProntuarioViewModel prontuario)
        {
            if (ModelState.IsValid)
            {
                _prontuarioApp.Add(prontuario);
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("erro", "falha ao criar cadastro");
                return View(ModelState);
            } 
        }

        [Authorize(Roles = "MEDICOVET")]
        public ActionResult UpdateProntuario(int id)
        {
            var prontuario = _prontuarioApp.SearchById(id);

            var listAnimaisMedicos = _prontuarioApp.getAnimalMedico();

            SelectList dropMedicos = new SelectList(listAnimaisMedicos.medicoVeterinarios, "MedicoVetId", "Nome");
            SelectList dropanimais = new SelectList(listAnimaisMedicos.animais, "AnimalId", "Nome");
            ViewBag.dropMedicos = dropMedicos;
            ViewBag.dropanimais = dropanimais;

            return View(prontuario);
        }

        [Authorize(Roles = "MEDICOVET")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProntuario(ProntuarioViewModel prontuario)
        {
            if (ModelState.IsValid)
            {
                _prontuarioApp.Update(prontuario);
                return RedirectToAction("DetaisProntuario", new {@id = prontuario.ProntuarioId });
            }
            else
            {
                ModelState.AddModelError("erro", "falha em atualizar");
                return View(ModelState);
            }
        }

        public ActionResult DetaisProntuario(int id)
        {
            var prontuario = _prontuarioApp.SearchById(id);
            return View(prontuario);
        }

        [Authorize(Roles = "MEDICOVET")]
        public ActionResult RemoveProntuario(int id)
        {
            _prontuarioApp.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SearchByWordProntuario(string word)
        {
            var prontuario = _prontuarioApp.SearchByWord(word);

            return View();
        }
    }
}