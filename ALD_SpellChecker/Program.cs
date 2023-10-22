using SinglyLinkedList;
using System;
using System.IO;
using System.Text;

public class SpellChecker
{
    private SinglyLinkedList<string> referenceDictionary;

    // Constructor to initialize the reference dictionary
    public SpellChecker()
    {
        referenceDictionary = new SinglyLinkedList<string>();
        LoadDictionary();
    }

    // Load words from the "german.dic" file into the reference dictionary
    private void LoadDictionary()
    {
        try
        {
            // Read all lines from the dictionary file
            string[] words = File.ReadAllLines("..\\..\\..\\..\\SinglyLinkedList\\german.dic", Encoding.UTF8);

            foreach (var word in words)
            {
                // Add the word to the reference dictionary
                referenceDictionary.Add(word);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The dictionary file 'german.dic' was not found.");
        }
    }

    // Check spelling of the input sentence
    public void CheckSpelling(string inputSentence)
    {
        // Split the input sentence into words
        string[] words = inputSentence.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Console.ForegroundColor = ConsoleColor.White; // Reset console color

        foreach (var word in words)
        {
            // Change console color to red if word is not found in reference dictionary
            if (!referenceDictionary.Contains(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            // Print the word
            Console.Write(word + " ");

            Console.ForegroundColor = ConsoleColor.White; // Reset console color
        }

        Console.WriteLine(); // Print a newline for better formatting
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of SpellChecker
        SpellChecker spellChecker = new SpellChecker();

        // Read the user input
        Console.WriteLine("Please enter a sentence in German:");
        var inputSentence = Console.ReadLine();

        // Check the spelling of the input sentence
        spellChecker.CheckSpelling(inputSentence);
    }
}
