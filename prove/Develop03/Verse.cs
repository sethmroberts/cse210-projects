class Verse
{
    private List<Word> _words;

    public Verse(string text)
    {
        _words = new List<Word>();
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void Display()
    {
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWord(Random rand)
    {
        List<Word> visibleWords = _words.FindAll(w => w.IsVisible());
        if (visibleWords.Count > 0)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsVisible())
            {
                return false;
            }
        }
        return true;
    }
}