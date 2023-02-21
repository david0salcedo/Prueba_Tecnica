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
                Models.Movimiento MovimientoEliminar = await context.Movimientos.FirstOrDefaultAsync(p => p.MovimientoId == MovimientoId);

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
                Models.Movimiento Movimiento = await context.Movimientos.FirstOrDefaultAsync(p => p.MovimientoId == MovimientoId);

                if (Movimiento == null) { new Models.Movimiento(); }

                return Movimiento;
            }

        }

        public async Task<List<Models.Movimiento>> ObtenerMovimientos()
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                List<Models.Movimiento> Movimientos = await context.Movimientos.ToListAsync();

                if (Movimientos == null) { return new List<Models.Movimiento>(); }

                return Movimientos;
            }

        }
    }
}
