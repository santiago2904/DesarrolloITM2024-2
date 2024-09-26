using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;


public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

 private string? nombreproducto;
 private int? stock;
 private double? valorunitario;


    public Producto( string? nombre= null, int? stock=null, double? valorunitario=null)
 {
      Nombre = nombre;
      Stock = stock;
      Valorunitario= valorunitario;
 }
//gey set para nombre
 public string? Nombre {get; set;}

 // get y set para stock

 public int? Stock {get; set;}

// get y set para valorunitario

public double? Valorunitario {get; set;}


}



