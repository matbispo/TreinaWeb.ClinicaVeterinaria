using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Model.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        TEntity SearchById(int id);
        IEnumerable<TEntity> SearchAll();
    }
}
