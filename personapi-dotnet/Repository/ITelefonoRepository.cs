using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public interface ITelefonoRepository
    {
        IEnumerable<Telefono> GetAll();
        Telefono GetById(int telefonoID);
        void Insert(Telefono telefono);
        void Update(Telefono telefono);
        void Delete(int telefonoID);
        void Save();
    }
}
