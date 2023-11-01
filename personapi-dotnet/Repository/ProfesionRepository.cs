using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;
        public ProfesionRepository() { _context = new PersonaDbContext(); }
        public ProfesionRepository(PersonaDbContext context) { _context = context; }
        public IEnumerable<Profesion> GetAll() { return _context.Profesions.ToList(); }
        public Profesion GetById(int ProfesionID) { return _context.Profesions.Find(ProfesionID); }
        public void Insert(Profesion profesion) { _context.Profesions.Add(profesion); }
        public void Update(Profesion profesion) { _context.Entry(profesion).State = EntityState.Modified; }
        public void Delete(int ProfesionID)
        {
            Profesion profesion = _context.Profesions.Find(ProfesionID);
            if (profesion != null) { _context.Profesions.Remove(profesion); }
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
