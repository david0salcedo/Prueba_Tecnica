using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.Models
{
    public enum TipoCuenta
    {
        Ahorro, Corriente
    }

    public class Cuenta
    {
        [Key]
        public int CuentaId { get; set; }
        public int NumeroCuenta { get; set; }
        public TipoCuenta? TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }

        [NotMapped]
        public virtual Cliente Cliente { get; set; }

        public virtual List<Movimiento> Movimientos { get; set; }
    }
}
