using TallerDesarrollo.models;
using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

public class ClienteView
{
    private readonly ClienteService _clienteService;
    private readonly EmpresaService _empresaService;

    public ClienteView()
    {
        _clienteService = new ClienteService();
        _empresaService = new EmpresaService();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Clientes");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Actualizar Cliente");
            Console.WriteLine("4. Eliminar Cliente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese el email del cliente:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido del cliente:");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el crédito del cliente:");
                    decimal credito = decimal.Parse(Console.ReadLine());

                    // Supongamos que ya tienes una empresa creada y obtienes su referencia.
                    // Aquí solo para ilustrar, puedes modificarlo según tu implementación.
                    Console.WriteLine("Ingrese el código de la empresa asociada:");
                    int codigoEmpresa = int.Parse(Console.ReadLine());
                    Empresa empresa = _empresaService.ReadEmpresas().FirstOrDefault(e => e.Codigo == codigoEmpresa);

                    if (empresa != null)
                    {
                        _clienteService.CreateCliente(email, nombre, apellido, credito, codigoEmpresa);
                    }
                    else
                    {
                        Console.WriteLine("Empresa no encontrada.");
                    }

                    break;
                case "2":
                    var clientes = _clienteService.ReadClientes();
                    Console.WriteLine("Listado de Clientes:");
                    foreach (var cliente in clientes)
                    {
                        var empresaCliente = _empresaService.ReadEmpresas().FirstOrDefault(e => e.Codigo == cliente.EmpresaCodigo);
                        Console.WriteLine(
                            $"Código: {cliente.Codigo}, " +
                            $"Email: {cliente.Email}," +
                            $" Nombre: {cliente.Nombre}, " +
                            $"Apellido: {cliente.Apellido}," +
                            $" Crédito: {cliente.Credito}," +
                            $" Empresa: {empresaCliente?.Nombre}");
                    }

                    break;
                case "3":
                    Console.WriteLine("Ingrese el código del cliente a actualizar:");
                    int codigoCliente = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo email del cliente:");
                    string nuevoEmail = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo nombre del cliente:");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo apellido del cliente:");
                    string nuevoApellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo crédito del cliente:");
                    decimal nuevoCredito = decimal.Parse(Console.ReadLine());
                    _clienteService.UpdateCliente(codigoCliente, nuevoEmail, nuevoNombre, nuevoApellido, nuevoCredito);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el código del cliente a eliminar:");
                    int codigoEliminarCliente = int.Parse(Console.ReadLine());
                    _clienteService.DeleteCliente(codigoEliminarCliente);
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