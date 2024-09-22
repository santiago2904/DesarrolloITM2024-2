using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

public class EmpresaView
{
    private readonly EmpresaService _empresaService;

    public EmpresaView()
    {
        _empresaService = new EmpresaService();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Empresas");
            Console.WriteLine("1. Crear Empresa");
            Console.WriteLine("2. Listar Empresas");
            Console.WriteLine("3. Actualizar Empresa");
            Console.WriteLine("4. Eliminar Empresa");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre de la empresa:");
                    string nombre = Console.ReadLine();
                    _empresaService.CreateEmpresa(nombre);
                    break;
                case "2":
                    var empresas = _empresaService.ReadEmpresas();
                    Console.WriteLine("Listado de Empresas:");
                    foreach (var empresa in empresas)
                    {
                        Console.WriteLine($"Código: {empresa.Codigo}, Nombre: {empresa.Nombre}");
                    }

                    break;
                case "3":
                    Console.WriteLine("Ingrese el código de la empresa a actualizar:");
                    int codigo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo nombre de la empresa:");
                    string nuevoNombre = Console.ReadLine();
                    _empresaService.UpdateEmpresa(codigo, nuevoNombre);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el código de la empresa a eliminar:");
                    int codigoEliminar = int.Parse(Console.ReadLine());
                    _empresaService.DeleteEmpresa(codigoEliminar);
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