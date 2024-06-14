using System.Security.Cryptography.X509Certificates;

public class Reflect : Activity
{
    //set up
    private List<string> _question;

    public Reflect()
    {
        _ActivityPrompt = "Reflect";
        _StartPrompt = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompt = ["Think of a time when you stood up for someone else." , "Think of a time when you did something really difficult." , "Think of a time when you helped someone in need." , "Think of a time when you did something truly selfless."];
        _question = ["Why was this experience meaningful to you?" , "Have you ever done anything like this before?" , "How did you get started?" , "How did you feel when it was complete?" , "What made this time different than other times when you were not as successful?" , "What is your favorite thing about this experience?" , "What could you learn from this experience that applies to other situations?" , "What did you learn about yourself through this experience?" , "How can you keep this experience in mind in the future?"];

    }


    // main part of the reflect activity
    public override void Start(int targetTimeInSeconds)
    {
        // informs the user whats happening
        int startTimer = 5;
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {GetPrompt()} ---\n");
        Console.Write("When you have something in mind press enter");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience. ");
        Console.Write("You may begin in: ");
        //simple timer
        while (startTimer > 0)
        {
            Console.Write($"{startTimer}\b");
            Thread.Sleep(1000);
            startTimer --;
        }
        Console.Clear();

        // reflect part of the activity
        while (targetTimeInSeconds > 0)
        {
            Console.Write($"> {GetRanQuestion()} ");
            Animation(10);
            Console.WriteLine();
            targetTimeInSeconds -= 10;
        }
    }

    //gets random question for the user
    public string GetRanQuestion()
    {
        Random ran = new Random();
        int num = ran.Next(0, _question.Count);
        return _question[num];
    }
}