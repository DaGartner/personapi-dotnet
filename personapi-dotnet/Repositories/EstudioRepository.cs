using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private readonly PersonaDbContext _context;

        public EstudiosRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetAllEstudiosAsync()
        {
            return await _context.Estudios.ToListAsync();
        }

        public async Task<Estudio> GetEstudiosByIdAsync(int idProf, int ccPer)
        {
            return await _context.Estudios.FindAsync(idProf, ccPer);
        }

        public async Task<Estudio> CreateEstudiosAsync(Estudio estudio)
        {
            await _context.Estudios.AddAsync(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task UpdateEstudiosAsync(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudiosAsync(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
