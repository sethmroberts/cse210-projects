using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();

        int number = -1;
        while (number != 0)
        {
            
            Console.Write("Enter a list of numbers, type 0 when finished.");
            number = int.Parse(Console.ReadLine());
            
            if (number != 0)
            {
                numbers.Add(number);
            }

        }

        /* Compute sum, average, and max. */
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        /* Print results to the user. */
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is {max}");
    }

}