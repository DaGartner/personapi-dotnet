using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IEstudiosRepository
    {
        Task<IEnumerable<Estudio>> GetAllEstudiosAsync();
        Task<Estudio> GetEstudiosByIdAsync(int idProf, int ccPer);
        Task<Estudio> CreateEstudiosAsync(Estudio estudio);
        Task UpdateEstudiosAsync(Estudio estudio);
        Task DeleteEstudiosAsync(int idProf, int ccPer);
    }
}
