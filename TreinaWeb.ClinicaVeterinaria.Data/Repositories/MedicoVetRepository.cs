using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ClinicaVeterinaria.Data.Context;
using TreinaWeb.ClinicaVeterinaria.Model.Entities;
using TreinaWeb.ClinicaVeterinaria.Model.Interfaces.Repositories;

namespace TreinaWeb.ClinicaVeterinaria.Data.Repositories
{
    public class MedicoVetRepository : IMedicoVetRepository
    {
        private ClinicaVeterinariaContext _context;

        public MedicoVetRepository()
        {
            _context = new ClinicaVeterinariaContext();
        }

        public void Add(MedicoVeterinario obj)
        {
            _context.MedicosVeterinarios.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(MedicoVeterinario obj)
        {
            _context.MedicosVeterinarios.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<MedicoVeterinario> SearchAll()
        {
            return _context.MedicosVeterinarios.ToList();
        }

        public MedicoVeterinario SearchById(int id)
        {
            return _context.MedicosVeterinarios.Find(id);
        }

        public IEnumerable<MedicoVeterinario> SearchByName(string name)
        {
            return _context.MedicosVeterinarios.ToList().Where(mv=> mv.Nome.Contains(name));
        }

        public void Update(MedicoVeterinario obj)
        {
            _context.MedicosVeterinarios.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
