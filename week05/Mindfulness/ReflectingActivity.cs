using System;
using System.Threading;

public class ReflectingActivity : Activity
{
    private string[] _prompts = {
        "Piensa en una ocasión en la que defendiste a otra persona.",
        "Piensa en una ocasión en la que hiciste algo realmente difícil.",
        "Piensa en una ocasión en la que ayudaste a alguien necesitado.",
        "Piensa en una ocasión en la que hiciste algo verdaderamente desinteresado."
    };

    private string[] _questions = {
        "¿Por qué fue significativa esta experiencia para usted?",
        "¿Alguna vez has hecho algo parecido?",
        "¿Cómo empezaste?",
        "¿Cómo te sentiste cuando lo terminaste?",
        "¿Qué hizo que esta vez fuera diferente a otras cuando no tuviste tanto éxito?",
        "¿Qué es lo que más te gusta de esta experiencia?",
        "¿Qué podrías aprender de esta experiencia que pueda aplicarse a otras situaciones?",
        "¿Qué aprendiste sobre ti mismo a través de esta experiencia?",
        "¿Cómo puedes mantener esta experiencia en la mente en el futuro?"
    };

    public ReflectingActivity()
        : base("Actividad de Reflexión",
               "Esta actividad te ayudará a reflexionar sobre los momentos de tu vida en los que has demostrado fortaleza y resiliencia. Esto te ayudará a reconocer el poder que tienes y cómo puedes usarlo en otros aspectos de tu vida")
    { }

    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        int elapsed = 0;

        while (elapsed < GetDuration())
        {
            string prompt = _prompts[rand.Next(_prompts.Length)];
            Console.WriteLine("\n" + prompt);
            Countdown(3);

            foreach (string question in _questions)
            {
                if (elapsed >= GetDuration()) break;
                Console.WriteLine("- " + question);
                ShowSpinner(2);
                elapsed += 4;
            }
        }

        EndMessage();
    }
}
