using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;



public class ProductosPorFactura
{
    private int? cantidad;   
    private double? subtotal;

public ProductosPorFactura(int? cantidad=null,double? subtotal=null)
{
    Cantidad = cantidad;
    Subtotal = subtotal;
}

// get y set para Cantidad 
public int? Cantidad {get; set;}

// get y set para Subtotal
public double? Subtotal  {get; set;}











}