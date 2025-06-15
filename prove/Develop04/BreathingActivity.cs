using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() 
        : base("Breathing", 
               "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        // Calculate how many full inhale/exhale cycles fit in the given duration (each is 10 seconds)
        int fullCycles = _duration / 10;

        for (int i = 0; i < fullCycles; i++)
        {
            Console.Write("Breathe in...");
            Countdown(4);

            Console.Write("Now breathe out...");
            Countdown(6);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($" {i}");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.Write("  \b\b");
    }
}
