// ReflectionActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a fear.",
        "Think of a time when you made someone smile.",
        "Think of a time when you learned something the hard way.",
        "Think of a time when you acted with courage even when it was difficult.",
        "Think of a time when you stayed calm in a stressful situation."

    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What surprised you most about this experience?",
        "Would you do anything differently if you had to do it again?",
        "How did this shape your character or beliefs?",
        "What strengths did you discover in yourself?",
        "How might this help you handle future challenges?"

    };

    public ReflectionActivity() 
        : base("Reflection", 
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        PauseWithSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"> {question}");
            PauseWithSpinner(5);
        }

        DisplayEndingMessage();
    }
}