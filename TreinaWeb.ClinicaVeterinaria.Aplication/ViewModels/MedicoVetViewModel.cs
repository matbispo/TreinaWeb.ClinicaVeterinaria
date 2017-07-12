using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels
{
    public class MedicoVetViewModel
    {
        [Key]
        public int MedicoVetId { get; set; }

        [Display(Name = "Nome do medico veterinario")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres"), MinLength(2, ErrorMessage = "Minmo de 2 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Numero do conselho regional de veterinaria")]
        [Required(ErrorMessage = "Campo obrigatorio")]
       // [StringLength(50, ErrorMessage = "Limite de 50 caracteres"), MinLength(7, ErrorMessage = "Minmo de 7 caracteres")]
        public int NumeroCRV { get; set; }
    }
}