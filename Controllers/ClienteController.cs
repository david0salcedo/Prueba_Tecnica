using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TEST.Models;
using TEST.Repository.Cliente;

namespace TEST.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ClienteController(IRepositoryCliente repositoryCliente, IConfiguration configuration)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryCliente.SetConfiguration(configuration);

        }


        [HttpPost]
        public async Task<ActionResult> CrearCliente([FromBody] Cliente cliente)
        {
            try
            {
                bool resultado = await _repositoryCliente.CrearCliente(cliente);

                if (resultado)
                {
                    return Ok(cliente);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception CrearCliente", ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarCliente([FromBody] Cliente cliente)
        {
            try
            {
                bool resultado = await _repositoryCliente.ActualizarCliente(cliente);

                if (resultado)
                {
                    return Ok(cliente);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ActualizarCliente", ex);
            }
        }

        [HttpGet("{ClienteId:int}")]
        public async Task<ActionResult> ObtenerCliente(int ClienteId)
        {
            try
            {
                Cliente cliente = await _repositoryCliente.ObtenerCliente(ClienteId);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerCliente", ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerPersonas()
        {
            try
            {
                List<Cliente> clientes = await _repositoryCliente.ObtenerClientes();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerPersonas", ex);
            }
        }


        [HttpDelete("{ClienteId:int}")]
        public async Task<ActionResult> EliminarCliente(int ClienteId)
        {
            try
            {

                bool resultado = await _repositoryCliente.EliminarCliente(ClienteId);


                if (resultado)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception EliminarCliente", ex);
            }
        }
    }
}
