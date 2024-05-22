using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        //Console.WriteLine($"{f1.GetTop()}/{f1.GetBottom()}");
        //Fraction f2 = new Fraction(6);
        //Console.WriteLine($"{f2.GetTop()}/{f2.GetBottom()}");
        //Fraction f3 = new Fraction(6,7);
        //Console.WriteLine($"{f3.GetTop()}/{f3.GetBottom()}");

        f1.SetTop(1);
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetDecimalValue()}");

        f1.SetTop(5);
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetDecimalValue()}");

        f1.SetTop(3);
        f1.SetBottom(4);
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetDecimalValue()}");

        f1.SetTop(1);
        f1.SetBottom(3);
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetDecimalValue()}");


    }
}