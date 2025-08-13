using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration; 

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration()
    {
        Console.Write("Ingrese la duración en segundos: ");
        int.TryParse(Console.ReadLine(), out _duration);
    }

    public void StartMessage()
    {
        Console.WriteLine($"\n--- {_name} ---");
        Console.WriteLine(_description);
        SetDuration();
        Console.WriteLine("Prepárate para comenzar...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\n¡Buen trabajo!");
        ShowSpinner(3);
        Console.WriteLine($"Has completado la actividad {_name} durante {_duration} segundos.\n");
        ShowSpinner(3);
    }

    // Animación de ruleta/temporizador
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    public int GetDuration() => _duration;

    public string GetName() => _name;

    
    public abstract void Run();
}
