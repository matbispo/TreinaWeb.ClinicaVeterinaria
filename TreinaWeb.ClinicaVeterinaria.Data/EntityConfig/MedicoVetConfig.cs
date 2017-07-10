using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;

namespace TreinaWeb.ClinicaVeterinaria.Data.EntityConfig
{
    public class MedicoVetConfig : EntityConfigBase<MedicoVeterinario>
    {
        protected override void ConfigurationTableName()
        {
            ToTable("MedicosVeterinarios");
        }

        protected override void ConfigurationPropertiesTable()
        {
            Property(cfg=> cfg.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(cfg => cfg.NumeroCRV)
                .IsRequired();
        }

        protected override void ConfigurationPrimaryKey()
        {
            HasKey(cfg=> cfg.MedicoVetId);
        }

        protected override void ConfigurationForeignKey()
        {
            
        }
    }
}
