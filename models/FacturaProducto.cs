using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models
{
    public class FacturaProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }
        public double Subtotal { get; set; }

        public FacturaProducto(int facturaId, int productoId, int cantidad, double subtotal)
        {
            FacturaId = facturaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
    }
}