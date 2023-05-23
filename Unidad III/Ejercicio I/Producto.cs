

class Producto
{
   private string codigo;
   private string nombre;
   private decimal precio;


   public Producto(string codigo, string nombre, decimal precio)
   {
       this.codigo = codigo;
       this.nombre = nombre;
       this.precio = precio;
   }


   public string get_nombre()
   {
       return nombre;
   }
   public void set_nombre(string name)
   {
       this.nombre = name;
   }
   public decimal get_precio()
   {
       return precio;
   }
   public void set_precio(decimal precio)
   {
       this.precio = precio;
   }
   public string get_codigo()
   {
       return codigo;
   }
   public void set_codigo(string codigo)
   { 
      this.codigo = codigo;
   }






   public override string ToString()
   {
       return $"{codigo}: {nombre} - {precio}\n";
   }


}




class Almacen
{
   public Producto[] productos;
   public Almacen(int num)
   {
       productos = new Producto[num]; 
   }


   public void AgregarProducto(Producto producto)
   {
       for (int i = 0; i <  productos.Length; i++)
       {
           if(productos[i] == null)
           {
               productos[i] = producto;
               return;
           }
       }
       Console.WriteLine("El producto no pudo ser agregado");


   }


   public Producto ObtenerProducto(int index)
   {
       return productos[index-1];
   }


   public void BuscarProducto(string nomb)
   {
       for (int i = 0; i <  productos.Length; i++)
       {
           if(productos[i] != null)
           {
                if(productos[i].get_nombre().ToUpper().Contains(nomb.ToUpper()))
                {
                    Console.WriteLine(productos[i]); 
                }
           }
       }
   }


   public void EliminarProducto(int index)
   {
       productos[index-1] = null;
   }


   public override string ToString()
   {
       string all = "";
       for (int i = 0; i <  productos.Count(); i++)
       {
           if(productos[i] != null)
           {
               all += i+1+". " +productos[i].ToString();
           }
       }
       return all;
   }


}




