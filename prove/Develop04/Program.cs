using System;

class Program
{
    static void Main(string[] args)
    {

        //gets a value from the menu and then launches the proper activity.
        int Whatdo = 0;
        while (Whatdo != 4)
        {
            Whatdo = Menu();
            if (Whatdo == 1)
            {
                Breath breath = new Breath();
                breath.StartPhrase();
            }
            else if (Whatdo == 2)
            {
                Reflect reflect = new Reflect();
                reflect.StartPhrase();
            }
            else if (Whatdo == 3)
            {
                List list = new List();
                list.StartPhrase();
            }
            else if (Whatdo == 4)
            {
                Console.Clear();
                Console.WriteLine("GoodBy");
                
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            Console.Clear();

        }
    }

//The menu for everything
    static int Menu()
    {
        
        Console.WriteLine("Menu Option:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. quit");
        Console.Write("Select a choice from the menu: ");
        string t = Console.ReadLine();
        int num = int.Parse(t);
        return num;
    }
}