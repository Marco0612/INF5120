using System;
using System.Collections.Generic;

namespace AppNomina
{
    public class AppNomina
    {
        private readonly IPersistencia _storage;

        public AppNomina()
        {
            // Obtener la ruta del directorio donde se encuentra la aplicación en ejecución
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            // Utilice SQLiteStorage o FileStorage según sus necesidades
            _storage = new SQLiteStorage($"Data Source={appPath}nomina.db");
            //_storage = new FileStorage($"{appPath}contactos.txt");
        }

        public void Iniciar()
        {
            char seleccion, seleccion2;
            do
            {
                Console.Clear();
                Console.WriteLine("--------Bienvenido a la Nomina--------");
                Console.WriteLine("Seleccione una función");
                Console.WriteLine("1) Gestionar Empleados");
                Console.WriteLine("2) Gestionar Registros Laborales");
                Console.WriteLine("3) Gestionar Detalle de Nomina");
                Console.WriteLine("4) Imprimir Nomina");
                Console.WriteLine("5) Exportar Nomina en Txt");
                Console.WriteLine("6) Salir");

                seleccion = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                switch (seleccion)
                {
                    case '1':
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("--------Bienvenido Gestionar los Empleados--------");
                            Console.WriteLine("Seleccione una función");
                            Console.WriteLine("1) Listar empleados");
                            Console.WriteLine("2) Agregar empleados");
                            Console.WriteLine("3) Eliminar empleados");
                            Console.WriteLine("4) Salir");

                            seleccion2 = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (seleccion2)
                            {
                                case '1':
                                    ListarEmpleados(_storage.GetEmpleados());
                                    break;
                                case '2':
                                    AgregarEmpleado();
                                    break;
                                case '3':
                                    EliminarEmpleado();
                                    break;
                                case '4':
                                    break;
                            }
                        } while (seleccion2 != '4');
                        break;
                    case '2':
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("--------Bienvenido los Registros Laborales--------");
                            Console.WriteLine("Seleccione una función");
                            Console.WriteLine("1) Listar Registros Laborales");
                            Console.WriteLine("2) Agregar Registros Laborales");
                            Console.WriteLine("3) Eliminar Registro Laboral");
                            Console.WriteLine("4) Salir");

                            seleccion2 = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (seleccion2)
                            {
                                case '1':
                                    ListarRegistroLaborales(_storage.GetRegistroLaborals());
                                    break;
                                case '2':
                                    AgregarRegistroLaboral();
                                    break;
                                case '3':
                                    EliminarRegistroLaboral();
                                    break;
                                case '4':
                                    break;
                            }
                        } while (seleccion2 != '4');
                        break;
                    case '3':
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("--------Bienvenido Gestionar Detalles de Nomina--------");
                            Console.WriteLine("Seleccione una función");
                            Console.WriteLine("1) Listar Detalle de Nomina");
                            Console.WriteLine("2) Agregar Detalle de Nomina");
                            Console.WriteLine("3) Eliminar Detalle de Nomina");
                            Console.WriteLine("4) Salir");

                            seleccion2 = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (seleccion2)
                            {
                                case '1':
                                    ListarDetalleNomina(_storage.GetDetalleNomina());
                                    break;
                                case '2':
                                    AgregarDetalleNomina();
                                    break;
                                case '3':
                                    EliminarDetalleNomina();
                                    break;
                                case '4':
                                    break;
                            }
                        } while (seleccion2 != '4');
                        break;
                    case '4':
                       _storage.printNomina();
                       Console.ReadLine();
                        break;
                    case '5':
                        _storage.archivotxtNomina();
                        Console.WriteLine("El archivo se ha creado correctamente");
                        Console.ReadLine();
                        break;
                }
            } while (seleccion != '6');

        }


        private void ListarEmpleados(List<Empleado> empleados)
        {
            Console.WriteLine("\n---LISTA DE Empleados---\n");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados");
            }
            else
            {
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"ID.                : {empleados[i].Id}");
                    Console.WriteLine($"Nombre             : {empleados[i].Nombre}");
                    Console.WriteLine($"Fecha de Nacimiento: {empleados[i].Fecha_nacimiento}");
                    Console.WriteLine($"Precio Por Hora    : {empleados[i].PrecioPorHora}");
                    Console.WriteLine($"Cuenta Bancaria    : {empleados[i].CuentaBanco}");
                    Console.WriteLine("------------------------------------------------");
                }

                Console.WriteLine($"\n\nTotal empleados: {empleados.Count}\n");
            }

            Console.ReadLine();
        }
        private void AgregarEmpleado()
        {
            Console.WriteLine("Introduzca un nombre: ");
            string nombre = Console.ReadLine() ??  "";
            Console.WriteLine("Introduzca su fecha de nacimiento: " );
            string fecha_nacimiento = Console.ReadLine() ?? "";
            Console.WriteLine("Introduzca su precio por hora: " );
            double precio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Introduzca su Cuenta de Banco: " );
            string cuenta = Console.ReadLine() ?? "";

            Empleado empleado = new Empleado(nombre, fecha_nacimiento, precio, cuenta);

            _storage.GuardarEmpleado(empleado);
        }


        private void EliminarEmpleado()
        {
            List<Empleado> empleados = _storage.GetEmpleados();
            ListarEmpleados(empleados);
      
            Console.WriteLine("¿Qué empleado desea eliminar?");
            int idx;  
            int.TryParse(Console.ReadLine(), out  idx);
       
            Empleado empleado = empleados.Find(c => c.Id == idx);
            if (empleado != null)
            {
                _storage.EliminarEmpleado(empleado.Id);
                Console.WriteLine("Empleado eliminado.");
            }
            else
            {
                Console.WriteLine("Id inválido.");
            }
            Console.ReadLine();
        }


        private void ListarRegistroLaborales(List<RegistroLaboral> registros)
        {
            Console.WriteLine("\n---LISTA DE REGISTROS LABORALES---\n");

            if (registros.Count == 0)
            {
                Console.WriteLine("No hay registros");
            }
            else
            {
                for (int i = 0; i < registros.Count; i++)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"No                 : {registros[i].Id}");
                    Console.WriteLine($"ID del empleado    : {registros[i].IdEmpleado}");
                    Console.WriteLine($"Nombre             : {registros[i].CantidadHorasTrabajadas}");
                    Console.WriteLine("------------------------------------------------");
                }

                Console.WriteLine($"\n\nTotal registros: {registros.Count}\n");
            }

            Console.ReadLine();
        }
        private void AgregarRegistroLaboral()
        {
            Console.WriteLine("Introduzca el ID del empleado nombre: ");
            int id = int.Parse(Console.ReadLine() ??  "");

            Console.WriteLine("Introduzca las horas trabajadas por dicho empleado " );
            int horas = int.Parse(Console.ReadLine() ??  "");

            RegistroLaboral registro = new RegistroLaboral(id,horas);

            _storage.GuardarRegistroLaboral(registro);
        }


        private void EliminarRegistroLaboral()
        {
            List<RegistroLaboral> registros = _storage.GetRegistroLaborals();
            ListarRegistroLaborales(registros);
      
            Console.WriteLine("¿Qué registro desea eliminar?");
            int idx;  
            int.TryParse(Console.ReadLine(), out  idx);
       
           RegistroLaboral registro = registros.Find(c => c.Id == idx);
            if (registro != null)
            {
                _storage.EliminarEmpleado(registro.Id);
                Console.WriteLine("Registro Laboral eliminado.");
            }
            else
            {
                Console.WriteLine("Id inválido.");
            }
            Console.ReadLine();
        }

        private void ListarDetalleNomina(List<DetalleNomina> nominas)
        {
            Console.WriteLine("\n---LISTA DE NOminas---\n");

            if (nominas.Count == 0)
            {
                Console.WriteLine("No hay registros");
            }
            else
            {
                for (int i = 0; i < nominas.Count; i++)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"No                : {nominas[i].Id}");
                    Console.WriteLine($"ID del Empleado   : {nominas[i].IdEmpleado}");
                    Console.WriteLine($"Fecha             : {nominas[i].Fecha}");
                    Console.WriteLine($"Monto             : {nominas[i].Monto}");
                    Console.WriteLine("------------------------------------------------");
                }

                Console.WriteLine($"\n\nTotal registros: {nominas.Count}\n");
            }

            Console.ReadLine();
        }
        private void AgregarDetalleNomina()
        {
            Console.WriteLine("Introduzca el ID del empleado nombre: ");
            int id = int.Parse(Console.ReadLine() ??  "");

            Console.WriteLine("Introduzca el Monto: " );
            double monto = Convert.ToDouble(Console.ReadLine() ??  "");
            Console.WriteLine("Introduzca la Fecha: " );
            string fecha = Console.ReadLine() ??  "";


            DetalleNomina nomina = new DetalleNomina(id,monto,fecha);

            _storage.GuardarDetalleNomina(nomina);
        }


        private void EliminarDetalleNomina()
        {
            List<DetalleNomina> nominas = _storage.GetDetalleNomina();
            ListarDetalleNomina(nominas);
      
            Console.WriteLine("¿Qué nomina desea eliminar?");
            int idx;  
            int.TryParse(Console.ReadLine(), out  idx);
       
           DetalleNomina nomina = nominas.Find(c => c.Id == idx);
            if (nominas != null)
            {
                _storage.EliminarEmpleado(nomina.Id);
                Console.WriteLine("Registro Laboral eliminado.");
            }
            else
            {
                Console.WriteLine("Id inválido.");
            }
            Console.ReadLine();
        }
/*
        private void imprimir_nomina()
        {
            Console.WriteLine("\n---  NOMINA  ---\n");

            if (nominas.Count == 0)
            {
                Console.WriteLine("No hay registros");
            }
            else
            {
                for (int i = 0; i < nominas.Count; i++)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"No                : {nominas[i].Id}");
                    Console.WriteLine($"ID del Empleado   : {nominas[i].IdEmpleado}");
                    Console.WriteLine($"Fecha             : {nominas[i].Fecha}");
                    Console.WriteLine($"Monto             : {nominas[i].Monto}");
                    Console.WriteLine("------------------------------------------------");
                }

                Console.WriteLine($"\n\nTotal registros: {nominas.Count}\n");
            }

            Console.ReadLine();
        }*/

}
}

/*switch (seleccion)
                {
                    case '1':
                        ListarEmpleados(_storage.GetEmpleados());
                        break;
                    case '2':
                        AgregarEmpleado();
                        break;
                    case '3':
                        EliminarEmpleado();
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                }
*/