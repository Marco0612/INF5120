using System;
class HelloWorld {
  static void Main()
  {
    Conductor persona = new Conductor("Juean","8");
    IVehiculo moto = new Motocicleta("Modelo 1#", 2010);
    IVehiculo car = new Carro("Modelo 2#", 2023);
    IVehiculo cam = new Camion("Modelo 4#", 2003);
    persona.conducir(moto);
    persona.conducir(car);
    persona.conducir(cam);
    
  }
}

/*
public class Correr
{
    static void Main()
    {
        Conductor persona = new Conductor("Modelo 4","8");
        //IVehiculo camion = new Carro("Modelo #1",2003);

    }
}*/
    public interface IVehiculo
    {
        void frenar();
        void parquear();
        void acelerar();
    }

    class Conductor
    {
        private string name;
        private string id;

        public Conductor()
        {
            name = "Not a name";
            id = "0000001";
        }
        public Conductor(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        public void conducir(IVehiculo vehiculo)
        {
            Console.WriteLine("Coductor esta manejando " + vehiculo.ToString());
        }
        public override string ToString(){
            return $"ID: {id}; Nombre: {name}";
        }
    }

    class Motocicleta: IVehiculo
    {
        private string modelo;
        private int year;
        public Motocicleta(string modelo, int a)
        {
            this.modelo = modelo;
            this.year = a;
        }
        public void frenar()
        {
            Console.WriteLine("\nLa moto está frenado.");
        }
        public  void parquear()
        {
            Console.WriteLine("\nLa moto está parqueada.");
        }
        public void acelerar()
        {
            Console.WriteLine("\nLa moto está acelerando.");
        }
        public override string ToString()
        {
            return $"Tipo de vehiculo: Moto; Modelo: {modelo}; Año: {year}";
        }

    }
    class Carro: IVehiculo
    {
        private string modelo;
        private int year;
        
        public Carro(string modelo, int a)
        {
            this.modelo = modelo;
            this.year = a;
        }
        public void frenar()
        {
            Console.WriteLine("\nEl carro está frenado.");
        }
        public  void parquear()
        {
            Console.WriteLine("\nEl carro está parqueada.");
        }
        public void acelerar()
        {
            Console.WriteLine("\nEL carro está acelerando.");
        }
        public override string ToString()
        {
            return $"Tipo de vehiculo: Carro; Modelo: {modelo}; Año: {year}";
        }
    }

    class Camion: IVehiculo
    {
        private string modelo;
        private int year;
        public Camion(string modelo, int a)
        {
            this.modelo = modelo;
            this.year = a;
        }
        public void frenar()
        {
            Console.WriteLine("\nEl camión está frenado.");
        }
        public  void parquear()
        {
            Console.WriteLine("\nEl camión está parqueada.");
        }
        public void acelerar()
        {
            Console.WriteLine("\nEl camión está acelerando.");
        }
        public override string ToString()
        {
            return $"Tipo de vehiculo: Camion; Modelo: {modelo}; Año: {year}";
        }
    }

