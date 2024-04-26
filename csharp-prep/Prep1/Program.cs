using System;

class Program
{
    static void Main(string[] args)
    {
        string first;
        string last;

        Console.Write("What is your first name? ");
        first = Console.ReadLine();

        Console.Write("What is your last name? ");
        last = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Your Name is {last}, {first} {last}");
    }
}