
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

    // Override with the original code from Job.cs allows you to change the status of Rough and Trim 
    public override void UpdateJob()
    {
        base.UpdateJob();
        if (_roughDone == false)
        {
            Console.Write("Did the Rough Get Finished(yes,no): ");
            string doWhat = Console.ReadLine();

            if (doWhat == "yes")
            {_roughDone = true;}
        }
        Console.Write("Did the Trim Get Finished(yes,no): ");
        string what = Console.ReadLine();
        if (what == "yes")
        {
            _trimDone = true;
        }

        

    }
    
    // Also an override with the original and allows you to add the company that requested the job
    public override void CreateJob()
    {
        base.CreateJob();
        Console.Write("What is the company name: ");
        _company = Console.ReadLine();
        _roughDone = false;
        _trimDone = false;
    }

    // Displays the Job
    public override void DisplayJob()
    {
        Console.WriteLine(_company);
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
    
    // Format that it is saved in
    public override string SaveFormat()
    {
        string toReturn = ($"Rough,{_address},{_active},{_cost},{_company},{_roughDone},{_trimDone},{_onTheJob.SaveFormat(2)}");
        foreach (Item i in _neededItems)
        {
            toReturn = toReturn + "," + i.SaveFormat(2);
        } 
        return toReturn;
    }

    // Format the report that is used in the report.
    public override string ReportDisplay()
    {
        string toReturn = ($"{_address}: ${_cost}\nEmployee:\n{_onTheJob.ReportDisplay()}\n ");
        if (_roughDone)
        {
            toReturn += ("Rough: Done\n");
        }
        else
        {
            toReturn += ("Rough: Not finished\n");
        }
        if (_trimDone)
        {
            toReturn += ("Trim: Done\n");
        }
        else
        {
            toReturn += ("Trim: Not finished\n");
        }
        toReturn += ("Items:\n");
        foreach (Item i in _neededItems)
        {
            toReturn = toReturn + i.ReportDisplay();
        } 
        return toReturn;
    }

}