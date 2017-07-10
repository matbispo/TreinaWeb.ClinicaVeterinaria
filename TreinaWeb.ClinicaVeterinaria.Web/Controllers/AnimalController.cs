﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.ClinicaVeterinaria.Aplication.Aplications;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;

namespace TreinaWeb.ClinicaVeterinaria.Web.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalAplication _animalApp;

        public AnimalController(IAnimalAplication animalApp)
        {
            _animalApp = animalApp;
        }
        // GET: Animal
        public ActionResult Index() // home page que lista todos os registros
        {
            var ListAnial = _animalApp.SearchAll();
            return View(ListAnial);
        }

        public ActionResult SearchByname(string name) // implementar com ajax
        {
            var animalDetail = _animalApp.SearchByName(name);
            return View(animalDetail);
        }

        public ActionResult AddAnimal() // cria tela de cadastro
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnimal(AnimalViewModel animalVM) // efetiva o cadastro
        {
            if (ModelState.IsValid)
            {
                _animalApp.Add(animalVM);
                return RedirectToAction("Index");
            }
            else {
                return null; // retornar erro
            }
        }

        public ActionResult AnimalUpdate(int id) { // cria tela de atualização

            if (id > 0)
            {
                var animalDetail = _animalApp.SearchById(id);
                return View(animalDetail);
            }
            else {
                return null; // retornar um erro
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnimalUpdate(AnimalViewModel animalVM) { // efetiva a atualização e retorna o objeto para a tela de detalhes

            if (ModelState.IsValid)
            {
                _animalApp.Update(animalVM);
                return RedirectToAction("AnimalDetails", animalVM.AnimalId);
            }
            else {
                return null; // erro
            }
        }

        public ActionResult AnimalDetails(int id) // detalhes
        {
            var animalDetail = _animalApp.SearchById(id);
            return View(animalDetail);
        }

        public ActionResult AnimalDelete(int id) // deletar
        {
            var animalDelete = _animalApp.SearchById(id);
            _animalApp.Delete(animalDelete);
            return RedirectToAction("Index");
        }
    }
}