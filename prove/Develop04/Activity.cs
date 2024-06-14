public class Activity
{
    protected string _StartPrompt;
    protected List<string> _prompt;
    protected string _ActivityPrompt;

    // this is the function that runs the main part of each program
    public void StartPhrase()
    {
        //starting part of the activity
        Console.Clear();
        Console.WriteLine($"Welcome to the {_ActivityPrompt} Activity.\n");
        Console.WriteLine($"{_StartPrompt}\n");
        
        //gets the time from the user
        Console.Write("How long, in seconds would you like for your session: ");
        string t = Console.ReadLine();
        int Time = int.Parse(t);

        Console.WriteLine("Get ready...");
        Animation(5);

        //starts the actual activity 
        //start(time) is diffrent for every activity
        Console.WriteLine("\n\n");
        Start(Time);

        //end of the activity
        Console.WriteLine("\n");
        Console.WriteLine("Well Done!!");
        Console.WriteLine($"You have finished another {Time} Sec of the {_ActivityPrompt} Activity");
        Animation(5);
        
    }
    
    // A blank class to be changed by all of the children classes
    public virtual void Start(int targetTimeInSeconds)
    {}

    // a simple spinner animation
    public void Animation(int readyTimer)
    {
        int delay = 250;
        while (readyTimer > 0)
        {
            Console.Write("/\b");
            Thread.Sleep(delay);
            Console.Write("-\b");
            Thread.Sleep(delay);
            Console.Write("\\\b");
            Thread.Sleep(delay);
            Console.Write("|\b");
            Thread.Sleep(delay);
            readyTimer -- ;
        }
    }
    
    //retrieves random prompt from the _prompt list
    protected string GetPrompt()
    {
        Random ran = new Random();
        int num = ran.Next(0, _prompt.Count);
        return _prompt[num];
    }

}