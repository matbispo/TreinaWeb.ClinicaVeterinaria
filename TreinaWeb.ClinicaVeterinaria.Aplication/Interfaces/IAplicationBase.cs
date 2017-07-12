using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ClinicaVeterinaria.Aplication.Interfaces
{
    public interface IAplicationBase<TEntity, TViewModel> where TViewModel : class
    {
        void Add(TViewModel obj);
        void Delete(int id);
        void Update(TViewModel obj);
        TViewModel SearchById(int id);
        IEnumerable<TViewModel> SearchAll();
    }
}
