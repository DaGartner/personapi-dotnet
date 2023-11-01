using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int personaID);
        void Insert(Persona persona);
        void Update(Persona persona);
        void Delete(int PersonaID);
        void Save();
    }
}
