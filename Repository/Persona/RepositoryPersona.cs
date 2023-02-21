using Microsoft.EntityFrameworkCore;
using TEST.Models;

namespace TEST.Repository.Persona
{
    public class RepositoryPersona : IRepositoryPersona
    {
        private  IConfiguration _configuration;

        public void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ActualizarPersona(Models.Persona persona)
        {
                using (ContextDB context = new ContextDB(_configuration))
                {
                    context.Personas.Update(persona);

                    int result = await context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
        }

        public async Task<bool> CrearPersona(Models.Persona persona)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                await context.Personas.AddAsync(persona);

                    int result = await context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

        }

        public async Task<bool> EliminarPersona(int personaId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Persona personaEliminar = await context.Personas.FirstOrDefaultAsync(p => p.PersonaId == personaId);
                   
                    if (personaEliminar == null) { return true; }

                    context.Personas.Remove(personaEliminar);

                    int result = await context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
        }

        public async Task<Models.Persona> ObtenerPersona(int personaId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Persona persona = await context.Personas.FirstOrDefaultAsync(p => p.PersonaId == personaId);

                    if (persona == null) { new Models.Persona(); }

                    return persona;
                }

        }

        public async Task<List<Models.Persona>> ObtenerPersonas()
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                List<Models.Persona> personas = await context.Personas.ToListAsync();

                if (personas == null) { return new List<Models.Persona>(); }

                return personas;
            }

        }


    }
}
