public class Simple : Goal
{
        public Simple(int points, string title, string description, bool active)
    {
        _goalType = "Simple";
        _pointVal = points;
        _title = title;
        _description = description;
        _active = active;
    }

    public override int AccomplishGoal()
    {
        if (_active)
        {
            _active = false;
            return _pointVal;
        }
        return 0;
    }
}