using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllPersonasAsync();
        Task<Persona> GetPersonaByIdAsync(int cc);
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task UpdatePersonaAsync(Persona persona);
        Task DeletePersonaAsync(int cc);
    }
}
