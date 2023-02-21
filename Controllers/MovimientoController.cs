using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TEST.Models;
using TEST.Repository.Movimiento;
using TEST.Repository.Movimiento;
using TEST.Services.LoggerManager;

namespace TEST.Controllers
{
    [Route("api/movimientos")]
    public class MovimientoController : Controller
    {
        private readonly IRepositoryMovimiento _repositoryMovimiento;

        public MovimientoController(IRepositoryMovimiento repositoryMovimiento, IConfiguration configuration)
        {
            _repositoryMovimiento = repositoryMovimiento;
            _repositoryMovimiento.SetConfiguration(configuration);

        }


        [HttpPost]
        public async Task<ActionResult> CrearMovimiento([FromBody] Movimiento Movimiento)
        {
            try
            {
                bool resultado = await _repositoryMovimiento.CrearMovimiento(Movimiento);

                if (resultado)
                {
                    return Ok(Movimiento);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception CrearMovimiento", ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarMovimiento([FromBody] Movimiento Movimiento)
        {
            try
            {
                bool resultado = await _repositoryMovimiento.ActualizarMovimiento(Movimiento);

                if (resultado)
                {
                    return Ok(Movimiento);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception CrearMovimiento", ex);
            }
        }

        [HttpGet("{MovimientoId:int}")]
        public async Task<ActionResult> ActualizarMovimiento(int MovimientoId)
        {
            try
            {
                Movimiento Movimiento = await _repositoryMovimiento.ObtenerMovimiento(MovimientoId);

                return Ok(Movimiento);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ActualizarMovimiento", ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerMovimientos()
        {
            try
            {
                List<Movimiento> Movimientos = await _repositoryMovimiento.ObtenerMovimientos();

                return Ok(Movimientos);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerMovimientos", ex);
            }
        }


        [HttpDelete("{MovimientoId:int}")]
        public async Task<ActionResult> EliminarMovimiento(int MovimientoId)
        {
            try
            {

                bool resultado = await _repositoryMovimiento.EliminarMovimiento(MovimientoId);


                if (resultado)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception EliminarMovimiento", ex);
            }
        }
    }
}
