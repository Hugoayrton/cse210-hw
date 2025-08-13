using System;

public class Program
{
    public static void Main(string[] args)
    {
        // se añadieron animaciones más visuales con Countdown,
        // Spinner y prompts aleatorios para reflejar mejor la experiencia de mindfulness.
        while (true)
        {
            Console.WriteLine("Seleccione una actividad:");
            Console.WriteLine("1. Respiración");
            Console.WriteLine("2. Reflexión");
            Console.WriteLine("3. Listado");
            Console.WriteLine("4. Salir");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    continue;
            }

            activity.Run();
        }
    }
}
