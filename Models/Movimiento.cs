using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.Models
{
    public enum TipoMovimiento
    {
        Ahorro, Corriente
    }

    public class Movimiento
    {
        [Key]
        public int MovimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }

        public int? CuentaId { get; set; }
        [NotMapped]
        public virtual Cuenta Cuenta { get; set; }

    }
}
