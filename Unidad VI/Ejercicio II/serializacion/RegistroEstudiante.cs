using System.Text.Json;
class RegistroEstudiantes
{
    private List<Estudiante> estudiantes;

    public RegistroEstudiantes()
    {
        estudiantes = new List<Estudiante>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        estudiantes.Add(estudiante);
    }

    public void EliminarEstudiante(int id)
    {
        estudiantes.RemoveAll(e => e.ID == id);
    }

    public void ActualizarEstudiante(Estudiante estudiante)
    {
        int index = estudiantes.FindIndex(e => e.ID == estudiante.ID);
        if (index != -1)
        {
            estudiantes[index] = estudiante;
        }
    }

    public void ListarEstudiantes()
    {
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"ID: {estudiante.ID}, Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, Edad: {estudiante.Edad}");
        }
    }

    public void GuardarDatos()
    {
        string jsonData = JsonSerializer.Serialize(estudiantes);
        File.WriteAllText("estudiantes.json", jsonData);
    }

    public void CargarDatos()
    {
        if (File.Exists("estudiantes.json"))
        {
            string jsonData = File.ReadAllText("estudiantes.json");
            estudiantes = JsonSerializer.Deserialize<List<Estudiante>>(jsonData);
        }
    }
}