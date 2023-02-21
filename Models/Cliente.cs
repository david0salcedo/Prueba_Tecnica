using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }

        public int? PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        public int? CuentaId { get; set; }
        public virtual Cuenta Cuenta { get; set; }
    }
}
