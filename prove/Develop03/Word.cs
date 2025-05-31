public class Word
{
    private string _text;
    private bool _visible;

    public Word(string text)
    {
        _text = text;
        _visible = true;
    }

    public string GetDisplayText()
    {
        if (_visible)
        {
            return _text;
        }
        else
        {
            return new string('_', _text.Length);
        }
    }

    public void Hide()
    {
        _visible = false;
    }

    public bool IsVisible()
    {
        return _visible;
    }
}
