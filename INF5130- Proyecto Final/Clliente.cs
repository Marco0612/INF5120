
class Cliente
{
    protected string name;
    protected string cedula;
    string apellido;
    //private static int id;
    private List<Servicio> servicios = new List<Servicio>();
    public Cliente()
    {
        name = "";
        apellido ="";
        cedula= "";

    }
    public Cliente(string nombre,string apellido, string cedula)
    {

        name = nombre;
        this.cedula = cedula;
        this.apellido = apellido;
        AgreagarRecord(name,apellido,cedula,"./files/clientes.csv");
    }

    public static void AgreagarRecord(string name, string apellido, string cedula, string pathname)
    {
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(@pathname,true))
        {
            file.WriteLine($"{name},{apellido},{cedula}");
        }
    } 
    public void AgreagarServicio(Servicio service)
    {
        servicios.Add(service);
    }

    public override string ToString()
    {
        string text = $"Nombre: {name}, Apellido: {apellido}, Cedula: {cedula}, Servicios: ";
        foreach(Servicio serv in servicios)
        {
            text += serv.phone_number + " ";
        }
        return text;
        
    }

    public string get_cedula()
    {
        return this.cedula;
    }

}