using TallerDesarrollo.config;
using TallerDesarrollo.models;

public class ProductoService
{
    private readonly AppDbContext _context;

    public ProductoService()
    {
        _context = new AppDbContext();
    }

    public void CreateProducto(string nombre, int stock, double valorunitario)
    {
        try
        {
            // Cambiar Find por LINQ para buscar por nombre
            var findProducto = _context.Productos
                .FirstOrDefault(p => p.Nombre == nombre);

            if (findProducto != null)
            {
                Console.WriteLine("El Producto ya existe.");
                return;
            }

            var producto = new Producto { Nombre = nombre, Stock = stock, Valorunitario = valorunitario };
            _context.Productos.Add(producto);
            _context.SaveChanges();
            Console.WriteLine("El producto fue creado con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el producto: {ex.Message}");
        }
    }

    public List<Producto> ReadProductos()
    {
        return _context.Productos.ToList();
    }

    public void UpdateProducto(int codigo, string nuevoNombre, int nuevoStock, double nuevoValorunitario)
    {
        try
        {
            var producto = _context.Productos.Find(codigo);
            if (producto != null)
            {
                producto.Nombre = nuevoNombre;
                producto.Stock = nuevoStock;
                producto.Valorunitario = nuevoValorunitario;

                _context.SaveChanges();
                Console.WriteLine("El producto fue actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no fue encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
        }
    }

    public void DeleteProducto(int codigo)
    {
        try
        {
            var producto = _context.Productos.Find(codigo);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                Console.WriteLine("El producto fue eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no fue encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
        }
    }
}