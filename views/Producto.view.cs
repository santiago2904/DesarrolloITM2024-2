using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

public class ProductoView
{
    private readonly ProductoService _productoService;

    public ProductoView()
    {
        _productoService = new ProductoService();
    }


    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCRUD Productos");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre del producto:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el stock del producto:");
                    int stock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el valor unitario del producto:");
                    double valorunitario = double.Parse(Console.ReadLine());
                    _productoService.CreateProducto(nombre, stock, valorunitario);
                    break;
                case "2":
                    var productos = _productoService.ReadProductos();
                    Console.WriteLine("Listado de Productos:");
                    foreach (var producto in productos)
                    {
                        Console.WriteLine(
                            $"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Stock: {producto.Stock}, Valor Unitario: {producto.Valorunitario}");
                    }

                    break;
                case "3":
                    Console.WriteLine("Ingrese el código del producto a actualizar:");
                    int codigo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo nombre del producto:");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo stock del producto:");
                    int nuevoStock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo valor unitario del producto:");
                    double nuevoValorunitario = double.Parse(Console.ReadLine());
                    _productoService.UpdateProducto(codigo, nuevoNombre, nuevoStock, nuevoValorunitario);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el código del producto eliminar:");
                    int codigoEliminar = int.Parse(Console.ReadLine());
                    _productoService.DeleteProducto(codigoEliminar);
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