using TallerDesarrollo.models;
using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

private readonly ProductosPorFacturaService _productosporfacturaservice;

public ProductosPorFacturaView()
{
    _productosPorFacturaService = new ProductosPorFacturaService();
}

public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Facturas");
            Console.WriteLine("1. Crear Productos Por Factura");
            Console.WriteLine("2. Listar Productos Por Factura");
            Console.WriteLine("3. Actualizar Productos Por Factura");
            Console.WriteLine("4. Eliminar Productos Por Factura");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();
             switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese la fecha:");
                    fecha = DateOnly(Console.ReadLine());
                    Console.WriteLine("Ingrese La cantidad del producto");
                    int cantidad = int.Parse(Console.ReadLine());
                    double valorTotal = Valorunitario*cantidad;
                    _productosporfacturasService.CreateProductoPorFactura(Fecha,cantidad, valorTotal);
                    break;
                case "2":
                    var ProductosPorFactura = _productoporfacturaService.ReadProductosPorFactura();
                    Console.WriteLine("Listado de Productos por factura:");
                    foreach (var productoporfactura in ProductosPorFactura)
                    {
                        Console.WriteLine(
                            $"Código: {productoporfactura.codigoFactura}, Fecha: {productoporfactura.fecha}, Cantidad: {productoporfactura.cantidad}, Valor Total: {productoporfactura.Valortotal}");
                    }

                    break;
                case "3":
                    Console.WriteLine("Ingrese el código del producto de factura a actualizar:");
                    int codigoFactura = int.Parse(Console.ReadLine());
                     Console.WriteLine("Ingrese la nueva catidad del producto:");
                    int nuevaCantidad = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo valor total del producto:");
                    double nuevoValortotal = double.Parse(Console.ReadLine());
                    _productosporfacturaService.UpdateProductoPorFactura(codigo, nuevaCantidad,nuevoValortotal);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el código del producto por facturas a eliminar:");
                    int codigoEliminar = int.Parse(Console.ReadLine());
                    _productosporfacturaService.DeleteProductoPorFactura(codigoEliminar);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
