using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("1. Load Journal");
        Console.WriteLine("2. New Journal");
        Console.Write("Choose an option: ");
        string startupChoice = Console.ReadLine();

        Journal myJournal = null;

        Dictionary<string, List<string>> promptLibrary = new Dictionary<string, List<string>>
            {
                { "gratitude", new List<string> {
                    "What are you grateful for today?",
                    "Who made your day better?",
                    "What's one thing you usually take for granted?"
                }},
                { "handOfGod", new List<string> {
                    "Where did you see the hand of God in your life today?",
                    "What quiet moment felt meaningful today?",
                    "What was unexpected but good?"
                }}
            };

        if (startupChoice == "1")
        {
            Console.Write("Enter filename to load from: ");
            string loadFile = Console.ReadLine();

            myJournal = new Journal("placeholder");
            myJournal.LoadFromFile(loadFile);
            Console.WriteLine($"Loaded journal with flavor: {myJournal._flavor}");

        }
        else if (startupChoice == "2")
        {
            Console.WriteLine("Choose a journal flavor:");
            Console.WriteLine("1. Gratitude Journal");
            Console.WriteLine("2. Hand of God Journal");
            Console.Write("Choice: ");
            string flavorChoice = Console.ReadLine();

            string selectedFlavor = flavorChoice == "1" ? "gratitude" : "handOfGod";
            myJournal = new Journal(selectedFlavor);
        }
        else
        {
            Console.WriteLine("Invalid startup choice.");
            return;
        }


        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display All Entries");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load different journal from File");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.AddEntry(promptLibrary);
                    break;
                case "2":
                    myJournal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
