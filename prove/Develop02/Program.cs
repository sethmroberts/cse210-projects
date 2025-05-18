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
                    "What's one thing you usually take for granted?",
                    "What made you smile unexpectedly today?",
                    "What ability or talent are you thankful for?",
                    "Who was kind to you today?",
                    "What's something small that brought you joy?",
                    "What recent challenge has made you stronger?",
                    "What is something you're glad you didn't lose today?",
                    "What comfort did you enjoy today (a warm meal, a bed, a friend)?",
                    "What part of nature did you notice and appreciate today?",
                    "What's one item you own that makes life easier?",
                    "What memory brought you happiness today?",
                    "What was your favorite moment of the day?",
                    "How did someone's words impact you positively today?"
                }}
                ,
                { "handOfGod", new List<string> {
                    "Where did you see the hand of God in your life today?",
                    "What quiet moment felt meaningful today?",
                    "What was unexpected but good?",
                    "Did you feel guided or protected at any point today?",
                    "Who did God place in your path today?",
                    "What did God remind you of today?",
                    "What prayer was answered — even in part?",
                    "Where did you feel peace that didn't make sense?",
                    "What opportunity today felt divinely timed?",
                    "Did a scripture or quote come to mind just when you needed it?",
                    "How did God help someone *through* you today?",
                    "What hardship today felt lighter than it should have?",
                    "What beauty or wonder felt sacred today?",
                    "Where did you feel God's love directly or indirectly?",
                    "How did you grow spiritually today — even in a small way?"
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
