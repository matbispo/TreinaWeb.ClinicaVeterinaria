using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Data.EntityConfig
{
    public abstract class EntityConfigBase<TEntity>:EntityTypeConfiguration<TEntity>
        where TEntity:class
    {
        public EntityConfigBase()
        {
            ConfigurationTableName();
            ConfigurationPropertiesTable();
            ConfigurationPrimaryKey();
            ConfigurationForeignKey();

        }

        protected abstract void ConfigurationForeignKey();
        protected abstract void ConfigurationPrimaryKey();
        protected abstract void ConfigurationPropertiesTable();
        protected abstract void ConfigurationTableName();       
    }
}
