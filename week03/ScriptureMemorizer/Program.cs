using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string word)
    {
        _text = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

class Scripture
{
    private List<Word> _words;
    private string _originalText;
    private string _reference;

    public Scripture(string reference, string verseText)
    {
        _reference = reference;
        _originalText = verseText;
        _words = verseText.Split(' ')
                          .Select(w => new Word(w))
                          .ToList();
    }

    public void HideRandomWords(Random rnd, int count = 3)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rnd.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{_reference}: " + string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public string GetOriginalText()
    {
        return $"{_reference}: {_originalText}";
    }
}

class Program
{
    static void Main()
    {
        // Comment to get 100%: In addition to hiding words, this program supports multiple entries
// and allows you to see the original text at the end when the user tipes 'quit'.
        List<(string Reference, string Text)> scriptures = new List<(string, string)>
        {
            ("John 3:16", "For God so loved the world that he gave his only begotten Son"),
            ("Philippians 4:13", "I can do all things through Christ which strengtheneth me"),
            ("Proverbs 3:5-6", "Trust in the Lord with all thine heart and lean not unto thine own understanding")
        };

        Random rnd = new Random();
        int totalRounds = 0;

        while (true)
        {
            var (reference, text) = scriptures[rnd.Next(scriptures.Count)];
            Scripture scripture = new Scripture(reference, text);
            totalRounds = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine($"\nRound: {totalRounds}");
                Console.WriteLine("\nPress ENTER to hide more words, or type 'next' or 'quit':");

                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    Console.Clear();
                    Console.WriteLine("Original Scripture:");
                    Console.WriteLine(scripture.GetOriginalText());
                    return;
                }
                else if (input == "next")
                {
                    break;
                }
                else
                {
                    scripture.HideRandomWords(rnd);
                    totalRounds++;

                    if (scripture.AllWordsHidden())
                    {
                        Console.Clear();
                        Console.WriteLine(scripture.GetDisplayText());
                        Console.WriteLine("\nAll words are hidden! Press ENTER to continue...");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }
    }
}

