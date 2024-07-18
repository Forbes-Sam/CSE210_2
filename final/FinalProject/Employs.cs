using System.Diagnostics.Contracts;

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
        Load load = new Load();
        List<Employs> employs = load.LoadEmploys("employs.txt");
        _employsNum = (employs[employs.Count()]).GetID() + 1;
    }
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
    public bool Contractor()
    {
        return _contractor;
    }
    public string ReportDisplay()
    {return($"{_employsNum}: {_firstName} {_lastName}, ${_money}");}

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

    public int GetID()
    {
        return _employsNum;
    }
}