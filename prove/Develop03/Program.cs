using System;
using System.Formats.Tar;

class Program
{
    static void Main(string[] args)
    {
        Scripture scrip = new Scripture();
        scrip.AddWord();
        scrip.Display();
        string WhatDo = "Hi";
        bool Continue = true;
        while (WhatDo != "quit")
        {
            WhatDo = Console.ReadLine();
            Console.Clear();
            if (WhatDo == "reset")
            {
                scrip.Reset();
            }
            else if (Continue == false)
            {
                WhatDo = "quit";
            }
            else
            {
                Console.WriteLine("press enter to continue,'quit' to leave, 'reset' to start from the begging");
                Continue = scrip.RemoveWord();
            }
            scrip.Display();

        }
    }
}