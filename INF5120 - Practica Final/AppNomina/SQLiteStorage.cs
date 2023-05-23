using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;

namespace AppNomina
{
    public class SQLiteStorage : IPersistencia
    {
        private readonly string _connectionString;

        public SQLiteStorage(string connectionString)
        {
            _connectionString = connectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                -- Crear la tabla Empleado
                CREATE TABLE IF NOT EXISTS Empleado (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    FechaNacimiento TEXT NOT NULL,
                    PrecioPorHora REAL NOT NULL,
                    CuentaBanco TEXT NOT NULL
                );

                -- Crear la tabla RegistroLaboral
                CREATE TABLE IF NOT EXISTS RegistroLaboral (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    IdEmpleado INTEGER NOT NULL,
                    CantidadHorasTrabajadas REAL NOT NULL,
                    FOREIGN KEY (IdEmpleado) REFERENCES Empleado (ID) ON DELETE CASCADE ON UPDATE CASCADE
                );

                -- Crear la tabla DetalleNomina
                CREATE TABLE IF NOT EXISTS DetalleNomina (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Fecha TEXT NOT NULL,
                    IdEmpleado INTEGER NOT NULL,
                    Monto REAL NOT NULL,
                    FOREIGN KEY (IdEmpleado) REFERENCES Empleado (ID) ON DELETE CASCADE ON UPDATE CASCADE
                    );
            ";
            command.ExecuteNonQuery();
        }

        public List<Empleado> GetEmpleados()
        {
            var empleados = new List<Empleado>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM empleado;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var empleado = new Empleado
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Fecha_nacimiento = reader.GetString(2),
                    PrecioPorHora = reader.GetDouble(3),
                    CuentaBanco = reader.GetString(4),

                    
                };
                empleados.Add(empleado);
            }

            return empleados;
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO empleado (Nombre, FechaNacimiento, PrecioPorHora, CuentaBanco ) VALUES (@nombre, @fecha, @precio, @cuenta);";
            command.Parameters.AddWithValue("@nombre", empleado.Nombre);
            command.Parameters.AddWithValue("@fecha", empleado.Fecha_nacimiento);
            command.Parameters.AddWithValue("@precio", empleado.PrecioPorHora);
            command.Parameters.AddWithValue("@cuenta", empleado.CuentaBanco);
            command.ExecuteNonQuery();
        }

        public void EliminarEmpleado(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM empleado WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void EliminarEmpleado(Empleado empleado)
        {
            EliminarEmpleado(empleado.Id);
        }

        public List<RegistroLaboral> GetRegistroLaborals()
        {
            var registros = new List<RegistroLaboral>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM RegistroLaboral;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var registro = new RegistroLaboral
                {
                    Id = reader.GetInt32(0),
                    IdEmpleado = reader.GetInt32(1),
                    CantidadHorasTrabajadas = reader.GetInt32(2)
                };
                registros.Add(registro);
            }

            return registros;
        }

        public void GuardarRegistroLaboral(RegistroLaboral registro)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO RegistroLaboral (IdEmpleado, CantidadHorasTrabajadas) VALUES (@id, @horas);";
            command.Parameters.AddWithValue("@id", registro.IdEmpleado);
            command.Parameters.AddWithValue("@horas", registro.CantidadHorasTrabajadas);
            command.ExecuteNonQuery();
        }

        public void EliminarRegistroLaboral(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM RegistroLaboral WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void EliminarRegistroLaboral(RegistroLaboral registro)
        {
            EliminarRegistroLaboral(registro.Id);
        }

        public List<DetalleNomina> GetDetalleNomina()
        {
            var nominas = new List<DetalleNomina>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DetalleNomina;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var nomina = new DetalleNomina()
                {
                    Fecha = reader.GetString(1),
                    IdEmpleado = reader.GetInt32(2),
                    Monto = reader.GetDouble(3)
                };
                nominas.Add(nomina);
            }

            return nominas;
        }

        public void GuardarDetalleNomina(DetalleNomina nomina)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO DetalleNomina (Fecha ,IdEmpleado, Monto) VALUES (@fecha,@id, @monto);";
            command.Parameters.AddWithValue("@id", nomina.IdEmpleado);
            command.Parameters.AddWithValue("@monto", nomina.Monto);
            command.Parameters.AddWithValue("@fecha", nomina.Fecha);
            command.ExecuteNonQuery();
        }

        public void EliminarDetalleNomina(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM DetalleNomina WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void EliminarDetalleNomina(DetalleNomina nomina)
        {
            EliminarRegistroLaboral(nomina.IdEmpleado);
        }


        public void printNomina()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT e.Nombre, e.PrecioPorHora, e.CuentaBanco, dn.Monto, dn.Fecha  FROM Empleado e INNER JOIN DetalleNomina dn ON e.ID = dn.idEmpleado;";

            using var reader = command.ExecuteReader();
            
            Console.WriteLine("NOMBRE | PRECIO POR HORA | CUENTA DE BANCO| MONTO | FECHA");

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetString(0)},    {reader.GetString(1)},    {reader.GetString(2)},    {reader.GetString(2)},   {reader.GetString(3)},    {reader.GetString(4)}   ");
            }
        }

        public void archivotxtNomina()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT e.Nombre, e.PrecioPorHora, e.CuentaBanco, dn.Monto, dn.Fecha  FROM Empleado e INNER JOIN DetalleNomina dn ON e.ID = dn.idEmpleado;";

            using var reader = command.ExecuteReader();
            File.Delete(@"./nomina.txt");
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"./nomina.txt",true))
            {
                    file.WriteLine("NOMBRE | PRECIO POR HORA | CUENTA DE BANCO| MONTO | FECHA");
            }
            while (reader.Read())
            {
                using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"./nomina.txt",true))
                {
                    file.WriteLine($"{reader.GetString(0)},{reader.GetString(1)},{reader.GetString(2)},{reader.GetString(2)},{reader.GetString(3)},{reader.GetString(4)}");
                }
            }
        }


        
    }
}