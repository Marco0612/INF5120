// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        RegistroEstudiantes registro = new RegistroEstudiantes();
        registro.CargarDatos();
        char seleccion = '1';
        do{
            Console.Clear();
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Eliminar estudiante");
            Console.WriteLine("3. Actualizar estudiante");
            Console.WriteLine("4. Listar estudiantes");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            seleccion = Console.ReadKey().KeyChar;
                try
                {
                    switch (seleccion)
                    {
                        case '1':
                            AgregarEstudiante(registro);
                            break;
                        case '2':
                            EliminarEstudiante(registro);
                            break;
                        case '3':
                            ActualizarEstudiante(registro);
                            break;
                        case '4':
                            ListarEstudiantes(registro);
                            break;
                        case '5':

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

            registro.GuardarDatos();
        }while(seleccion != '5');

    }
        

    public static void AgregarEstudiante(RegistroEstudiantes registro)
    {
        Estudiante estudiante = new Estudiante();
        Console.Clear();
        Console.Write("\nIngrese el ID: ");
        estudiante.ID = int.Parse(Console.ReadLine() ?? "");

        Console.Write("\nIngrese el Nombre: ");
        estudiante.Nombre = Console.ReadLine() ?? "";

        Console.Write("\nIngrese el Apellido: ");
        estudiante.Apellido = Console.ReadLine()?? "";

        Console.Write("\nIngrese la Edad: ");
        estudiante.Edad = int.Parse(Console.ReadLine()??"" );

        registro.AgregarEstudiante(estudiante);
        Console.WriteLine("Estudiante Agregado");
        Console.ReadLine();
    }
    private static void ActualizarEstudiante(RegistroEstudiantes registro)
    {
        Estudiante estudiante = new Estudiante();

        Console.Write("\nID del estudiante a actualizar: ");
        estudiante.ID = int.Parse(Console.ReadLine()?? "");

        Console.Write("\nNuevo nombre: ");
        estudiante.Nombre = Console.ReadLine() ?? "";

        Console.Write("\nNuevo apellido: ");
        estudiante.Apellido = Console.ReadLine()?? "";

        Console.Write("\nNueva edad: ");
        estudiante.Edad = int.Parse(Console.ReadLine()?? "");

        registro.ActualizarEstudiante(estudiante);
        Console.WriteLine("\nEstudiante actualizado.");
        Console.ReadLine();
    }

    private static void ListarEstudiantes(RegistroEstudiantes registro)
    {
        Console.ReadLine();
        registro.ListarEstudiantes();
        Console.ReadLine();
    }
    static void EliminarEstudiante(RegistroEstudiantes registro)
    {
       Console.Write("\nID del estudiante a eliminar: ");
        int id = int.Parse(Console.ReadLine()??"");

        registro.EliminarEstudiante(id);
        Console.WriteLine("\nEstudiante eliminado.");
        Console.ReadLine();
    }

}

