using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("What is your grade percentage? ");
        string gradeStringPercentage = Console.ReadLine();
        int gradeIntPercentage = int.Parse(gradeStringPercentage);
        int gradeSecondNumber = gradeIntPercentage % 10;

        string grade = "";
        string gradeSign = "";
        if (gradeIntPercentage >= 90)
            {
                grade = "A";
            }
        else if (gradeIntPercentage >= 80)
            {
                grade = "B";
            }
        else if (gradeIntPercentage >= 70)
            {
                grade = "C";
            }
        else if (gradeIntPercentage >= 60)
            {
                grade = "D";
            }
        else
            {
                grade = "F";
            }

        if (gradeSecondNumber >= 7)
            {
                gradeSign = "+";
            }
        else if (gradeSecondNumber < 3)
            {
                gradeSign = "-";
            }
        Console.WriteLine($"Your grade is {grade}{gradeSign}");

        if (gradeIntPercentage >= 70)
            {
                Console.WriteLine("Good job! You passed!");
            }
        else
            {
                Console.WriteLine("I'm sorry, you didn't pass, good luck next time!");
            }
    }
}