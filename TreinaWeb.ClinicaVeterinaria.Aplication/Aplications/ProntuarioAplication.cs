using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;
using TreinaWeb.ClinicaVeterinaria.Model.Interfaces.Repositories;
using AutoMapper;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.Aplications
{
    public class ProntuarioAplication : IProntuarioAplication
    {
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly IMedicoVetRepository _medicoApp;
        private readonly IAnimalRepository _animalApp;

        public ProntuarioAplication(IProntuarioRepository prontuarioRepository, IMedicoVetRepository medicoApp, IAnimalRepository animalApp)
        {
            _prontuarioRepository = prontuarioRepository;
            _medicoApp = medicoApp;
            _animalApp = animalApp;
        }

        public void Add(ProntuarioViewModel obj)
        {
            var prontuarioEntt = Mapper.Map<ProntuarioViewModel, Prontuario>(obj);
            _prontuarioRepository.Add(prontuarioEntt);
        }

        public void Delete(int id)
        {
            //var prontuarioEntt = Mapper.Map<ProntuarioViewModel, Prontuario>(obj);
            var prontuarioEntt = _prontuarioRepository.SearchById(id);
            _prontuarioRepository.Delete(prontuarioEntt);
        }

        public IEnumerable<ProntuarioViewModel> SearchAll()
        {
            var prontuarioEntt  = _prontuarioRepository.SearchAll();

            var prontuarioVM = Mapper.Map<IEnumerable<Prontuario>, IEnumerable<ProntuarioViewModel>>(prontuarioEntt); 

            return prontuarioVM;
        }

        public ProntuarioViewModel SearchById(int id)
        {
            var prontuarioEntt = _prontuarioRepository.SearchById(id);

            var prontuarioVM = Mapper.Map<Prontuario, ProntuarioViewModel>(prontuarioEntt);

            return prontuarioVM;
        }

        public IEnumerable<ProntuarioViewModel> SearchByWord(string word)
        {
            var prontuarioEntt = _prontuarioRepository.SearchByWord(word);

            var prontuarioVM = Mapper.Map<IEnumerable<Prontuario>, IEnumerable<ProntuarioViewModel>>(prontuarioEntt);

            return prontuarioVM;
        }

        public void Update(ProntuarioViewModel obj)
        {
            var prontuarioEntt = Mapper.Map<ProntuarioViewModel, Prontuario>(obj);
            _prontuarioRepository.Update(prontuarioEntt);
        }

        public MedicoVetAnimal getAnimalMedico()
        {
            var AnimalMedic = new MedicoVetAnimal();

            AnimalMedic.animais = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_animalApp.SearchAll());
            AnimalMedic.medicoVeterinarios = Mapper.Map<IEnumerable<MedicoVeterinario>, IEnumerable<MedicoVetViewModel>>(_medicoApp.SearchAll());

            return AnimalMedic;
        }
    }
}
