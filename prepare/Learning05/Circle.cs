 
 public class Circle : Shape
 {
    private double _radius;

    public Circle(string color, double radius)
    {
        _color = color;
        _radius = radius;
    }

    protected override double GetArea()
    {
        
        return Math.PI * _radius * _radius;
    }

}
