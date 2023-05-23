/*-- Crear la tabla RegistroLaboral
CREATE TABLE IF NOT EXISTS RegistroLaboral (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    IdEmpleado INTEGER NOT NULL,
    CantidadHorasTrabajadas REAL NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleado (ID) ON DELETE CASCADE ON UPDATE CASCADE
);
*/


namespace AppNomina
{
    public class RegistroLaboral
    {
        private int id;
        private int idEmpleado;
        private int  cantidadHorasTrabajadas;
       

    
         public int IdEmpleado { 
                    get { return idEmpleado; } 
                    set { idEmpleado = value;}
                     }
        public int Id { 
                    get { return id; } 
                    set { id = value;}
                     }

        public int CantidadHorasTrabajadas { 
                    get { return cantidadHorasTrabajadas; } 
                    set { cantidadHorasTrabajadas = value;}
                     }
    public RegistroLaboral(){}

    public RegistroLaboral(int IdEmpleado, int cantidadHoras)
    {
        this.IdEmpleado = IdEmpleado;
        this.CantidadHorasTrabajadas = cantidadHoras;
    }
    public RegistroLaboral(int id, int IdEmpleado, int cantidadHoras)
    {
        this.id = id;
        this.IdEmpleado = IdEmpleado;
        this.CantidadHorasTrabajadas = cantidadHoras;
    }
    }

}
