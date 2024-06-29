using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Some variables to help with the code
        Goal goal = new Goal();
        List<Goal> goals = [];
        int points = 0;
        int WhatDo = 0;

        while (WhatDo != 6)

        {
            // Adds a goal and saves it to the list
            Console.WriteLine();
            Console.WriteLine($"You have {points}\n");
            WhatDo = Menu();
            if (WhatDo == 1)
            {
                // Get the type of goal it is so that it can be set up correctly
                Console.WriteLine("Goal types");
                Console.WriteLine("   1. Simple Goal");
                Console.WriteLine("   2. Eternal Goal");
                Console.WriteLine("   3. Checklist Goal");
                Console.Write("What type of goal would you like to create: ");
                string i = Console.ReadLine();
                int type = int.Parse(i);
                Console.WriteLine();
                if (type == 1)
                {
                    Simple simple = new Simple(0, "", "", true);
                    simple.AddGoal();
                    goals.Add(simple);

                }
                else if (type == 2)
                {
                    Eternal eternal = new Eternal(0, "", "", true);
                    eternal.AddGoal();
                    goals.Add(eternal);
                }
                else if (type == 3)
                {
                    Checklist checklist = new Checklist(0, "", "", true, 0, 0);
                    checklist.AddGoal();
                    goals.Add(checklist);
                }
                // if they don't give a valid input just save it as a simple goal
                else
                {
                    Simple simple = new Simple(0, "", "", true);
                    simple.AddGoal();
                    goals.Add(simple);
                }
                Console.WriteLine();

            }
            // Show all the goals and if they are complete
            else if (WhatDo == 2)
            {
                goal.ShowAll(goals, true);
            }
            // saves the goals to a .txt file
            else if (WhatDo == 3)
            {
                goal.Save(goals);
            }
            // Load some Goals of a txt file
            else if (WhatDo == 4)
            {
                goal.Load(goals);
            }
            // Shows goals and asks which one you completed and add points
            else if (WhatDo == 5)
            {
                goal.ShowAll(goals, false);
                Console.Write("Which Goal did you accomplish: ");
                string s = Console.ReadLine();
                int remove = int.Parse(s);

                foreach(var goal1 in goals)
                {
                    int number = 1;
                    if (number == remove)
                    {
                        points += goal1.AccomplishGoal();
                    }
                    number ++;
                }
            }
            // exit message
            else if (WhatDo == 6)
            {
                Console.WriteLine("Good By");
            }
            // No valid input
            else
            {
                Console.WriteLine("Not a valid input");
            }

        }
    }
    //The menu
    static int Menu()
    {
        Console.WriteLine("Menu Options");
        Console.WriteLine("   1. Create new Goal");
        Console.WriteLine("   2. List Goals");
        Console.WriteLine("   3. Save Goals");
        Console.WriteLine("   4. Load Goals");
        Console.WriteLine("   5. Record Event");
        Console.WriteLine("   6. Quit");
        Console.Write("What do you want to do: ");
        string i = Console.ReadLine();
        return int.Parse(i);
    }


}