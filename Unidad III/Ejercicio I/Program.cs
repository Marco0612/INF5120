class Corre{
static void Main(string[] args)
{
    Console.WriteLine("Juan");
    
    Almacen almacen1 = new Almacen(5);
    Console.WriteLine(almacen1);
    almacen1.AgregarProducto(new Producto("001", "Botella de vino", 1000));
    almacen1.AgregarProducto(new Producto("002", "Botella de cervesa", 500));
    almacen1.AgregarProducto(new Producto("003", "Fresas", 300));
    almacen1.AgregarProducto(new Producto("004", "Mazana", 50));
    almacen1.AgregarProducto(new Producto("005", "Arroz", 45));
    almacen1.AgregarProducto(new Producto("005", "Arroz", 45));
    Console.WriteLine(almacen1);
    almacen1.EliminarProducto(2);
    Console.WriteLine(almacen1);
    //Uso de Obtener Producto
    Console.WriteLine(almacen1.ObtenerProducto(1));
    //Imprimir la lista de de elementos que contienen una A
    almacen1.BuscarProducto("A");

}
}
