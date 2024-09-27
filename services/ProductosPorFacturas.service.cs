using TallerDesarrollo.config;
using TallerDesarrollo.models;

namespace TallerDesarrollo.services;

public class ProductosPorFacturaService
{
    private readonly AppDbContext _context;

    public ProductosPorFacturaService()
    {
        _context = new AppDbContext();
    }

    public void CreateProductoPorFactura(int codigoFactura, int cantidad, DateOnly fecha,
        double valorTotal, Producto producto)
    {
        try
        {   
            var findProductoPorFactura = _context.productosPorFactura.Find(codigoFactura);
                
                if (findProductoPorFactura != null)
                {
                    Console.WriteLine("La Factura ya existe.");
                    return;
                }
                var productoPorFactura =new ProductoPorFactura(producto.Codigo, codigoFactura, cantidad, producto.Valorunitario * cantidad);
                context.ProductosPorFactura.Add(productoPorFactura);
                _context.SaveChanges();
                Console.WriteLine("la factura se ha creado con exito");
        }
        catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la factura: {ex.Message}");
            }
     }

    public List<ProductoPorFactura> ReadProductosPorFactura()
    {
        return _context.ProductosPorFactura.ToList();
    }

public void UpdateProductoPorFactura(int codigoFactura, int nuevaCantidad, double nuevoValortotal,Producto producto)
    {
        try
        {
            var ProductoPorFactura = _context.ProductosPorFactura.Find(codigoFactura);
            if (ProductoPorFactura != null)
            {
                ProductoPorFactura.cantidad = nuevaCantidad;
                ProductoPorFactura.valorTotal = nuevoValortotal;
                ProductoPorFactura.producto = producto;
                _context.SaveChanges();
                Console.WriteLine("La factura  fue actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("La Factura no fue encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar la factura: {ex.Message}");
        }
    }

    
 public void DeleteProductoPorFactura(int codigoFactura)
    {
        try
        {
            var productoPorFactura = _context.ProductosPorFactura.Find(codigoFactura);
            if (productoPorFactura != null)
            {
                _context.ProductosPorFactura.Remove(productoPorFactura);
                _context.SaveChanges();
                Console.WriteLine("La Factura fue eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("La factura no fue encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar la factura: {ex.Message}");
        }
    }

}