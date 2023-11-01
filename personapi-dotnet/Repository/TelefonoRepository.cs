using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;
        public TelefonoRepository() { _context = new PersonaDbContext(); }
        public TelefonoRepository(PersonaDbContext context) { _context = context; }
        public IEnumerable<Telefono> GetAll() { return _context.Telefonos.ToList(); }
        public Telefono GetById(int TelefonoID) { return _context.Telefonos.Find(TelefonoID); }
        public void Insert(Telefono telefono) { _context.Telefonos.Add(telefono); }
        public void Update(Telefono telefono) { _context.Entry(telefono).State = EntityState.Modified; }
        public void Delete(int TelefonoID)
        {
            Telefono telefono = _context.Telefonos.Find(TelefonoID);
            if (telefono != null) { _context.Telefonos.Remove(telefono); }
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
