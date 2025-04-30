using System;
using System.Formats.Asn1;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,101);

        int guess = 0;
        string input = "";
        List<int> guesses = new List<int>();
        Console.WriteLine("Please guess the magic number.");

        while (guess != number)
        {
            Console.Write("What is your guess? ");
            input = Console.ReadLine();
            guess = int.Parse(input);
            guesses.Add(guess);
            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
        }

        Console.WriteLine($"Well done! You guessed the magic number in {guesses.Count} guesses!");
    }
}