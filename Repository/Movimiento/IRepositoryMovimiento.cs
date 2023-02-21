namespace TEST.Repository.Movimiento
{
    public interface IRepositoryMovimiento
    {
        void SetConfiguration(IConfiguration configuration);
        Task<bool> CrearMovimiento(Models.Movimiento movimiento);
        Task<bool> ActualizarMovimiento(Models.Movimiento movimiento);
        Task<bool> EliminarMovimiento(int movimientoId);
        Task<Models.Movimiento> ObtenerMovimiento(int movimientoId);
        Task<List<Models.Movimiento>> ObtenerMovimientos();

        Task<List<Models.Movimiento>> ReproteMovimientos(DateTime fechaInicio, DateTime fechaFinal);

    }
}
