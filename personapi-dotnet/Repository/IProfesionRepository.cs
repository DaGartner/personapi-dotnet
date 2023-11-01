using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public interface IProfesionRepository
    {
        IEnumerable<Profesion> GetAll();
        Profesion GetById(int profesionID);
        void Insert(Profesion profesion);
        void Update(Profesion profesion);
        void Delete(int profesionID);
        void Save();
    }
}
