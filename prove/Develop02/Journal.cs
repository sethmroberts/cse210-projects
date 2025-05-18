using System.IO.Enumeration;

public class Journal
{
    public List<Entry> _entries;
    public string _flavor;

    public Journal(string flavor)
    {
        _flavor = flavor;
        _entries = new List<Entry>();
    }

    public void AddEntry(Dictionary<string, List<string>> promptLibrary)
    {
        List<string> prompts = promptLibrary[_flavor];
        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];

        string date = DateTime.Now.ToString("yyyy-MM-dd");


        Console.WriteLine($"Prompt: {selectedPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry
        {
            _date = date,
            _prompt = selectedPrompt,
            _response = response
        };

        _entries.Add(newEntry);
    }


    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }


public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"FLAVOR={_flavor}");
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}~{entry._prompt}~{entry._response}");
            }
        }
    }


    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        if (lines[0].StartsWith("FLAVOR="))
        {
            _flavor = lines[0].Substring(7);
        }
        else
        {
            Console.WriteLine("Missing flavor info in file. Defaulting to 'gratitude'.");
            _flavor = "gratitude";
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("~");

            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _prompt = parts[1],
                    _response = parts[2]
                };

                _entries.Add(entry);
            }
        }
    }
}