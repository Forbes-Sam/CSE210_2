using System.Threading.Tasks.Dataflow;

class Resume
{
    public string _sfName;
    public List<Job> _sfJobs;

    public void Display()
    {
        Console.WriteLine($"{_sfName}");

        for (int i = 0;i < _sfJobs.Count;i++ )
        {
            Job sfJobs = _sfJobs[i];
            sfJobs.Display();

        }
    }
}