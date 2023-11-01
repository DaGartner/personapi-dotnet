using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class EstudioRepository:IEstudioRepository
    {
        private readonly PersonaDbContext _context;
        public EstudioRepository(){_context = new PersonaDbContext();}
        public EstudioRepository(PersonaDbContext context) { _context = context; }
        public IEnumerable<Estudio> GetAll(){return _context.Estudios.ToList();}
        public Estudio GetById(int EstudioID){return _context.Estudios.Find(EstudioID);}
        public void Insert(Estudio estudio){_context.Estudios.Add(estudio);}
        public void Update(Estudio estudio){_context.Entry(estudio).State = EntityState.Modified;}
        public void Delete(int EstudioID)
        {
            Estudio estudio = _context.Estudios.Find(EstudioID);
            if (estudio != null){_context.Estudios.Remove(estudio);}
        }
        public void Save(){_context.SaveChanges();}
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed){if (disposing){_context.Dispose();}}
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
