namespace TEST.Repository.Cuenta
{
    public interface IRepositoryCuenta
    {
        void SetConfiguration(IConfiguration configuration);
        Task<bool> CrearCuenta(Models.Cuenta cuenta);
        Task<bool> ActualizarCuenta(Models.Cuenta cuenta);
        Task<bool> EliminarCuenta(int cuentaId);
        Task<Models.Cuenta> ObtenerCuenta(int cuentaId);
        Task<List<Models.Cuenta>> ObtenerCuentas();
    }
}
