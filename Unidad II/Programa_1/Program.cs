// See https://aka.ms/new-console-template for more information


// See https://aka.ms/new-console-template for more information
using System;

class Programa1
{
    
    public string Nombre_titular;
    public string Num_cuenta;
    public double Saldo;

    public CuentaBancaria(string nombre_titular, string num_cuenta, double saldo)
    {
        Nombre_titular = nombre_titular;
        Num_cuenta = num_cuenta;
        Saldo = saldo;
    }

    public void Depositar(double ingreso)
    {
        Saldo += ingreso;
        Console.WriteLine($"Su saldo es: {Saldo}");
    }

    public void Retirar(double cantidad)
    {

        if(Saldo - cantidad >= 0)
        {
            Saldo -= cantidad;
            Console.WriteLine($"Su retiro se ha completado exitosamente. Su nuevo saldo: {Saldo}");
        }else
        {
            Console.WriteLine($"La transacción no puede ser completada. Saldo insuficiente.");
        }
        
    }

    public void MostrarDetalles(){
        Console.WriteLine($"Nombre del titular: {Nombre_titular}");
        Console.WriteLine($"Numero de Cuenta: {Num_cuenta}");
        Console.WriteLine($"Saldo: {Saldo}");
    }
    static void Main()
    {
        CuentaBancaria cuenta1 = new CuentaBancaria("Maria Javier", "000001", 100000);
        CuentaBancaria cuenta2 = new CuentaBancaria("Maximo Reyes", "000002", 100000);
        

        Console.WriteLine("Detalles de la cuenta #1");
        cuenta1.MostrarDetalles();
        Console.WriteLine();

        Console.WriteLine("Detalles de la cuenta #2");
        cuenta2.MostrarDetalles();
        Console.WriteLine();

        cuenta1.Depositar(10000);
        Console.WriteLine();
        cuenta2.Retirar(2000000);
        Console.WriteLine();

        Console.WriteLine("Detalles de la cuenta #1 después del deposito");
        cuenta1.MostrarDetalles();
        Console.WriteLine();

        Console.WriteLine("Detalles de la cuenta #2 después del retiro");
        cuenta2.MostrarDetalles();
        Console.WriteLine();
    }


}
