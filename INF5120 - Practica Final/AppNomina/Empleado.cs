/*
-- Crear la tabla Empleado
CREATE TABLE IF NOT EXISTS Empleado (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    FechaNacimiento TEXT NOT NULL,
    PrecioPorHora REAL NOT NULL,
    CuentaBanco TEXT NOT NULL
);

*/

namespace AppNomina
{
    public class Empleado
    {
        private int id;
        private string nombre;
        private string fecha_nacimiento;

        private double precioPorHora;
        private string cuentaBanco;

         public string Nombre { 
                    get { return nombre; } 
                    set { nombre = value;}
                     }
        public string Fecha_nacimiento
        {   get{ return fecha_nacimiento;} 
            set{fecha_nacimiento = value;} 
        }
         public int Id { 
                    get { return id; } 
                    set { id = value;}
                     }

        public double PrecioPorHora { 
                    get { return precioPorHora; } 
                    set { precioPorHora = value;}
                     }
        public string CuentaBanco
        {
                    get { return cuentaBanco; } 
                    set { cuentaBanco = value;}
                     }
        
    

    public Empleado()
    {
        nombre ="";
        fecha_nacimiento="";
        cuentaBanco= "";

    }

    public Empleado(string nombre, string fecha_nacimiento, double precioPorHora, string cuentaBanco)
    {
        this.nombre = nombre;
        this.fecha_nacimiento = fecha_nacimiento;
        this.precioPorHora = precioPorHora;
        this.cuentaBanco =cuentaBanco;
    }
    public Empleado(int id, string nombre, string fecha_nacimiento, double precioPorHora, string cuentaBanco): this(nombre, fecha_nacimiento, precioPorHora, cuentaBanco)
    {
       this.Id = id;
    }
    }
}

