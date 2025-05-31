class Program
{
    static void Main(string[] args)
    {
        Scripture scripture;
        string scriptureFolder = "scriptures";
        if (Directory.Exists(scriptureFolder))
        {
            string[] files = Directory.GetFiles(scriptureFolder, "*.txt");
            if (files.Length > 0)
            {
                Random rand = new Random();
                string randomFile = files[rand.Next(files.Length)];
                Console.WriteLine($"Loading: {Path.GetFileName(randomFile)}");

                using (StreamReader reader = new StreamReader(randomFile))
                {
                    scripture = new Scripture(reader);
                }
            }
            else
            {
                Console.WriteLine("No scripture files found. Using default.\n");
                scripture = GetDefaultScripture();
            }
        }
        else
        {
            Console.WriteLine("Scripture folder not found. Using default.\n");
            scripture = GetDefaultScripture();
        }


        bool keepRunning = true;
        Console.Clear();
        scripture.Display();

        while (keepRunning && !scripture.AllWordsHidden())
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                keepRunning = false;
                break;
            }

            scripture.HideRandomWords();

            Console.Clear();
            scripture.Display();
        }

        if (scripture.AllWordsHidden())
        {
            Console.WriteLine("\nYou've memorized the scripture!");
        }
        else
        {
            Console.WriteLine("\nYou ended early. Come back soon to finish memorizing!");
        }
    }

    static Scripture GetDefaultScripture()
    {
        return new Scripture("Proverbs 3:5-6", new List<string> {
            "Trust in the Lord with all thine heart;",
            "and lean not unto thine own understanding.",
            "In all thy ways acknowledge him, and he shall direct thy paths."
        });
    }
}