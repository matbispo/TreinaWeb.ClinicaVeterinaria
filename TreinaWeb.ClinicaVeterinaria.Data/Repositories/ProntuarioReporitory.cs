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
    public class ProntuarioReporitory : IProntuarioRepository
    {
        private ClinicaVeterinariaContext _context;

        public ProntuarioReporitory()
        {
            _context = new ClinicaVeterinariaContext();
        }

        public void Add(Prontuario obj)
        {
            _context.Prontuarios.Include(p=> p.animal).Include(p=> p.medicoVeterinario);
            _context.Prontuarios.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Prontuario obj)
        {
            _context.Prontuarios.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Prontuario> SearchAll()
        {
            return _context.Prontuarios
                .Include(p=> p.animal).Include(p=> p.medicoVeterinario)
                .ToList();
        }

        public Prontuario SearchById(int id)
        {
            return _context.Prontuarios
                   .Include(p => p.animal).Include(p => p.medicoVeterinario)
                   .Where(p => p.ProntuarioId == id).First();
        }

        public IEnumerable<Prontuario> SearchByWord(string word)
        {
            return _context.Prontuarios.ToList().Where(mv => mv.Observacoes.Contains(word));
        }

        public void Update(Prontuario obj)
        {
            _context.Prontuarios.Attach(obj); // Include(p=> p.animal).Include(p=> p.medicoVeterinario)
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
