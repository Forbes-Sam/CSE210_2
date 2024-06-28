public class Eternal : Goal
{
    public Eternal(int points, string title, string description, bool active)
    {
        
        _goalType = "Eternal";
        _pointVal = points;
        _title = title;
        _description = description;
        _active = active;
    }

    public override int AccomplishGoal()
    {
        return _pointVal;
    }
}