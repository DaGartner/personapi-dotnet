using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetPersonaByIdAsync(int id)
        {
            return await _context.Personas.Include(p => p.Telefonos).FirstOrDefaultAsync(p => p.Cc == id);
        }


        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task UpdatePersonaAsync(Persona persona)
        {
            var existingEntity = _context.Personas.Local.FirstOrDefault(p => p.Cc == persona.Cc);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        public async Task DeletePersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}
