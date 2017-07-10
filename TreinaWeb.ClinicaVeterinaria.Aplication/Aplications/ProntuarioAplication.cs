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

        public ProntuarioAplication(IProntuarioRepository prontuarioRepository)
        {
            _prontuarioRepository = prontuarioRepository;
        }

        public void Add(ProntuarioViewModel obj)
        {
            var prontuarioEntt = Mapper.Map<ProntuarioViewModel, Prontuario>(obj);
            _prontuarioRepository.Add(prontuarioEntt);
        }

        public void Delete(ProntuarioViewModel obj)
        {
            var prontuarioEntt = Mapper.Map<ProntuarioViewModel, Prontuario>(obj);
            _prontuarioRepository.Delete(prontuarioEntt);
        }

        public IEnumerable<ProntuarioViewModel> SearchAll()
        {
            var prontuarioEntt  = _prontuarioRepository.SearchAll();

            var prontuarioVM = new List<ProntuarioViewModel>();

            foreach (var item in prontuarioEntt)
            {
                prontuarioVM.Add(Mapper.Map<Prontuario, ProntuarioViewModel>(item));
            }
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

            var prontuarioVM = new List<ProntuarioViewModel>();

            foreach (var item in prontuarioEntt)
            {
                prontuarioVM.Add(Mapper.Map<Prontuario, ProntuarioViewModel>(item));
            }
            return prontuarioVM;
        }

        public void Update(ProntuarioViewModel obj)
        {
            var prontuarioEntt = Mapper.Map<ProntuarioViewModel, Prontuario>(obj);
            _prontuarioRepository.Update(prontuarioEntt);
        }
    }
}
