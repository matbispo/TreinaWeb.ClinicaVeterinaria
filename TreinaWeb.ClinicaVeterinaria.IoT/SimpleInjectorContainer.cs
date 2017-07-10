using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Aplication.Aplications;
using TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces;
using TreinaWeb.ClinicaVeterinaria.Data.Repositories;
using TreinaWeb.ClinicaVeterinaria.Model.Interfaces.Repositories;

namespace TreinaWeb.ClinicaVeterinaria.IoC
{
    public static class SimpleInjectorContainer
    {
        public static void RegisterServices(Container container)
        {
            // repositories
            container.Register<IAnimalRepository, AnimalRepository>();
            container.Register<IProntuarioRepository, ProntuarioReporitory>();
            container.Register<IMedicoVetRepository, MedicoVetRepository>();
            
            //Aplications
            container.Register<IAnimalAplication, AnimalAplication>();
            container.Register<IMedicoVetAplication, MedicoVetAplication>();
            container.Register<IProntuarioAplication, ProntuarioAplication>();

            // container.Verify();

            //return container;

            // ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
