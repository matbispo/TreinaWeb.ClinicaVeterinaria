using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreinaWeb.ClinicaVeterinaria.Data.EntityConfig
{
    class AnimalConfig : EntityConfigBase<Animal>
    {
        protected override void ConfigurationTableName()
        {
            ToTable("Animais");
        }

        protected override void ConfigurationPropertiesTable()
        {
            Property(a => a.AnimalId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("Varchar");

            Property(a=> a.Raca)
                .IsRequired()
                .HasMaxLength(50);

            Property(a=> a.NomeDono)
                .IsRequired()
                .HasMaxLength(150);
        }

        protected override void ConfigurationPrimaryKey()
        {
            HasKey(pk=> pk.AnimalId);
        }
        protected override void ConfigurationForeignKey()
        {

        }

    }
}
