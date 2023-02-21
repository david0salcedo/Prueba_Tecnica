using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TEST.Models;
using TEST.Repository.Persona;
using TEST.Services.LoggerManager;

namespace TEST.Controllers
{
    [Route("api/personas")]
    public class PersonaController : Controller
    {
        private readonly IRepositoryPersona _repositoryPersona;

        public PersonaController(IRepositoryPersona repositoryPersona, IConfiguration configuration)
        {
            _repositoryPersona= repositoryPersona;
            _repositoryPersona.SetConfiguration(configuration);
        }


        [HttpPost]
        public async Task<ActionResult> CrearPersona([FromBody] Persona persona)
        {
            try
            {
                bool resultado = await _repositoryPersona.CrearPersona(persona);

                if(resultado)
                {
                    return Ok(persona);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception CrearPersona", ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarPersona([FromBody] Persona persona)
        {
            try
            {
                bool resultado = await _repositoryPersona.ActualizarPersona(persona);

                if (resultado)
                {
                    return Ok(persona);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ActualizarPersona", ex);
            }
        }

        [HttpGet("{PersonaId:int}")] 
        public async Task<ActionResult> ObtenerPersona(int PersonaId)
        {
            try
            {

                Persona persona = await _repositoryPersona.ObtenerPersona(PersonaId);

                return Ok(persona);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerPersona" , ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerPersonas()
        {
            try
            {
                List<Persona> personas = await _repositoryPersona.ObtenerPersonas();

                return Ok(personas);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerPersonas", ex);
            }
        }


        [HttpDelete("{PersonaId:int}")]
        public async Task<ActionResult> EliminarPersona(int PersonaId)
        {
            try
            {

                bool resultado = await _repositoryPersona.EliminarPersona(PersonaId);


                if (resultado)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerPersona", ex);
            }
        }

    }
}
