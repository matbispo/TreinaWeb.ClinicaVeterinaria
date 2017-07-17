using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TreinaWeb.ClinicaVeterinaria.Identity.Aplication
{
    public class ClinicaVeterinariaDB : IdentityDbContext<IdentityUser>
    {
        public ClinicaVeterinariaDB()
            :base("ClinicaVeterinariaDB")
        {
        }
    }
}