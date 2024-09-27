public class ProductoView
{
    private readonly ProductoService _productoService;

    public ProductoView()
    {
        _productoService = new ProductoService();
    }

    public void ShowMenu()
    {
        int option;
        do
        {
            Console.WriteLine("\n--- Menú de Productos ---");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            option = int.Parse(Console.ReadLine() ?? "0");

            switch (option)
            {
                case 1:
                    CreateProducto();
                    break;
                case 2:
                    ListProductos();
                    break;
                case 3:
                    UpdateProducto();
                    break;
                case 4:
                    DeleteProducto();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (option != 0);
    }

    private void CreateProducto()
    {
        Console.WriteLine("\n--- Crear Producto ---");
        Console.Write("Nombre del Producto: ");
        var nombre = Console.ReadLine();

        Console.Write("Stock: ");
        var stock = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Valor unitario: ");
        var valorunitario = double.Parse(Console.ReadLine() ?? "0");

        _productoService.CreateProducto(nombre, stock, valorunitario);
    }

    private void ListProductos()
    {
        Console.WriteLine("\n--- Lista de Productos ---");
        var productos = _productoService.ReadProductos();

        foreach (var producto in productos)
        {
            Console.WriteLine(
                $"ID: {producto.Codigo}, Nombre: {producto.Nombre}, Stock: {producto.Stock}, Valor Unitario: {producto.Valorunitario}");
        }
    }

    private void UpdateProducto()
    {
        Console.WriteLine("\n--- Actualizar Producto ---");
        Console.Write("Código del Producto: ");
        var codigo = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Nuevo Nombre: ");
        var nuevoNombre = Console.ReadLine();

        Console.Write("Nuevo Stock: ");
        var nuevoStock = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Nuevo Valor Unitario: ");
        var nuevoValorunitario = double.Parse(Console.ReadLine() ?? "0");

        _productoService.UpdateProducto(codigo, nuevoNombre, nuevoStock, nuevoValorunitario);
    }

    private void DeleteProducto()
    {
        Console.WriteLine("\n--- Eliminar Producto ---");
        Console.Write("Código del Producto: ");
        var codigo = int.Parse(Console.ReadLine() ?? "0");

        _productoService.DeleteProducto(codigo);
    }
}