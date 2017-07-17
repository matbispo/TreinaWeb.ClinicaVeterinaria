using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="Email obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatorio!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
