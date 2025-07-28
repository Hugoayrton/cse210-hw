using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Improvements made to meet the requirements:
* - The program now works with a library of scripts instead of just a fixed phrase.
* - It selects a random script to memorize, making the experience more varied.
* - The user can move on to the next script by typing 'next' or exit with 'quit'.
* - This helps to practice more scripts and makes the program more useful for memorization.
 */

class Word
{
    private string text;
    private bool isHidden;

    public Word(string word)
    {
        text = word;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public void Show()
    {
        isHidden = false;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        return isHidden ? "_____" : text;
    }
}

class Scripture
{
    private List<Word> words;

    public Scripture(string verseText)
    {
        words = verseText.Split(' ')
                         .Select(w => new Word(w))
                         .ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        Random rnd = new Random();

        var visibleWords = words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rnd.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public void ShowAllWords()
    {
        foreach (var word in words)
        {
            word.Show();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return string.Join(" ", words.Select(w => w.GetDisplayText()));
    }
}

class Program
{
    static void Main()
    {
        List<string> scriptures = new List<string>()
        {
            "For God so loved the world that he gave his only begotten Son",
            "I can do all things through Christ which strengtheneth me",
            "Trust in the Lord with all thine heart and lean not unto thine own understanding",
            "Be strong and of a good courage; be not afraid, neither be thou dismayed"
        };

        Random rnd = new Random();

        while (true)
        {
            Console.Clear();
            string selectedScripture = scriptures[rnd.Next(scriptures.Count)];
            Scripture scripture = new Scripture(selectedScripture);

            Console.WriteLine("Memorize this scripture:");

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress ENTER to hide more words, type 'next' for another scripture, or 'quit' to exit.");
                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    return; 
                }
                else if (input == "next")
                {
                    break; 
                }
                else
                {
                    scripture.HideRandomWords();

                    if (scripture.AllWordsHidden())
                    {
                        Console.WriteLine("\nAll words are hidden! Press 'next' to try another scripture or 'quit' to exit.");
                    }
                }
            }
        }
    }
}
