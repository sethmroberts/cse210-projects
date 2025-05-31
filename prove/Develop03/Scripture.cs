public class Scripture
{
    private Reference _reference;
    private List<Verse> _verses;

    public Scripture(string referenceText, List<string> verses)
    {
        _reference = new Reference(referenceText);
        _verses = new List<Verse>();
        foreach (string verse in verses)
        {
            _verses.Add(new Verse(verse));
        }
    }

    public Scripture(StreamReader reader)
    {
        _reference = new Reference(reader.ReadLine());
        _verses = new List<Verse>();
        while (!reader.EndOfStream)
        {
            _verses.Add(new Verse(reader.ReadLine()));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        foreach (Verse verse in _verses)
            verse.Display();
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        foreach (Verse verse in _verses)
            verse.HideRandomWord(rand);
    }
    
        public bool AllWordsHidden()
    {
        foreach (Verse verse in _verses)
        {
            if (!verse.AllWordsHidden())
                return false;
        }
        return true;
    }
}
