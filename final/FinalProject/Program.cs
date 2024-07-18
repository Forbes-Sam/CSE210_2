class Program
{
    static void Main(string[] args)
    {
        Load load = new Load();
        Save save = new Save();
        List<Item> Inventory;
        List<Employs> employs;
        List <Job> jobs;
        bool run = true;

        while (run)
        {
            Inventory = load.LoadInventory("item.txt");
            employs = load.LoadEmploys("employs.txt");
            jobs = load.LoadJob("jobs.txt");

            Console.WriteLine("Menu");
            Console.WriteLine(" 1.Jobs");
            Console.WriteLine(" 2.Inventory");
            Console.WriteLine(" 3.Employs");
            Console.WriteLine(" 4.Generate report");
            Console.Write("What do you want to do: ");
            int whatDo = int.Parse(Console.ReadLine());
            Console.Clear();

            if (whatDo == 1)
            {
                Console.WriteLine("Job Menu");
                Console.WriteLine(" 1. View Jobs");
                Console.WriteLine(" 2. Add Job");
                Console.WriteLine(" 3. Remove Job");
                Console.Write("What do you want to do: ");
                int whatToDo = int.Parse(Console.ReadLine());
                Console.Clear();

                if (whatToDo == 1)
                {
                    DisplayJobs(jobs);
                }
                else if (whatToDo == 2)
                {
                    Console.Write("Is this a Rough/Trim(true, false):");
                    bool RT = bool.Parse(Console.ReadLine());
                    if (RT)
                    {
                        Rough rough = new Rough();
                        rough.CreateJob();
                        jobs.Add(rough);
                        save.SaveJobs("jobs.txt",jobs);
                    }
                    else
                    {
                        Job job = new Job();
                        job.CreateJob();
                        jobs.Add(job);
                        save.SaveJobs("jobs.txt", jobs);
                    }
                }
                else if (whatToDo == 3)
                {
                    DisplayJobs(jobs);
                    Console.Write("\nWhich job would you like to remove(number and street address): ");
                    string rem = Console.ReadLine();
                    for (int i = 0; jobs.Count() > i; i++)
                    {
                        if (jobs[i].Remove(rem))
                        {
                            Job jobRem = jobs[i];
                            jobs.Remove(jobRem);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input");
                }
            }
            else if (whatDo == 2)
            {
                Console.WriteLine("Inventory Menu");
                Console.WriteLine(" 1. View Inventory");
                Console.WriteLine(" 2. Add/Remove Inventory");
                Console.WriteLine(" 3. Add new Inventory");
                Console.Write("What do you want to do: ");
                int whatToDo = int.Parse(Console.ReadLine());
                Console.Clear();

                if (whatToDo == 1)
                {
                    DisplayItem(Inventory);
                }
                else if (whatToDo == 2)
                {
                    int quite = 1;
                    while (quite != 0)
                    {
                        DisplayItem(Inventory);
                        Console.WriteLine("0: quite");
                        Console.Write("What items quantity would you like to change: ");
                        quite = int.Parse(Console.ReadLine());
                        if (quite != 0)
                        {
                            Console.WriteLine("Add Inventory Menu");
                            Console.WriteLine(" 1. Add Inventory");
                            Console.WriteLine(" 2. Remove Inventory");
                            Console.Write("What do you want to do: ");
                            int RA = int.Parse(Console.ReadLine());
                            Console.Write("How Much: ");
                            int howMuch = int.Parse(Console.ReadLine());
                            if (RA == 1)
                            {
                                foreach (Item i in Inventory)
                                {i.AddInv(howMuch);}
                            }
                            else if (RA == 2)
                            {
                                foreach (Item i in Inventory)
                                {i.RemoveInv(howMuch);}
                            }
                        }
                    }

                }
                else if (whatToDo == 3)
                {
                    Item item = new Item();
                    item.NewItem();
                    Inventory.Add(item);
                    save.saveInventory("item.txt",Inventory);
                }
                else
                {
                    Console.WriteLine("Not a valid input");
                }
            }
            else if (whatDo == 3)
            {
                Console.WriteLine("Employees Menu");
                Console.WriteLine(" 1. View Employees");
                Console.WriteLine(" 2. Add Employees");
                Console.WriteLine(" 3. Remove Employees");
                Console.Write("What do you want to do: ");
                int whatToDo = int.Parse(Console.ReadLine());

                if (whatToDo == 1)
                {
                    DisplayEmploys(employs);
                }
                else if (whatToDo == 2)
                {
                    Employs employ = new Employs();
                    employ.newEmploy();
                    employs.Add(employ);
                    save.saveEmploys("employs.txt",employs);
                }
                else if (whatToDo == 3)
                {
                    DisplayEmploys(employs);
                    Console.WriteLine("Which employee would you like to remove: ");
                    int toRemove = int.Parse(Console.ReadLine());
                    for (int i = 0; employs.Count() > i;i++)
                    {
                        if (employs[i].GetID() == toRemove)
                        {
                            Employs e = employs[i];
                            employs.Remove(e);
                        }
                        save.saveEmploys("employs.txt",employs);
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input");
                }
            }
            else if (whatDo == 4)
            {}
            else if (whatDo == 5)
            {
                run = false;
            }
            else
            {
                Console.WriteLine("No Valid Input");
            }
        }

    }
    

    static void DisplayJobs(List<Job> jobs)
    {
        foreach (Job i in jobs)
        {
            i.DisplayJob();
            Console.WriteLine();
        }
    }
    static void DisplayEmploys(List<Employs> employs)
    {
        foreach (Employs i in employs)
        {
            i.Display();
            Console.WriteLine();
        }
    }
    static void DisplayItem(List<Item> Inventory)
    {
        foreach (Item i in Inventory)
        {
            i.Display();
        }
    }
    
    
}   