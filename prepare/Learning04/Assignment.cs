using System.Reflection.Metadata.Ecma335;

public class Assignment
{
    protected string _studentName;
    protected string _topic;

    public void GetSummary()
    {
        Console.WriteLine($"{_studentName} - {_topic}");
    }
}