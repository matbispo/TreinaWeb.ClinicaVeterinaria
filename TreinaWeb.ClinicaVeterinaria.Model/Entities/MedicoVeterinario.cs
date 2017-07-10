using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Model.Entities
{
    public class MedicoVeterinario
    {
        public int MedicoVetId { get; set; }
        public string Nome { get; set; }
        public int NumeroCRV { get; set; }

        public virtual ICollection<Prontuario> Prontuarios { get; set; }

        public MedicoVeterinario()
        {
            this.Prontuarios = new List<Prontuario>();
        }
    }
}
