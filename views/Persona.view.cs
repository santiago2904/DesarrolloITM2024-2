using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

public class PersonaView
{
    private readonly PersonaService _personaService;

    public PersonaView()
    {
        _personaService = new PersonaService();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Personas");
            Console.WriteLine("1. Crear Persona");
            Console.WriteLine("2. Listar Personas");
            Console.WriteLine("3. Actualizar Persona");
            Console.WriteLine("4. Eliminar Persona");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese el email de la persona:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre de la persona:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido de la persona:");
                    string apellido = Console.ReadLine();
                    _personaService.CreatePersona(email, nombre, apellido);
                    break;
                case "2":
                    var personas = _personaService.ReadPersonas();
                    Console.WriteLine("Listado de Personas:");
                    foreach (var persona in personas)
                    {
                        Console.WriteLine(_personaService.GetInfoPersona(persona));
                    }

                    break;
                case "3":
                    Console.WriteLine("Ingrese el código de la persona a actualizar:");
                    int codigo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo email de la persona:");
                    string nuevoEmail = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo nombre de la persona:");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo apellido de la persona:");
                    string nuevoApellido = Console.ReadLine();
                    _personaService.UpdatePersona(codigo, nuevoEmail, nuevoNombre, nuevoApellido);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el código de la persona a eliminar:");
                    int codigoEliminar = int.Parse(Console.ReadLine());
                    _personaService.DeletePersona(codigoEliminar);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}