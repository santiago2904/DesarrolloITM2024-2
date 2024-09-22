using TallerDesarrollo.config;
using TallerDesarrollo.models;

namespace TallerDesarrollo.services;

public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService()
    {
        _context = new AppDbContext();
    }

    public void CreateCliente(string email, string nombre, string apellido, decimal credito, int empresaCodigo)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            
            var cliente = new Cliente
                { Email = email, Nombre = nombre, Apellido = apellido, Credito = credito, EmpresaCodigo = empresaCodigo};

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            Console.WriteLine("Cliente creado con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el cliente: {ex.Message}");
            Console.WriteLine($"Detalles: {ex.InnerException?.Message}");
        }
    }

    public List<Cliente> ReadClientes()
    {
        return _context.Clientes.ToList();
    }

    public void UpdateCliente(int codigo, string nuevoEmail, string nuevoNombre, string nuevoApellido,
        decimal nuevoCredito)
    {
        try
        {
            var cliente = _context.Clientes.Find(codigo);
            if (cliente != null)
            {
                cliente.Email = nuevoEmail;
                cliente.Nombre = nuevoNombre;
                cliente.Apellido = nuevoApellido;
                cliente.Credito = nuevoCredito;
                _context.SaveChanges();
                Console.WriteLine("Cliente actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el cliente: {ex.Message}");
        }
    }

    public void DeleteCliente(int codigo)
    {
        try
        {
            var cliente = _context.Clientes.Find(codigo);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                Console.WriteLine("Cliente eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el cliente: {ex.Message}");
        }
    }
}