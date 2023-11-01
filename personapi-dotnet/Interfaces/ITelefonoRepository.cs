using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllTelefonosAsync();
        Task<Telefono> GetTelefonoByNumAsync(string num);
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Task UpdateTelefonoAsync(Telefono telefono);
        Task DeleteTelefonoAsync(string num);
    }
}
