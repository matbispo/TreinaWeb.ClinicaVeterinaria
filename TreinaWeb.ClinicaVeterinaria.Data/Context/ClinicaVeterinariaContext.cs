using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TreinaWeb.ClinicaVeterinaria.Data.EntityConfig;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace TreinaWeb.ClinicaVeterinaria.Data.Context
{
    class ClinicaVeterinariaContext: DbContext
    {
        public ClinicaVeterinariaContext()
            :base("ClinicaVeterinariaDB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<MedicoVeterinario> MedicosVeterinarios { get; set; }
        public DbSet<Prontuario> Prontuarios{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add( new AnimalConfig());
            modelBuilder.Configurations.Add(new ProntuarioConfig());
            modelBuilder.Configurations.Add(new MedicoVetConfig());
        }
    }
}
