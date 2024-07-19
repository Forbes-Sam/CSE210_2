class Program
{
    static void Main(string[] args)
    {
        // variables used throughout the program
        Load load = new Load();
        Save save = new Save();
        Password password = new Password();
        List<Item> Inventory;
        List<Employs> employs;
        List <Job> jobs;
        // variables for the intial username and password section
        bool run = false;
        bool correctUserName = false;
        int passwordCounter = 1;
        // Loops until you get username and password correct or run out of tries
        while (!run)
        {
            // infinite loop if you get password wrong 5 times
            while (passwordCounter > 5)
            {}
            // checks user inputted username with the username stored in password.cs
            if (!correctUserName)
            {
                Console.Write("Username(username):");
                correctUserName = password.CheckUserName(Console.ReadLine());
            }
            // checks the password the user inputted with the one stored in password.cs
            else if (correctUserName)
            {
                Console.Write("Password(password):");
                run = password.CheckPassword(Console.ReadLine());
                passwordCounter++;
            }
            
        }
        Console.Clear();

        // The main Loop
        while (run)
        {
            // loads the saved values
            Inventory = load.LoadInventory("item.txt");
            employs = load.LoadEmploys("employs.txt");
            jobs = load.LoadJob("jobs.txt");
            //The main Menu
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine(" 0.quit");
            Console.WriteLine(" 1.Jobs");
            Console.WriteLine(" 2.Inventory");
            Console.WriteLine(" 3.Employs");
            Console.WriteLine(" 4.Generate report");
            Console.Write("What do you want to do: ");
            int whatDo = int.Parse(Console.ReadLine());
            Console.Clear();

            // the main menu for jobs
            if (whatDo == 1)
            {
                Console.WriteLine("Job Menu");
                Console.WriteLine(" 1. View Jobs");
                Console.WriteLine(" 2. Add Job");
                Console.WriteLine(" 3. Remove Job");
                Console.Write("What do you want to do: ");
                int whatToDo = int.Parse(Console.ReadLine());
                Console.Clear();

                // allows the user to view all jobs and update them
                if (whatToDo == 1)
                {
                    DisplayJobs(jobs);
                    Console.WriteLine("0.Quite");
                    Console.Write("What Job do you want to update: ");
                    int jobToUpdate = int.Parse(Console.ReadLine());
                    Console.Clear();
                    jobs[jobToUpdate].UpdateJob();
                    save.SaveJobs("jobs.txt",jobs);
                }
                // allows the user to add jobs
                else if (whatToDo == 2)
                {
                    Console.Write("Is this a Rough/Trim(true, false):");
                    bool RT = bool.Parse(Console.ReadLine()); // RT is rough trim
                    // job for new houses
                    if (RT)
                    {
                        Rough rough = new Rough();
                        rough.CreateJob();
                        jobs.Add(rough);
                        save.SaveJobs("jobs.txt",jobs);
                    }
                    // regular job
                    else
                    {
                        Job job = new Job();
                        job.CreateJob();
                        jobs.Add(job);
                        save.SaveJobs("jobs.txt", jobs);
                    }
                }
                // remove a job
                else if (whatToDo == 3)
                {
                    DisplayJobs(jobs);
                    Console.Write("\nWhich job would you like to remove: ");
                    int rem = int.Parse(Console.ReadLine());
                    for (int i = 0; jobs.Count() > i; i++)
                    {
                        if (i == rem)
                        {
                            Job j = jobs[i];
                            jobs.Remove(j);
                        }
                    }
                    save.SaveJobs("jobs.txt", jobs);
                }
                else
                {
                    Console.WriteLine("Not a valid input");
                }
            }
            // Inventory menu
            else if (whatDo == 2)
            {
                Console.WriteLine("Inventory Menu");
                Console.WriteLine(" 1. View Inventory");
                Console.WriteLine(" 2. Add/Remove Inventory");
                Console.WriteLine(" 3. Add new Inventory");
                Console.Write("What do you want to do: ");
                int whatToDo = int.Parse(Console.ReadLine());
                Console.Clear();

                // view inventory and wait until user presses enter
                if (whatToDo == 1)
                {
                    Console.Clear();
                    DisplayItem(Inventory);
                    Console.Write("enter to continue");
                    string i = Console.ReadLine();
                }
                //Add or remove inventory
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
                            int RA = int.Parse(Console.ReadLine()); // RA remove or add
                            Console.Write("How Much: ");
                            int howMuch = int.Parse(Console.ReadLine());

                            // Add inventory
                            if (RA == 1)
                            {
                                foreach (Item i in Inventory)
                                {
                                    if (i.ItemNum() == quite)
                                    {
                                        i.AddInv(howMuch);
                                    }
                                }
                            }
                            //Remove inventory
                            else if (RA == 2)
                            {
                                foreach (Item i in Inventory)
                                {
                                    if (i.ItemNum() == quite)
                                    {
                                        i.RemoveInv(howMuch);
                                    }
                                }
                            }
                        }
                    }

                }
                // Add a new item to the inventory list
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
            // Employees menu
            // realized i spelled employees wrong and that i spelled it employs (sorry)
            else if (whatDo == 3)
            {
                Console.WriteLine("Employees Menu");
                Console.WriteLine(" 1. View Employees");
                Console.WriteLine(" 2. Add Employees");
                Console.WriteLine(" 3. Remove Employees");
                Console.Write("What do you want to do: ");
                int whatToDo = int.Parse(Console.ReadLine());

                // View all employees
                if (whatToDo == 1)
                {
                    Console.Clear();
                    DisplayEmploys(employs);
                    Console.Write("enter to continue");
                    string i = Console.ReadLine();
                }
                // Add a new Employee
                else if (whatToDo == 2)
                {
                    Employs employ = new Employs();
                    employ.newEmploy();
                    employs.Add(employ);
                    save.saveEmploys("employs.txt",employs);
                }
                // Remove an employee
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
            // Generate a report found in the report.txt file
            else if (whatDo == 4)
            {
                Report report = new Report();
                report.CreateList();
            }
            // quit
            else if (whatDo == 0)
            {
                run = false;
            }
            else
            {
                Console.WriteLine("No Valid Input");
            }
        }
    }
    
    // ****display functions****//
    //displays the Jobs for the main file
    static void DisplayJobs(List<Job> jobs)
    {
        int n = 0;
        foreach (Job i in jobs)
        {
            Console.Write($"{n}. ");
            n ++;
            i.DisplayJob();
            Console.WriteLine();
        }
    }
    //displays the employees for the main file
    static void DisplayEmploys(List<Employs> employs)
    {
        foreach (Employs i in employs)
        {
            i.Display();
            Console.WriteLine();
        }
    }
    // Displays the Items for the main File
    static void DisplayItem(List<Item> Inventory)
    {
        foreach (Item i in Inventory)
        {
            i.Display();
        }
    }
       
}   