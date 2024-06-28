public class Checklist : Goal
{
    protected int _secPoints;
    private int _counter;
    private int _totalCount;

    public int Counter { get; internal set; }

    public Checklist(int points, string title, string description, bool active, int secPoints, int totalCount)
    {
        _goalType = "Checklist";
        _pointVal = points;
        _title = title;
        _description = description;
        _active = active;
        _secPoints = secPoints;
        _counter = 0;
        _totalCount = totalCount;
    }

    public override string ValueToSave()
    {
        return $"{_goalType},{_pointVal},{_title},{_description},{_active},{_secPoints},{_counter},{_totalCount}";
    }

    public override void AddGoal()
    {
        base.AddGoal();
        Console.Write("How many times does this goal need to be accomplished for bonus points:");
        string i = Console.ReadLine();
        _totalCount = int.Parse(i);
        

        Console.Write("What is the bonus for accomplishing this goal?");
        string g = Console.ReadLine();
        _secPoints = int.Parse(g);

    }

    public override void Display(bool showActive)
    {
        base.Display(showActive);
        Console.Write($" -- Currently completed: {_counter}/{_totalCount}");
    }

    public override int AccomplishGoal()
    {
        if (_active)
        {
            _counter ++;
            if (_counter == _totalCount)
            {
                _active = false;
                return _pointVal + _secPoints;
            }
            else if (_counter < _totalCount)
            {
                return _pointVal;
            }
            return 0;
        }
        return 0;
    }
}