using Microsoft.AspNetCore.Mvc;
using TEST.Models;
using TEST.Repository.Cuenta;

namespace TEST.Controllers
{
    [Route("cuentas")]
    public class CuentaController : Controller
    {
        private readonly IRepositoryCuenta _repositoryCuenta;

        public CuentaController(IRepositoryCuenta repositoryCuenta, IConfiguration configuration)
        {
            _repositoryCuenta = repositoryCuenta;
            _repositoryCuenta.SetConfiguration(configuration);
        }


        [HttpPost]
        public async Task<ActionResult> CrearCuenta([FromBody] Cuenta cuenta)
        {
            try
            {
                bool resultado = await _repositoryCuenta.CrearCuenta(cuenta);

                if (resultado)
                {
                    return Ok(cuenta);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception CrearCuenta", ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarCuenta([FromBody] Cuenta cuenta)
        {
            try
            {
                bool resultado = await _repositoryCuenta.ActualizarCuenta(cuenta);

                if (resultado)
                {
                    return Ok(cuenta);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ActualizarCuenta", ex);
            }
        }

        [HttpGet("{CuentaId:int}")]
        public async Task<ActionResult> ObtenerCuenta(int CuentaId)
        {
            try
            {
                Cuenta Cuenta = await _repositoryCuenta.ObtenerCuenta(CuentaId);

                return Ok(Cuenta);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerCuenta", ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerCuentas()
        {
            try
            {
                List<Cuenta> Cuentas = await _repositoryCuenta.ObtenerCuentas();

                return Ok(Cuentas);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ObtenerCuentas", ex);
            }
        }



        [HttpDelete("{CuentaId:int}")]
        public async Task<ActionResult> EliminarCuenta(int CuentaId)
        {
            try
            {

                bool resultado = await _repositoryCuenta.EliminarCuenta(CuentaId);


                if (resultado)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception EliminarCuenta", ex);
            }
        }
    }
}
