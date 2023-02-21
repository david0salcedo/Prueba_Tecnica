using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TEST.Repository.Cliente
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private IConfiguration _configuration;

        public void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ActualizarCliente(Models.Cliente Cliente)
        {
            using (ContextDB context = new ContextDB(_configuration))
            {
                context.Clientes.Update(Cliente);

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

        public async Task<bool> CrearCliente(Models.Cliente Cliente)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                await context.Clientes.AddAsync(Cliente);

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

        public async Task<bool> EliminarCliente(int ClienteId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Cliente ClienteEliminar = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(p => p.ClienteId == ClienteId);

                if (ClienteEliminar == null) { return true; }

                context.Clientes.Remove(ClienteEliminar);

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

        public async Task<Models.Cliente> ObtenerCliente(int ClienteId)
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                Models.Cliente Cliente = await context.Clientes.Include(p => p.Persona).Include(c => c.Cuenta).AsNoTracking().FirstOrDefaultAsync(p => p.ClienteId == ClienteId);

                if (Cliente == null) { new Models.Cliente(); }

                return Cliente;
            }

        }

        public async Task<List<Models.Cliente>> ObtenerClientes()
        {

            using (ContextDB context = new ContextDB(_configuration))
            {
                List<Models.Cliente> Clientes = await context.Clientes.Include(p => p.Persona).Include(c => c.Cuenta).AsNoTracking().ToListAsync();

                if (Clientes == null) { return new List<Models.Cliente>(); }

                return Clientes;
            }

        }
    }
}
