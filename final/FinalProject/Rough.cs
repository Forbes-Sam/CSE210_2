
public class Rough : Job
{
    private bool _roughDone;
    private bool _trimDone;

    public Rough() : base()
    {
        _roughDone = false;
        _trimDone = false;
    }

    public void RoughMes()
    {}
    public void TrimMes()
    {}

    public override void DisplayJob()
    {
        Console.WriteLine($"{_address}:");
        Console.WriteLine($"    Cost: ${_cost}");
        Console.WriteLine($"    Employee: {_onTheJob}");
        if (_roughDone)
        {
            Console.WriteLine("Rough: Done");
        }
        else
        {
            Console.WriteLine("Rough: Not finished");
        }
        if (_trimDone)
        {
            Console.WriteLine("Trim: Done");
        }
        else
        {
            Console.WriteLine("Trim: Not finished");
        }
        Console.WriteLine( "    Items:");
        foreach (Item i in _neededItems)
        {
            Console.Write( "     ");
            i.Display();
        }

    }
}