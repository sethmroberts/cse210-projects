// MindfulnessActivity.cs
public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);

        int seconds;
        while (true)
        {
            Console.Write("Enter duration in seconds (must be a multiple of 10): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out seconds) && seconds > 0 && seconds % 10 == 0)
            {
                _duration = seconds;
                break;
            }
            Console.WriteLine("Please enter a valid number that is a multiple of 10.");
        }

        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        PauseWithSpinner(3);
    }

    public void PauseWithSpinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    public abstract void RunActivity();
}
