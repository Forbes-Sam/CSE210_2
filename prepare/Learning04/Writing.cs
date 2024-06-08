class Writing : Assignment
{
    private string _title;
    
    public Writing(string name, string topic,string title)
    {
        _studentName = name;
        _topic = topic;
        _title = title;
    }

    public void GetWritingAssignment()
    {
        GetSummary();
        Console.WriteLine($"{_title}");
    }
}