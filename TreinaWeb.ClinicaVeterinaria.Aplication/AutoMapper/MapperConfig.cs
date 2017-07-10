using AutoMapper;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TreinaWeb.ClinicaVeterinaria.Aplication.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Animal, AnimalViewModel>();
            CreateMap<AnimalViewModel, Animal>();

            CreateMap<MedicoVeterinario, MedicoVetViewModel>();
            CreateMap<MedicoVetViewModel, MedicoVeterinario>();

            CreateMap<Prontuario, ProntuarioViewModel>();
            CreateMap<ProntuarioViewModel, Prontuario>();
        }

      /*  public static void Configure()
        {
            Mapper.Initialize(cfg=> {
                cfg.CreateMap<Animal, AnimalViewModel>();
                cfg.CreateMap<MedicoVeterinario, MedicoVetViewModel>();
                cfg.CreateMap<Prontuario, ProntuarioViewModel>();

                cfg.CreateMap<ProntuarioViewModel, Prontuario>();
                cfg.CreateMap<AnimalViewModel, Animal>();
                cfg.CreateMap<MedicoVetViewModel, MedicoVeterinario>();
            });
        }*/
    }
}
