class Correr
{

    static void Main()
    {
        Titular titular = new Titular("Marco Reyes", "001-09849430-0", new DateTime(2003, 12, 6));
        Console.WriteLine(titular);
        CuentaBancaria cuenta = new CuentaBancaria(1,100000,titular);
        Console.WriteLine(cuenta);
        CuentaBancaria cuenta1 = new CuentaBancaria(2,400000);
        Console.WriteLine(cuenta);
        cuenta1.asignarTitular(titular);


    }
    class CuentaBancaria
    {
        private int NumeroCuenta;
        private decimal saldo;

        private Titular persona;

        public CuentaBancaria()
        {
            NumeroCuenta =0;
            saldo = 0;
            persona = new Titular();
        }
        public CuentaBancaria(int NumeroCuenta, decimal saldo)
        {
            this.NumeroCuenta = NumeroCuenta;
            this.saldo = saldo;
            persona = new Titular();
        }
        public CuentaBancaria(int NumeroCuenta, decimal saldo, Titular titular)
        {
            this.NumeroCuenta = NumeroCuenta;
            this.saldo = saldo;
            this.persona = titular;
        }

        public void AgrgarSaldo(decimal num)
        {
            saldo += num;
        }

        public void asignarTitular(Titular titular)
        {
            persona = titular;
        }

        public override string ToString()
        {
            return $"\nNúmero de Cuenta: {NumeroCuenta}\nSaldo: {saldo}\nDatos del Titular: {persona.ToString()}";
        }

    }

    class Titular
    {
        private string nombre;
        private string cedula;
        private DateTime fechaNacimiento;

        public  Titular()
        {
            cedula = "000-00000000-0";
            nombre ="";
            fechaNacimiento= new DateTime(2000,1,1);
        }

        public void set_cedula(string cedula)
        {
            this.cedula = cedula;
        }

        public void set_nombre(string nombre)
        {
            this.nombre = cedula;
        }

        public string get_cedula()
        {
            return cedula;
        }

        public string get_nombre()
        {
            return cedula;
        }

        public Titular(string nombre, string cedula, DateTime fecha)
        {
            this.nombre = nombre;
            this.cedula = cedula;
            this.fechaNacimiento = fecha;
        }


        public override string ToString()
        {
            return $"\nNombre: {nombre} Cedula: {cedula} Fecha de Nacimient: {fechaNacimiento}";
        }
    }
}