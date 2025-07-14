using System;
using System;
using System.Collections.Generic;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Fecha: {_date}");
        Console.WriteLine($"Pregunta: {_prompt}");
        Console.WriteLine($"Respuesta: {_response}");
        Console.WriteLine();
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void ShowEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
}

public class Program
{
    static void Main()
    {
        // motivated phrase
        Console.WriteLine("✨ Remember: 'The habit of journaling helps you understand yourself better every day.' ✨\n");

        Journal journal = new Journal();

        List<string> prompts = new List<string>()
        {
            "¿Cuál fue la mejor parte de tu día?",
            "¿Qué te hizo sonreír hoy?",
            "¿Qué aprendiste hoy?",
            "¿A quién ayudaste hoy?",
            "¿Qué agradeces hoy?"
        };

        Random random = new Random();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Escribir una nueva entrada");
            Console.WriteLine("2. Mostrar todas las entradas");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string date = DateTime.Now.ToShortDateString();
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine(prompt);
                    Console.Write("Tu respuesta: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entrada guardada.\n");
                    break;

                case "2":
                    Console.WriteLine("\nTodas las entradas del diario:\n");
                    journal.ShowEntries();
                    break;

                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intenta de nuevo.\n");
                    break;
            }
        }
    }
}
