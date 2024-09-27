using TallerDesarrollo.services;
using TallerDesarrollo.models;

namespace TallerDesarrollo.views;

public class FacturaView
{
    private readonly FacturaService _facturaService;

    public FacturaView()
    {
        _facturaService = new FacturaService();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Facturas");
            Console.WriteLine("1. Crear Factura");
            Console.WriteLine("2. Listar Facturas");
            Console.WriteLine("3. Actualizar Factura");
            Console.WriteLine("4. Eliminar Factura");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateFactura();
                    break;
                case "2":
                    ListFacturas();
                    break;
                case "3":
                    UpdateFactura();
                    break;
                case "4":
                    DeleteFactura();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private void CreateFactura()
    {
        Console.WriteLine("Ingrese el ID de la persona asociada:");
        if (!int.TryParse(Console.ReadLine(), out int personaId))
        {
            Console.WriteLine("Error: ID de persona inválido.");
            return;
        }

        var productos = AddProductsToFactura();
        if (productos.Count == 0)
        {
            Console.WriteLine("No se añadieron productos a la factura.");
            return;
        }

        _facturaService.CrearFactura(DateTime.Now, personaId, productos);
    }

    private void UpdateFactura()
    {
        Console.WriteLine("Ingrese el código de la factura a actualizar:");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código de factura inválido.");
            return;
        }

        var productos = AddProductsToFactura();
        if (productos.Count == 0)
        {
            Console.WriteLine("No se añadieron productos a la factura.");
            return;
        }

        _facturaService.ActualizarFactura(codigo, productos);
    }


    private List<(int productoId, int cantidad)> AddProductsToFactura()
    {
        var productos = new List<(int productoId, int cantidad)>();

        while (true)
        {
            Console.WriteLine("¿Desea agregar un producto a la factura? (S/N):");
            string respuesta = Console.ReadLine()?.ToUpper();

            if (respuesta == "S")
            {
                Console.WriteLine("Ingrese el código del producto:");
                if (!int.TryParse(Console.ReadLine(), out int productoId))
                {
                    Console.WriteLine("Código de producto inválido.");
                    continue;
                }

                Console.WriteLine("Ingrese la cantidad del producto:");
                if (!int.TryParse(Console.ReadLine(), out int cantidad))
                {
                    Console.WriteLine("Cantidad inválida.");
                    continue;
                }

                productos.Add((productoId, cantidad));
            }
            else if (respuesta == "N")
            {
                break;
            }
            else
            {
                Console.WriteLine("Respuesta no válida.");
            }
        }

        return productos;
    }

    private void ListFacturas()
    {
        var facturas = _facturaService.LeerFacturas();
        if (facturas.Count == 0)
        {
            Console.WriteLine("No hay facturas disponibles.");
            return;
        }

        Console.WriteLine("Listado de Facturas:");
        foreach (var factura in facturas)
        {
            Console.WriteLine(
                $"Código: {factura.Codigo}, Total: {factura.Total}, Fecha: {factura.Fecha:yyyy-MM-dd}, Persona ID: {factura.PersonaId}");
        }
    }

    private void DeleteFactura()
    {
        Console.WriteLine("Ingrese el código de la factura a eliminar:");
        if (!int.TryParse(Console.ReadLine(), out int codigoEliminar))
        {
            Console.WriteLine("Código de factura inválido.");
            return;
        }

        _facturaService.EliminarFactura(codigoEliminar);
        Console.WriteLine("Factura eliminada exitosamente.");
    }
}