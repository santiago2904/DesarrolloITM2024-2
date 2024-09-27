using TallerDesarrollo.config;
using TallerDesarrollo.models;

namespace TallerDesarrollo.services;

public class VendedorService
{
    private readonly AppDbContext _context;

    public VendedorService()
    {
        _context = new AppDbContext();
    }

    public void CreateVendedor(string email, string nombre, string apellido, string direccion, string carne)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            
            var vendedor = new Vendedor
                { Email = email, Nombre = nombre, Apellido = apellido, Direccion = direccion, Carne = carne};

            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            Console.WriteLine("Vendedor creado con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el Vendedor: {ex.Message}");
            Console.WriteLine($"Detalles: {ex.InnerException?.Message}");
        }
    }

    public List<Vendedor> ReadVendedores()
    {
        return _context.Vendedores.ToList();
    }

    public void UpdateVendedor(int codigo, string nuevoEmail, string nuevoNombre, string nuevoApellido, string nuevoDireccion, string nuevoCarne
        )
    {
        try
        {
            var vendedor = _context.Vendedores.Find(codigo);
            if (vendedor != null)
            {
                vendedor.Email = nuevoEmail;
                vendedor.Nombre = nuevoNombre;
                vendedor.Apellido = nuevoApellido;
                vendedor.Direccion = nuevoDireccion;
                vendedor.Carne = nuevoCarne;
                _context.SaveChanges();
                Console.WriteLine("Vendedor actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Vendedor no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el Vendedor: {ex.Message}");
        }
    }

    public void DeleteVendedor(int codigo)
    {
        try
        {
            var vendedor = _context.Vendedores.Find(codigo);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                _context.SaveChanges();
                Console.WriteLine("Vendedor eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Vendedor no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el cliente: {ex.Message}");
        }
    }
}