// A class to keep track of all of the employees and add or remove them
public class Employs
{
    private string _firstName;
    protected string _lastName;
    protected float _money;
    private int _employsNum;
    private bool _contractor;
    

    public Employs(string firstname, string lastname, float money, int employs, bool contractor )
    {
        _firstName = firstname;
        _lastName = lastname;
        _money = money;
        _employsNum = employs;
        _contractor = contractor;
    }
    public Employs()
    {
        _firstName = "";
        _lastName = "";
        _money = 0;
        _employsNum = 0;
        _contractor = false;
    }
    //Gets all of the information to fill in the employee class
    public void newEmploy()
    {
        Console.Write("What is there First Name: ");
        _firstName = Console.ReadLine();

        Console.Write("What is there Last Name: ");
        _lastName = Console.ReadLine();

        Console.Write("Are they a contractor (true,false): ");
        _contractor = bool.Parse(Console.ReadLine());
        if (_contractor)
        {
            Console.Write("What is there Rate per Job: $");
            _money = float.Parse(Console.ReadLine());
        }
        else
        {
            Console.Write("What is there hourly wage: $");
            _money = float.Parse(Console.ReadLine());
        }
        // finds the last employees ID number and adds a one to get the new ID number
        Load load = new Load();
        List<Employs> employs = load.LoadEmploys("employs.txt");
        _employsNum = (employs[employs.Count()]).GetID() + 1;
    }
    // Displays the employees information
    public void Display()
    {
        Console.WriteLine($"{_employsNum}: {_firstName} {_lastName}");
        


        if (_contractor)
        {
            Console.WriteLine($"${_money} per Job");
            Console.WriteLine($"Contractor");
        }
        else
        {
            Console.WriteLine($"Hourly rate: ${_money}");
        }
        
    }
    // Returns if the employee is a contractor or not as a bool
    public bool Contractor()
    {
        return _contractor;
    }
    // Returns a string used in the report.cs class to Write the report
    public string ReportDisplay()
    {return($"{_employsNum}: {_firstName} {_lastName}, ${_money}");}
    // Returns a string that is used in the save class to be saved in a txt file
    // Format can be a 1 or 2.
    // 1 is default and 2 is for when it is being saved inside another class like in Job.cs
    public string SaveFormat(int format)
    {
        if (format == 2)
        {
            return ($"{_firstName}:{_lastName}:{_money}:{_employsNum}:{_contractor}");
        }
        else
        {
            return ($"{_firstName},{_lastName},{_money},{_employsNum},{_contractor}");
        }
    }
    //Returns an ID so that the program can find the right employee
    public int GetID()
    {
        return _employsNum;
    }
}