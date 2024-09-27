using TallerDesarrollo.models;
using TallerDesarrollo.config;
using Microsoft.EntityFrameworkCore;

namespace TallerDesarrollo.services;

public class FacturaService
{
    private readonly AppDbContext _context;

    public FacturaService()
    {
        _context = new AppDbContext();
    }

    // Crear una nueva factura con productos
    public void CrearFactura(DateTime? fecha, int personaId, List<(int productoId, int cantidad)> productos)
    {
        try
        {
            var factura = new Factura
            {
                Fecha = fecha,
                PersonaId = personaId,
                FacturaProductos = new List<FacturaProducto>()
            };

            double total = 0;

            // Añadir productos a la factura
            foreach (var (productoId, cantidad) in productos)
            {
                var producto = _context.Productos.Find(productoId);
                if (producto != null && producto.Stock >= cantidad)
                {
                    var subtotal = producto.Valorunitario * cantidad;
                    total += subtotal.Value; // Calcular el total sumando los subtotales

                    var facturaProducto = new FacturaProducto(facturaId: factura.Codigo, productoId: producto.Codigo,
                        cantidad: cantidad, subtotal: subtotal.Value);

                    // Disminuir el stock del producto
                    producto.Stock -= cantidad;

                    factura.FacturaProductos.Add(facturaProducto);
                }
                else
                {
                    Console.WriteLine($"El producto con ID {productoId} no tiene suficiente stock o no existe.");
                }
            }

            // Asignar el total calculado a la factura
            factura.Total = total;

            _context.Facturas.Add(factura);
            _context.SaveChanges();
            Console.WriteLine("Factura creada exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la factura: {ex.Message}");
        }
    }

    // Actualizar una factura (modificar productos)
    public void ActualizarFactura(int facturaId, List<(int productoId, int cantidad)> nuevosProductos)
    {
        try
        {
            var factura = _context.Facturas
                .Include(f => f.FacturaProductos)
                .FirstOrDefault(f => f.Codigo == facturaId);

            if (factura != null)
            {
                // Limpiar productos actuales de la factura
                factura.FacturaProductos.Clear();

                double total = 0;

                // Añadir nuevos productos
                foreach (var (productoId, cantidad) in nuevosProductos)
                {
                    var producto = _context.Productos.Find(productoId);
                    if (producto != null && producto.Stock >= cantidad)
                    {
                        var subtotal = producto.Valorunitario * cantidad;
                        total += subtotal.Value; // Calcular el nuevo total sumando los subtotales

                        var facturaProducto = new FacturaProducto(facturaId: factura.Codigo,
                            productoId: producto.Codigo, cantidad: cantidad, subtotal: subtotal.Value);

                        producto.Stock -= cantidad;
                        factura.FacturaProductos.Add(facturaProducto);
                    }
                    else
                    {
                        Console.WriteLine($"El producto con ID {productoId} no tiene suficiente stock o no existe.");
                    }
                }

                // Asignar el nuevo total calculado
                factura.Total = total;

                _context.SaveChanges();
                Console.WriteLine("Factura actualizada exitosamente.");
            }
            else
            {
                Console.WriteLine("Factura no encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar la factura: {ex.Message}");
        }
    }

    // Leer todas las facturas
    public List<Factura> LeerFacturas()
    {
        return _context.Facturas
            .Include(f => f.FacturaProductos)
            .ThenInclude(fp => fp.Producto)
            .Include(f => f.Persona)
            .ToList();
    }

    // Leer una factura por ID
    public Factura? LeerFacturaPorId(int codigo)
    {
        return _context.Facturas
            .Include(f => f.FacturaProductos)
            .ThenInclude(fp => fp.Producto)
            .Include(f => f.Persona)
            .FirstOrDefault(f => f.Codigo == codigo);
    }

    // Actualizar una factura (modificar total o productos)


    // Eliminar una factura
    public void EliminarFactura(int codigo)
    {
        try
        {
            var factura = _context.Facturas
                .Include(f => f.FacturaProductos)
                .FirstOrDefault(f => f.Codigo == codigo);

            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
                Console.WriteLine("Factura eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("Factura no encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar la factura: {ex.Message}");
        }
    }
}