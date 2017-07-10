using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces
{
    public interface IMedicoVetAplication: IAplicationBase<MedicoVeterinario, MedicoVetViewModel>
    {
        IEnumerable<MedicoVetViewModel> SearchByName(string name);
    }
}
