using System.Runtime.CompilerServices;

public class Square : Shape
{
    private double _side;

    public Square(string color, double side) 
    {
        _color = color;
        _side = side;
    }

    protected override double GetArea()
    {
        return _side * _side;
    }
}