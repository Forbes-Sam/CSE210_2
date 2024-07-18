
public class Rough : Job
{
    private string _company;
    private bool _roughDone;
    private bool _trimDone;

    public Rough(string company, bool rough, bool trim, string address, List<Item> items, bool active, float cost, Employs job) : base()
    {
        _address = address;
        _neededItems = items;
        _active = active;
        _cost = cost;
        _onTheJob = job;
        _company = company;
        _roughDone = rough;
        _trimDone = trim;
    }
    public Rough()
    {}

    public override void CreateJob()
    {
        base.CreateJob();
        Console.Write("What is the company name: ");
        _company = Console.ReadLine();
        _roughDone = false;
        _trimDone = false;
    }

    public override void DisplayJob()
    {
        Console.WriteLine($"{_address}:");
        Console.WriteLine($"Cost: ${_cost}");
        _onTheJob.Display();
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
    public override string SaveFormat()
    {
        string toReturn = ($"Rough,{_address},{_active},{_cost},{_company},{_roughDone},{_trimDone},{_onTheJob.SaveFormat(2)}");
        foreach (Item i in _neededItems)
        {
            toReturn = toReturn + "," + i.SaveFormat(2);
        } 
        return toReturn;
    }

}