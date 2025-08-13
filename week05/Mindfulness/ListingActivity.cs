using System;
using System.Threading;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string[] _prompts = {
        "¿Quiénes son las personas que aprecias?",
        "¿Cuáles son tus fortalezas personales?",
        "¿A quiénes has ayudado esta semana?",
        "¿Cuándo has sentido el Espíritu Santo este mes?",
        "¿Quiénes son algunos de tus héroes personales?"
    };

    public ListingActivity()
        : base("Actividad de Listado",
               "Esta actividad te ayudará a reflexionar sobre las cosas buenas de tu vida al hacerte enumerar tantas cosas como puedas en un área determinada")
    { }

    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];

        Console.WriteLine("\n" + prompt);
        Console.WriteLine("Comienza a listar elementos después de la cuenta regresiva:");
        Countdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"\n¡Excelente! Has listado {items.Count} elementos.");
        EndMessage();
    }
}
