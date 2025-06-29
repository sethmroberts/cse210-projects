using System.Drawing;

public abstract class Shape
{
    // private string _color;

    public Shape(string color)
    {
        Color = color;
    }

    public string Color { get; set; }

    public abstract double GetArea();
}

public class Square : Shape
{
    public double Side { get; set; }

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }
}

public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(string color, double width, double side) : base(color)
    {
        Length = Length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width;
    }
}