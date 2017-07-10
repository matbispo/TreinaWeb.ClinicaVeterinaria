using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Model.Entities
{
    public class Animal
    {
        public int AnimalId{ get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string NomeDono { get; set; }

        public virtual ICollection<Prontuario> Prontuarios { get; set; }

        public Animal()
        {
            this.Prontuarios = new List<Prontuario>();
        }
    }
}
