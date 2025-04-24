using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        // this is a program to compute the area of a circle

        // get the radius of a circle from the user
        Console.Write("please enter the radius: ");
        string text = Console.ReadLine();
        double radius = double.Parse(text);

        // compute the area of a circle
        double area = Math.PI * radius * radius;

        // display the area for the user to see.
        Console.WriteLine($"Area of the circle: {area}");
    }
}