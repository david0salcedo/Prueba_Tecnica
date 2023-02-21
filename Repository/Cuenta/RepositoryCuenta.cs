﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TEST.Repository.Cuenta
{
    public class RepositoryCuenta : IRepositoryCuenta
    {
        private IConfiguration _configuration;

        public void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ActualizarCuenta(Models.Cuenta Cuenta)
        {
            using (ContextDB context = new ContextDB(_configuration))
            {
                context.Cuentas.Update(Cuenta);

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

        public async Task<bool> CrearCuenta(Models.Cuenta Cuenta)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                await context.Cuentas.AddAsync(Cuenta);

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

        public async Task<bool> EliminarCuenta(int CuentaId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Cuenta CuentaEliminar = await context.Cuentas.FirstOrDefaultAsync(p => p.CuentaId == CuentaId);

                if (CuentaEliminar == null) { return true; }

                context.Cuentas.Remove(CuentaEliminar);

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

        public async Task<Models.Cuenta> ObtenerCuenta(int CuentaId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Cuenta Cuenta = await context.Cuentas.FirstOrDefaultAsync(p => p.CuentaId == CuentaId);

                if (Cuenta == null) { new Models.Cuenta(); }

                return Cuenta;
            }

        }

        public async Task<List<Models.Cuenta>> ObtenerCuentas()
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                List<Models.Cuenta> Cuentas = await context.Cuentas.ToListAsync();

                if (Cuentas == null) { return new List<Models.Cuenta>(); }

                return Cuentas;
            }

        }
    }
}
