
using System.Numerics;

public class Breath : Activity
{
    //sets up all the lists and variables for the breath activity
    public Breath()
    {
        _ActivityPrompt = "Breathing";
        _StartPrompt = "Welcome to the Breathing Activity \n\nThis activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _prompt = ["Breath in...." , "Breath out...."];
    }

    // overrides the start program
    public override void Start(int targetTimeInSeconds)
    {
        // gets timer all set up for breath in and out
        int totalTime = targetTimeInSeconds;
        int InTime = 4;
        int OutTime = 6;
        while (totalTime > 0)
        {
            // breath in for 4 seconds
            Console.Write("Breath in");
            while (InTime > 0)
            {
                Console.Write($" {InTime}\b\b");
                InTime--;
                totalTime--;
                Thread.Sleep(1000); // Wait for 1 second
            }
            InTime = 4;
            Console.WriteLine("...");

            // Breath out for 6 seconds
            Console.Write("Now Breath out");
            while (OutTime > 0)
            {
                Console.Write($" {OutTime}\b\b");
                OutTime--;
                totalTime--;
                Thread.Sleep(1000); // Wait for 1 second
            }
            Console.WriteLine("...\n");
            OutTime = 6;
        }
    }


}