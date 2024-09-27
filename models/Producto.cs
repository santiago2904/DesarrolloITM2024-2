using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;

public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

    public string? Nombre { get; set; }

    public int? Stock { get; set; }

    public double? Valorunitario { get; set; }

    public Producto(string? nombre = null, int? stock = null, double? valorunitario = null)
    {
        Nombre = nombre;
        Stock = stock;
        Valorunitario = valorunitario;
    }
}