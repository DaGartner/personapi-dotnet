using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllProfesionesAsync()
        {
            return await _context.Profesions.ToListAsync();
        }

        public async Task<Profesion> GetProfesionByIdAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                // Opción 1: Devolver null si la profesión no se encuentra
                return null;
            }
            return profesion;
        }


        public async Task<Profesion> CreateProfesionAsync(Profesion profesion)
        {
            await _context.Profesions.AddAsync(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task UpdateProfesionAsync(Profesion profesion)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesionAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
