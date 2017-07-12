using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces
{
    public interface IProntuarioAplication: IAplicationBase<Prontuario, ProntuarioViewModel>
    {
        IEnumerable<ProntuarioViewModel> SearchByWord(string word);

        MedicoVetAnimal getAnimalMedico();
    }
}
