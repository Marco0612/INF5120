using System.Text.Json;
class Estudiante
{
    private int id;
    private string nombre;
    private string apellido;
    private int edad;

    public Estudiante()
    {
        nombre ="";
        apellido="";
    }

    public Estudiante(string nombre, string apellido, int edad)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.edad = edad;

    }
    public Estudiante(int id, string nombre, string apellido, int edad): this(nombre, apellido, edad)
    {
        this.id = id;
    }

    public int ID{
        get{return id;}
        set{id = value;}
    }
    public string Nombre{
        get{return nombre;}
        set{nombre = value;}
    }
    public string Apellido{
         get{return apellido;}
        set{apellido = value;}
    }
    public int Edad{
         get{return edad;}
        set{edad = value;}
    }
    
}