// See https://aka.ms/new-console-template for more information
/*Crear una clase OutOfAttemptsException que herede de Exception y tenga un constructor
personalizado que reciba un mensaje.
2. Generar un número aleatorio entre 1 y 100.
3. Utilizar un bucle for o while para iterar hasta un máximo de 10 intentos.
4. Dentro del bucle, utilizar un bloque try y catch para manejar las excepciones.
a. Utilizar int.TryParse para validar la entrada del usuario y manejar el caso de caracteres
no válidos.
b. Si la entrada es válida, pero está fuera del rango, lanzar y manejar una
ArgumentOutOfRangeException.
c. Si el usuario adivina el número, mostrar un mensaje de felicitación y salir del bucle.
5. Si el bucle llega a su fin y el usuario no ha adivinado el número, lanzar y manejar una
OutOfAttemptsException.
*/

public class Corre{
    public static void Main()
    {
        Random rnd = new Random(); int intentos = 0;int numero = rnd.Next(1,101); int intento;
        Console.Clear();
         Console.WriteLine("\n ---- Juego Adivina el Numero ---- ");
        do
        {
            try
            {
                if(intentos > 10)
                {
                    throw new OutOfAttemptsException("Usted ha excedido el numero de intentos Permitidos");
                }
                Console.WriteLine("Ingrese su intento: ");
                int.TryParse(Console.ReadLine(), out intento);

                if(intento < 1 || intento > 100){
                    throw new ArgumentOutOfRangeException("EL numero insertado está fuera de rango");
                }

                if(intento == numero){
                    Console.WriteLine("Felicidades, Usted lo ha adivinado");
                    break;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Usted ha Ingresado un número o algo que no está en el rango");
                Console.WriteLine("Ingrese algo para continuar");
                Console.ReadLine();
                continue;
            }
            catch (OutOfAttemptsException e)
            {
                Console.WriteLine($"Excepcion encotrada {e}");
                Console.WriteLine("Se ha acabado el juego");
                break;
                Console.ReadLine();
                continue;
            }

            
            intentos++;

        }while(true);



    }
}
class OutOfAttemptsException: Exception{
    public OutOfAttemptsException(string message): base(message)
    {

    }

}