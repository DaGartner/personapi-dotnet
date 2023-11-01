using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetAll();
        Estudio GetById(int estudioID);
        void Insert(Estudio estudio);
        void Update(Estudio estudio);
        void Delete(int estudioID);
        void Save();
    }
}
