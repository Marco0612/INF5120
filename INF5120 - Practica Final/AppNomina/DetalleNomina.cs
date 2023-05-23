/*-- Crear la tabla RegistroLaboral
CREATE TABLE IF NOT EXISTS RegistroLaboral (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    IdEmpleado INTEGER NOT NULL,
    CantidadHorasTrabajadas REAL NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleado (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Crear la tabla DetalleNomina
CREATE TABLE IF NOT EXISTS DetalleNomina (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Fecha TEXT NOT NULL,
    IdEmpleado INTEGER NOT NULL,
    Monto REAL NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleado (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

*/
namespace AppNomina{
    public class DetalleNomina
    {
        private int id;
        private int idEmpleado;
        private string fecha;
        private double monto;
        public int Id { 
                    get { return id; } 
                    set { id = value;}
                     }

        public int IdEmpleado { 
                        get { return idEmpleado; } 
                        set { idEmpleado = value;}
                        }

        public double Monto{ 
                        get { return monto; } 
                        set { monto = value;}
                        }
        public string Fecha{
                        get { return fecha; } 
                        set { fecha = value;}
        }
    
    public DetalleNomina()
    {
        fecha = "";
    }
    public DetalleNomina(double monto, string fecha)
    {
        this.monto = monto;
        this.fecha = fecha;

    }
    public DetalleNomina(int id, double monto, string fecha): this(monto, fecha)
    {
        this.idEmpleado = id;
    }
    public DetalleNomina(int id2,int id, double monto, string fecha): this(monto, fecha)
    {
        this.id = id2;
        this.idEmpleado = id;
    }
    }
}
