using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;

namespace TreinaWeb.ClinicaVeterinaria.Data.EntityConfig
{
    public class ProntuarioConfig : EntityConfigBase<Prontuario>
    {
        protected override void ConfigurationTableName()
        {
            ToTable("Prontuarios");
        }

        protected override void ConfigurationPropertiesTable()
        {
            Property(cfg=> cfg.Observacoes).
                IsRequired()
                .HasMaxLength(250);

            Property(cfg=> cfg.DataHoraAtendimento)
                .IsRequired();
        }

        protected override void ConfigurationPrimaryKey()
        {
            HasKey(cfg=> cfg.ProntuarioId);
        }

        protected override void ConfigurationForeignKey()
        {
            HasRequired(cfg => cfg.animal)
                .WithMany(fk=> fk.Prontuarios)
                .HasForeignKey(fk=> fk.animalId);

            HasRequired(cfg => cfg.medicoVeterinario)
                .WithMany(fk => fk.Prontuarios)
                .HasForeignKey(fk => fk.medicoVetId);
        }
    }
}
