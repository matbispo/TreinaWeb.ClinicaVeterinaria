using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using AutoMapper;
using TreinaWeb.ClinicaVeterinaria.Model.Interfaces.Repositories;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.Aplications
{
    public class MedicoVetAplication : IMedicoVetAplication
    {
        private readonly IMedicoVetRepository _medicoVet;

        public MedicoVetAplication(IMedicoVetRepository medicoVet)
        {
            _medicoVet = medicoVet;
        }

        public void Add(MedicoVetViewModel obj)
        {
            var medicoVetEntt = Mapper.Map<MedicoVetViewModel, MedicoVeterinario>(obj);
            _medicoVet.Add(medicoVetEntt);
        }

        public void Delete(int id)
        {
            var obj = _medicoVet.SearchById(id);
            //var medicoVetEntt = Mapper.Map<MedicoVetViewModel, MedicoVeterinario>(obj);
            _medicoVet.Delete(obj);
        }

        public IEnumerable<MedicoVetViewModel> SearchAll()
        {
            var medicoVetEntt = _medicoVet.SearchAll();

            var medicoVetVM = new List<MedicoVetViewModel>();

            foreach (var item in medicoVetEntt)
            {
                medicoVetVM.Add(Mapper.Map<MedicoVeterinario, MedicoVetViewModel>(item));
            }

            return medicoVetVM;
        }

        public MedicoVetViewModel SearchById(int id)
        {
            var medicoVetEntt = _medicoVet.SearchById(id);

            var medicoVetVM = Mapper.Map<MedicoVeterinario, MedicoVetViewModel>(medicoVetEntt);

            return medicoVetVM;
        }

        public IEnumerable<MedicoVetViewModel> SearchByName(string name)
        {
            var medicoVetEntt = _medicoVet.SearchByName(name);

            var medicoVetVM = new List<MedicoVetViewModel>();

            foreach (var item in medicoVetEntt)
            {
                medicoVetVM.Add(Mapper.Map<MedicoVeterinario, MedicoVetViewModel>(item));
            }

            return medicoVetVM;
        }

        public void Update(MedicoVetViewModel obj)
        {
            var medicoVetEntt = Mapper.Map<MedicoVetViewModel, MedicoVeterinario>(obj);
            _medicoVet.Update(medicoVetEntt);
        }
    }
}
