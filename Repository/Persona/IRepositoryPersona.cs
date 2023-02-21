

namespace TEST.Repository.Persona
{
    public interface IRepositoryPersona
    {
        void SetConfiguration(IConfiguration configuration);
        Task<bool> CrearPersona(Models.Persona persona);
        Task<bool> ActualizarPersona(Models.Persona persona);
        Task<bool> EliminarPersona(int personaId);
        Task<Models.Persona> ObtenerPersona(int personaId);
        Task<List<Models.Persona>> ObtenerPersonas();


    }
}
