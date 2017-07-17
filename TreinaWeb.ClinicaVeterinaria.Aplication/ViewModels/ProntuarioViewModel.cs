using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels
{
    public class ProntuarioViewModel
    {
        [Key]
        public int ProntuarioId { get; set; }

        [Display(Name = "Data do atendimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DataHoraAtendimento { get; set; }

        [Display(Name = "Observações")]
        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        [StringLength(250, ErrorMessage = "Limite de 250 caracteres"), MinLength(10, ErrorMessage = "Minmo de 10 caracteres")]
        public string Observacoes { get; set; }

        [Display(Name = "medico veterinario")]
        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        //[StringLength(50, ErrorMessage = "Limite de 50 caracteres"), MinLength(7, ErrorMessage = "Minmo de 7 caracteres")]
        public int medicoVetId { get; set; }

        [Display(Name = "Animal atendido")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        //[StringLength(50, ErrorMessage = "Limite de 50 caracteres"), MinLength(7, ErrorMessage = "Minmo de 7 caracteres")]
        public int animalId { get; set; }

        public virtual AnimalViewModel animal { get; set; }
        public virtual MedicoVetViewModel medicoVeterinario { get; set; }

    }
}
