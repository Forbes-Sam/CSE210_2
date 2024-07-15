public class Employs
{
    private string _firstName;
    protected string _lastName;
    protected float _money;
    protected int _employsNum;
    private bool _contractor;
    private float _amountOwed;

    public Employs(string firstname, string lastname, float money, int employs, bool contractor, float amountOwed )
    {
        _firstName = firstname;
        _lastName = lastname;
        _money = money;
        _employsNum = employs;
        _contractor = contractor;
        _amountOwed = amountOwed;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{_employsNum}: {_firstName} {_lastName}, ${_money}");

        if (_contractor)
        {
            Console.WriteLine($"    ${_amountOwed}");
        }
    }
}