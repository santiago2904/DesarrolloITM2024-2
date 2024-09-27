using TallerDesarrollo.models;
using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

public class VendedorView
{
    private readonly VendedorService _vendedorService;

    public VendedorView()
    {
        _vendedorService = new VendedorService();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Vendedor");
            Console.WriteLine("1. Crear Vendedor");
            Console.WriteLine("2. Listar Vendedor");
            Console.WriteLine("3. Actualizar Vendedor");
            Console.WriteLine("4. Eliminar Vendedor");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese el email del Vendedor:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre del Vendedor:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido del Vendedor:");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el carne del Vendedor:");
                    string carne = Console.ReadLine();
                    Console.WriteLine("Ingrese la direccion del Vendedor:");
                    string direccion = Console.ReadLine();

                    break;
                case "2":
                    var vendedores = _vendedorService.ReadVendedores();
                    Console.WriteLine("Listado de Clientes:");
                    foreach (var vendedor in vendedores)
                    {
                       
                        Console.WriteLine(
                            $"Código: {vendedor.Codigo}, " +
                            $"Email: {vendedor.Email}," +
                            $" Nombre: {vendedor.Nombre}, " +
                            $"Apellido: {vendedor.Apellido}," +
                            $" Carne: {vendedor.Carne}," +
                            $" Dirreccion: {vendedor.Direccion}");
                    }

                    break;
                case "3":
                    Console.WriteLine("Ingrese el código del vendedor a actualizar:");
                    int codigoVendedor = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo email del vendedor:");
                    string nuevoEmail = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo nombre del vendedor:");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo apellido del vendedor:");
                    string nuevoApellido = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva direccion del vendedor:");
                    string nuevoDireccion = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo carne del vendedor:");
                    string nuevoCarne = Console.ReadLine();
                    _clienteService.UpdateCliente(codigoCliente, nuevoEmail, nuevoNombre, nuevoApellido, nuevoDireccion, nuevoCarne);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el código del vendedor a eliminar:");
                    int codigoEliminarVendedor = int.Parse(Console.ReadLine());
                    _clienteService.DeleteVendedor(codigoEliminarVendedor);
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