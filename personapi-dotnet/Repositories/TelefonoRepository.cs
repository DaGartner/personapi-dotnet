using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllTelefonosAsync()
        {
            return await _context.Telefonos.ToListAsync();
        }

        public async Task<Telefono> GetTelefonoByNumAsync(string num)
        {
            return await _context.Telefonos.FindAsync(num);
        }

        public async Task<Telefono> CreateTelefonoAsync(Telefono telefono)
        {
            await _context.Telefonos.AddAsync(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Entry(telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelefonoAsync(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }
    }
}
