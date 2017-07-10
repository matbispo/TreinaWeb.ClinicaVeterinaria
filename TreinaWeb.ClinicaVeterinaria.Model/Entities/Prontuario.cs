using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Model.Entities
{
    public class Prontuario
    {
        public int ProntuarioId { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
        public string Observacoes { get; set; }

        public int medicoVetId { get; set; }
        public int animalId { get; set; }

        public virtual Animal animal { get; set; }
        public virtual MedicoVeterinario medicoVeterinario { get; set; }
    }
}
