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
    public class AnimalRepository : IAnimalRepository //RepositoryBase<Animal>
    {
        private ClinicaVeterinariaContext _context;

        public AnimalRepository()
        {
            _context = new ClinicaVeterinariaContext();
        }

        public void Add(Animal obj)
        {
            _context.Animais.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Animal obj)
        {
            _context.Animais.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> SearchAll()
        {
            return _context.Animais.ToList();
        }

        public Animal SearchById(int id)
        {
            return _context.Animais.Find(id);
        }

        public IEnumerable<Animal> SearchByName(string name)
        {
            return _context.Animais.ToList().Where(mv => mv.Nome.Contains(name));
        }

        public void Update(Animal obj)
        {
            _context.Animais.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
