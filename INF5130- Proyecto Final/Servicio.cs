class Servicio
{
    public  string phone_number;
    private double saldo;
    private Cliente cliente= new Cliente();
    private List<IPaquete> paquetes = new List<IPaquete>();



    public Servicio(string phone_number, double saldo, Cliente cliente)
    {
        this.phone_number = phone_number;
        this.saldo = saldo;
        this.cliente = cliente;

        AgreagarRecord(phone_number, cliente.get_cedula(), "./files/servicios.csv");

    }

    public static void AgreagarRecord(string phone_number, string cedula, string pathname)
    {
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(@pathname,true))
        {
            file.WriteLine($"{phone_number},{cedula}");
        }
    } 
    public static void AgreagarRecordPaquetesActivados(string phone_number, string tipo_paquete, string pathname)
    {
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(@pathname,true))
        {
            file.WriteLine($"{phone_number},{tipo_paquete}");
        }
    } 
    public void AgregregarPaquete(IPaquete paquete)
    {
        paquetes.Add(paquete);
        string text = paquete.ToString();
        AgreagarRecordPaquetesActivados(phone_number, text,"./files/Paquetes_activados.csv");
    }
   
}

