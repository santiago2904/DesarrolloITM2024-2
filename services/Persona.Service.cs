using TallerDesarrollo.config;
using TallerDesarrollo.models;

namespace TallerDesarrollo.services;

public class PersonaService : IPersona
{
    private readonly AppDbContext _context;

    public PersonaService()
    {
        _context = new AppDbContext();
    }

    public void CreatePersona(string email, string nombre, string apellido)
    {
        try
        {
            var persona = new Persona { Email = email, Nombre = nombre, Apellido = apellido };
            _context.Personas.Add(persona);
            _context.SaveChanges();
            Console.WriteLine("Persona creada con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la persona: {ex.Message}");
        }
    }

    public List<Persona> ReadPersonas()
    {
        return _context.Personas.ToList();
    }

    public void UpdatePersona(int codigo, string nuevoEmail, string nuevoNombre, string nuevoApellido)
    {
        try
        {
            var persona = _context.Personas.Find(codigo);
            if (persona != null)
            {
                persona.Email = nuevoEmail;
                persona.Nombre = nuevoNombre;
                persona.Apellido = nuevoApellido;
                _context.SaveChanges();
                Console.WriteLine("Persona actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("Persona no encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar la persona: {ex.Message}");
        }
    }

    public void DeletePersona(int codigo)
    {
        try
        {
            var persona = _context.Personas.Find(codigo);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
                Console.WriteLine("Persona eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("Persona no encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar la persona: {ex.Message}");
        }
    }

    public string GetInfoPersona(Persona persona)
    {
        return $"Codigo:{persona.Codigo}  Nombre: {persona.Nombre} {persona.Apellido}, Email: {persona.Email}";
    }
}