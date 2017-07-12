using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using TreinaWeb.ClinicaVeterinaria.Data.Repositories;
using TreinaWeb.ClinicaVeterinaria.Model.Interfaces.Repositories;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.Aplications
{
    public class AnimalAplication: IAnimalAplication
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalAplication(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void Add(AnimalViewModel obj)
        {
            var animalEntt = Mapper.Map<AnimalViewModel, Animal>(obj);
            _animalRepository.Add(animalEntt);
        }

        public void Delete(int id)
        {
            //var animalEntt = Mapper.Map<AnimalViewModel, Animal>(obj);
            var obj = _animalRepository.SearchById(id);
             _animalRepository.Delete(obj);
        }

        public IEnumerable<AnimalViewModel> SearchAll()
        {
            var animalEntt = _animalRepository.SearchAll();
            var tAnimalVM = new List<AnimalViewModel>();

            foreach (var item in animalEntt)
            {
                tAnimalVM.Add(Mapper.Map<Animal, AnimalViewModel>(item));
            }

            return tAnimalVM;
        }

        public AnimalViewModel SearchById(int id)
        {
            var animalEntt = _animalRepository.SearchById(1);
            var tAnimalVM = Mapper.Map<Animal, AnimalViewModel>(animalEntt);
            return tAnimalVM;
        }

        public IEnumerable<AnimalViewModel> SearchByName(string name)
        {
            var animalEntt = _animalRepository.SearchByName(name);
            var tAnimalVM = new List<AnimalViewModel>();

            foreach (var item in animalEntt)
            {
                tAnimalVM.Add(Mapper.Map<Animal, AnimalViewModel>(item));
            }

            return tAnimalVM;
        }

        public void Update(AnimalViewModel obj)
        {
            var animalEntt = Mapper.Map<AnimalViewModel, Animal>(obj);
            _animalRepository.Update(animalEntt);
        }
    }
}
