interface IPaquete
{
    //void activar_Paquete();
    void set_PaqueteDias(int dias);
    void set_PaqueteHoras(int horas);
    void set_PaqueteIlimitado();
    string ToString();




}


class Paquete
{
    protected double costo;
    protected int duracion_horas;
    protected string nombre;

    public Paquete(double costo, int duracion_horas)
    {
        this.costo = costo;
        this.duracion_horas = duracion_horas;
        nombre = "";
    }
    public override string ToString()
    {
        string text = $"{nombre} con costo de RD${costo} de duracion de {duracion(duracion_horas)}";
        return text;
    }
    public string duracion(int horas)
    {
        if(horas == -1){
            return "ilimitada";
        }else if (horas/24 > 0)
        {
            return $"{horas/24} dias";
        }else{
            return $"{horas} horas";
        }
    }

}


class PaqueteInternet: Paquete, IPaquete 
{
    public PaqueteInternet(double costo, int duracion_horas):base(costo, duracion_horas)
    {  
        nombre = "Paquete de Internet";
    }
    public void set_PaqueteDias(int dias)
    {
        duracion_horas = 24*dias;
    }
    public void set_PaqueteHoras(int horas)
    {
        duracion_horas = horas;
    }
    public void set_PaqueteIlimitado()
    {
        duracion_horas = -1;
    }


}


class PaqueteMinutos: Paquete, IPaquete 
{
    public PaqueteMinutos(double costo, int duracion_horas):base(costo, duracion_horas)
    {  
        nombre = "Paquete de Internet";
    }
    public void set_PaqueteDias(int dias)
    {
        duracion_horas = 24*dias;
    }
    public void set_PaqueteHoras(int horas)
    {
        duracion_horas = horas;
    }
    public void set_PaqueteIlimitado()
    {
        duracion_horas = -1;
    }



}
class PaqueteRedesSociales: Paquete, IPaquete 
{
    public PaqueteRedesSociales(double costo, int duracion_horas):base(costo, duracion_horas)
    {  
        nombre = "Paquete de Redes Sociales";
    }
    public void set_PaqueteDias(int dias)
    {
        duracion_horas = 24*dias;
    }
    public void set_PaqueteHoras(int horas)
    {
        duracion_horas = horas;
    }
    public void set_PaqueteIlimitado()
    {
        duracion_horas = -1;
    }


}

class PaqueteTodoCompleto: Paquete, IPaquete 
{
    public PaqueteTodoCompleto(double costo, int duracion_horas):base(costo, duracion_horas)
    {  
        nombre = "Paquete de Todo Completo";
    }
    public void set_PaqueteDias(int dias)
    {
        duracion_horas = 24*dias;
    }
    public void set_PaqueteHoras(int horas)
    {
        duracion_horas = horas;
    }
    public void set_PaqueteIlimitado()
    {
        duracion_horas = -1;
    }

}