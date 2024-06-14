public class List : Activity
{
    public List()
    {
        _ActivityPrompt = "List";
        _StartPrompt = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompt = ["Who are people that you appreciate?" , "What are your personal strengths?" , "Who are the people that you have helped this week?" , "When have you felt the Holy Ghost this month?" , "Who are some of your personal heroes?"];
    }


    public override void Start(int targetTimeInSeconds)
    {
        int startTimer = 5;
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.Write("You may begin in: ");
        while (startTimer > 0)
        {
            Console.Write($"{startTimer}\b");
            Thread.Sleep(1000);
            startTimer --;
        }
        Console.WriteLine();
        Console.WriteLine($"{GetPrompt()}");

        int count = 0;

        BackgroundCountdown timer = new BackgroundCountdown(targetTimeInSeconds);
        timer.Start();

        bool WhileLoopEndCondition = true; // Flag to end the loop

        while (WhileLoopEndCondition)
        {
            Console.Write("> ");
            Console.ReadLine();
            count ++;
            WhileLoopEndCondition = timer.Running();

        }

        Console.WriteLine($"You listed {count} Items!");


    }
}