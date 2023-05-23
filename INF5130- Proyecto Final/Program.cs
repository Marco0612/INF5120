// See https://aka.ms/new-console-template for more information
using System;
int option;
do
{
    menu();
    string nombre , apellido, cedula;

    //string op = Console.Read();
    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("Ingrese su nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido: ");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese su cedula: ");
            cedula =Console.ReadLine();


            if(existe_cliente(cedula))
            {
                Cliente cliente = new Cliente(nombre,apellido,cedula);
            }else{
                Console.WriteLine("Ya está Registrado este cliente\n");
            }


            break;



        default:
            continue;
    }


} while (option != 5);


void menu()
{
    Console.WriteLine("       UNIVERSIDAD AUTONOMA DE SANTO DOMINGO       ");
    Console.WriteLine("              INF5120 - Proyecto Final             ");
    Console.WriteLine("       Marco Antonio Reyes Olivo - 100661222        \n\n\n");
    Console.WriteLine("        TIENDA DE PAQURTES DE SERVICIOS            \n\n\n");
    Console.WriteLine("Opciones:                                          ");
    Console.WriteLine("1-Registrase como Cliente                          ");
    Console.WriteLine("2-Registrar Servicio                              ");
    Console.WriteLine("3-Activar Paquete                                  ");
    Console.WriteLine("4-Agregar Saldo                                    ");
    Console.WriteLine("5-Salir                                  ");
    Console.WriteLine("Ingrese una opcion: ");
}

bool existe_cliente(string cedula)
{
    using(var reader = new StreamReader(@"./files/clientes.csv"))
    {
        List<string> listA = new List<string>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');

            listA.Add(values[2]);
        }


        foreach (var item in listA)
        {
            if(item == cedula){
                return true;
            }
        }

        return false;

    }
}

