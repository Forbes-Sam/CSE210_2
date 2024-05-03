using System;

class Program
{
    static void sfDisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string sfPromptUserName ()
    {
        string sfName;
        Console.Write("Please enter your Name: ");
        sfName = Console.ReadLine();
        return sfName;
    }

    static int sfPromptUserNumber ()
    {
        string sfNumStr;
        int sfNum;
        Console.Write("Please enter your favorite number: ");
        sfNumStr = Console.ReadLine();
        sfNum = int.Parse(sfNumStr);
        return sfNum;
    }

    static int sfSquareNumber (int sfNum)
    {
        int sfNumReturn;
        sfNumReturn = sfNum * sfNum;
        return sfNumReturn;
    }

    static void sfDisplayResult (string sfName, int sfNum )
    {
        Console.WriteLine($"{sfName}, the square of your number is {sfNum}");
    }

    static void Main(string[] args)
    {
        string sfUser;
        int sfNum;

        sfDisplayWelcome();
        sfUser = sfPromptUserName();
        sfNum = sfPromptUserNumber();
        sfNum = sfSquareNumber(sfNum);
        sfDisplayResult(sfUser,sfNum);

    }
}