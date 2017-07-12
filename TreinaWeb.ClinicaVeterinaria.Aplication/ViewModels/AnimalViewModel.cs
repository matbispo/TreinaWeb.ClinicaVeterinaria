using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels
{
    public class AnimalViewModel
    {
        [Key]
        public int AnimalId { get; set; }

        [Display(Name = "Nome do animal")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage ="Limite de 50 caracteres"), MinLength(2, ErrorMessage ="Minmo de 2 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Raça do Animal")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres"), MinLength(2, ErrorMessage = "Minmo de 5 caracteres")]
        public string Raca { get; set; }

        [Display(Name = "Nome do dono")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres"), MinLength(2, ErrorMessage = "Minmo de 5 caracteres")]
        public string NomeDono { get; set; }
    }
}