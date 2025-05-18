public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"\n{_date} \n{_prompt}: {_response}.");
    }
}

