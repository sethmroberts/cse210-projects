using System;
using System.Data.SqlTypes;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int number = PromptUserNumber();

        int squaredNumber = SquareNumber(number);

        DisplayResult(squaredNumber, name);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber() 
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }


    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;
        
        return squaredNumber;
    }


    static void DisplayResult(int squaredNumber, string name)
    {
        Console.WriteLine($"{name}, your favorite number squared is {squaredNumber}.");
    }
}