using TallerDesarrollo.config;
using TallerDesarrollo.views;

class Program
{
    static AppDbContext _context;

    static void Main(string[] args)
    {
        try
        {
            _context = new AppDbContext();

            if (_context.Database.CanConnect())
            {
                Console.WriteLine("Conexión a la base de datos exitosa.");
                ShowMainMenu();
            }
            else
            {
                Console.WriteLine("Error al conectar con la base de datos.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de conexión: {ex.Message}");
        }
    }

    static void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nSeleccione un CRUD:");
            Console.WriteLine("1. Empresas");
            Console.WriteLine("2. Personas");
            Console.WriteLine("3. Clientes");
            Console.WriteLine("4. Vendedores");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var empresaView = new EmpresaView();
                    empresaView.ShowMenu();
                    break;
                case "2":
                    var personaView = new PersonaView();
                    personaView.ShowMenu();
                    break;
                case "3":
                    var clienteView = new ClienteView();
                    clienteView.ShowMenu();
                    break;
                case "4":
                    //var VendedorView = new VendedorView();
                    //VendedorView.ShowMenu();
                    break;    
                case "5":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}