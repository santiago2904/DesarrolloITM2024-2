/*using TallerDesarrollo.config;
using TallerDesarrollo.models;

namespace TallerDesarrollo.services;

public class ProductosPorFacturaService
{
    private readonly AppDbContext _context;

    public ProductosPorFacturaService()
    {
        _context = new AppDbContext();
    }

    public void CreatePoductoPorFactura(int codigoFactura, int canidad, DateOnly fecha,
        double valorTotal, Producto producto)
    {
        var productoPorFactura =
            new ProductosPorFactura(producto.Codigo, codigoFactura, canidad, producto.Valorunitario * canidad);
    }
}*/