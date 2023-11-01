using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllProfesionesAsync();
        Task<Profesion> GetProfesionByIdAsync(int id);
        Task<Profesion> CreateProfesionAsync(Profesion profesion);
        Task UpdateProfesionAsync(Profesion profesion);
        Task DeleteProfesionAsync(int id);
    }
}
