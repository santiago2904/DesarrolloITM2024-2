using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        public double? Total { get; set; }

        public DateTime? Fecha { get; set; }

        public int? PersonaId { get; set; }
        public Persona? Persona { get; set; }

        public List<FacturaProducto>? FacturaProductos { get; set; }

        public Factura()
        {
            FacturaProductos = new List<FacturaProducto>();
        }

        public Factura(double? total = null, DateTime? fecha = null, int? personaId = null)
        {
            Total = total;
            Fecha = fecha;
            PersonaId = personaId;
            FacturaProductos = new List<FacturaProducto>();
        }
    }
}