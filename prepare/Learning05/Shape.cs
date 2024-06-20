public class Shape
{
    protected string _color;
    

    protected virtual double GetArea()
    {
        return 0;
    }

    public void Print()
    {
        Console.WriteLine($"{_color} area {GetArea()}");
    }

}