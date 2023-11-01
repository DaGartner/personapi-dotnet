using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class PersonaRepository:IPersonaRepository
    {
        private readonly PersonaDbContext _context;
        public PersonaRepository() { _context = new PersonaDbContext(); }
        public PersonaRepository(PersonaDbContext context) { _context = context; }
        public IEnumerable<Persona> GetAll() { return _context.Personas.ToList(); }
        public Persona GetById(int PersonaID) { return _context.Personas.Find(PersonaID); }
        public void Insert(Persona persona) { _context.Personas.Add(persona); }
        public void Update(Persona persona) { _context.Entry(persona).State = EntityState.Modified; }
        public void Delete(int PersonaID)
        {
            Persona persona = _context.Personas.Find(PersonaID);
            if (persona != null) { _context.Personas.Remove(persona); }
        }
        public void Save() { _context.SaveChanges(); }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed) { if (disposing) { _context.Dispose(); } }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
