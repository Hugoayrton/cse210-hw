using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Actividad de Respiración", 
               "Esta actividad te ayudará a relajarte caminando mientras inhalas y exhalas lentamente. Despeja tu mente y concéntrate en tu respiración")
    { }

    public override void Run()
    {
        StartMessage();

        int elapsed = 0;
        while (elapsed < GetDuration())
        {
            Console.WriteLine("Inhala...");
            Countdown(3);
            elapsed += 3;

            if (elapsed >= GetDuration()) break;

            Console.WriteLine("Exhala...");
            Countdown(3);
            elapsed += 3;
        }

        EndMessage();
    }
}
