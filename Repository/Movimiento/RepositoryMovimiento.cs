using Microsoft.EntityFrameworkCore;

namespace TEST.Repository.Movimiento
{
    public class RepositoryMovimiento : IRepositoryMovimiento
    {
        private IConfiguration _configuration;

        public void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ActualizarMovimiento(Models.Movimiento Movimiento)
        {
            using (ContextDB context = new ContextDB(_configuration))
            {
                context.Movimientos.Update(Movimiento);

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

        public async Task<bool> CrearMovimiento(Models.Movimiento Movimiento)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                await context.Movimientos.AddAsync(Movimiento);

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

        public async Task<bool> EliminarMovimiento(int MovimientoId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Movimiento MovimientoEliminar = await context.Movimientos.AsNoTracking().FirstOrDefaultAsync(p => p.MovimientoId == MovimientoId);

                if (MovimientoEliminar == null) { return true; }

                context.Movimientos.Remove(MovimientoEliminar);

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

        public async Task<Models.Movimiento> ObtenerMovimiento(int MovimientoId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Movimiento Movimiento = await context.Movimientos.AsNoTracking().FirstOrDefaultAsync(p => p.MovimientoId == MovimientoId);

                if (Movimiento == null) { new Models.Movimiento(); }

                 Movimiento.Cuenta = await context.Cuentas.AsNoTracking().FirstOrDefaultAsync(p => p.CuentaId == Movimiento.CuentaId);

                return Movimiento;
            }

        }

        public async Task<List<Models.Movimiento>> ObtenerMovimientos()
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                List<Models.Movimiento> Movimientos = await context.Movimientos.AsNoTracking().ToListAsync();

                if (Movimientos == null) { return new List<Models.Movimiento>(); }

                foreach (var item in Movimientos)
                {
                    item.Cuenta = await context.Cuentas.AsNoTracking().FirstOrDefaultAsync(p => p.CuentaId == item.CuentaId);

                }

                return Movimientos;
            }

        }

        public async Task<List<Models.Movimiento>> ReproteMovimientos(DateTime fechaInicio, DateTime fechaFinal)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                List<Models.Movimiento> Movimientos = await context.Movimientos.AsNoTracking().Where(m => m.Fecha >= fechaInicio && m.Fecha <= fechaFinal).ToListAsync();

                if (Movimientos == null) { return new List<Models.Movimiento>(); }

                foreach (var item in Movimientos)
                {
                    item.Cuenta = await context.Cuentas.AsNoTracking().FirstOrDefaultAsync(p => p.CuentaId == item.CuentaId);

                }

                return Movimientos;
            }

        }

    }
}
