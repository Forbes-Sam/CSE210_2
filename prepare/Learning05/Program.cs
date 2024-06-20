using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("green", 5);
        Rectangle rectangle = new Rectangle("red", 4, 2);
        Circle circle = new Circle("pink", 1);
        List<Shape> shapes = [square, rectangle, circle];

        foreach(Shape shape in shapes)
        {
            shape.Print();
        }
        
    }
}