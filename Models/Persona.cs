using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.Models
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public Genero Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        [NotMapped]
        public virtual Cliente Cliente { get; set; }
    }

    public enum Genero
    {
        M, F
    }
}
