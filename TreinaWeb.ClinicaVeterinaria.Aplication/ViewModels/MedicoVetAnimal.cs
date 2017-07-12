using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels
{
    public class MedicoVetAnimal
    {
        public IEnumerable<AnimalViewModel> animais { get; set; }
        public IEnumerable<MedicoVetViewModel> medicoVeterinarios { get; set; }

        public MedicoVetAnimal()
        {
            this.animais = new List<AnimalViewModel>();
            this.medicoVeterinarios = new List<MedicoVetViewModel>();
        }
    }
}
