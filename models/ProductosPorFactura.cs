using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;

public class ProductosPorFactura
{
    public ProductosPorFactura( int productoId, int? cantidad = null, double? subtotal = null)
    {
        ProductoId = productoId;
        Cantidad = cantidad;
        Subtotal = subtotal;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Producto")] public int ProductoId { get; set; }

    public Producto? Producto { get; set; }

// get y set para Cantidad 
    public int? Cantidad { get; set; }

// get y set para Subtotal
    public double? Subtotal { get; set; }
}