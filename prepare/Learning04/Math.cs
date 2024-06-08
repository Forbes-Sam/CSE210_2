using System.Diagnostics.Contracts;

public class Math : Assignment
{
    protected string _textbookSection;
    protected string _problems;

public Math(string name, string topic, string book, string problem)
{
    _studentName = name;
    _topic = topic;
    _textbookSection = book;
    _problems = problem;
}

    public void GetHomeworkList()
    {
        GetSummary();
        Console.WriteLine($"Section {_textbookSection} Problems {_problems}");
    }
}