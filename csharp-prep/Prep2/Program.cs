using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your Grade in the class? ");
        string StrGrade = Console.ReadLine();
        int NumGrade = int.Parse(StrGrade);

        string LetterGrade = "?";

        if (NumGrade >= 90)
        {
            LetterGrade = "A";
        }
        else if (NumGrade >= 80)
        {
            LetterGrade = "B";
        }
        else if (NumGrade >= 70)
        {
            LetterGrade = "C";
        }
        else if (NumGrade >= 60)
        {
            LetterGrade = "D";
        }
        else if (NumGrade < 60)
        {
            LetterGrade = "F";
        }

        Console.WriteLine($"Your Grade is a {LetterGrade}");

        if (NumGrade >= 70)
        {
            Console.WriteLine("You Passed the Class!!");
        }
        else
        {
            Console.WriteLine("Better Luck Next Time");
        }
        
    }
}