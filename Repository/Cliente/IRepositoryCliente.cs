namespace TEST.Repository.Cliente
{
    public interface IRepositoryCliente
    {
        void SetConfiguration(IConfiguration configuration);
        Task<bool> CrearCliente(Models.Cliente cliente);
        Task<bool> ActualizarCliente(Models.Cliente cliente);
        Task<bool> EliminarCliente(int clienteId);
        Task<Models.Cliente> ObtenerCliente(int clienteId);
        Task<List<Models.Cliente>>  ObtenerClientes();
    }
}
