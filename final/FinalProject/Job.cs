// This class is to save jobs that might be requested for by a consumer 
// It has a child class called rough
using System.ComponentModel.Design;

public class Job
{
    protected string _address;
    protected List<Item> _neededItems;
    protected bool _active;
    protected float _cost;
    protected Employs _onTheJob;

    public Job(string address, List<Item> items, bool active, float cost, Employs job)
    {
        _address = address;
        _neededItems = items;
        _active = active;
        _cost = cost;
        _onTheJob = job;
    }

    public Job()
    {
    }
    //returns the Employee on the job
    public Employs WhoOnTheJob()
    {
        return _onTheJob;
    }
    // returns whether the job is active or not as a bool
    public bool IsActive()
    {return _active;}
    // Updates existing jobs
    public virtual void UpdateJob()
    {
        // checks to see if you finished the job
        bool run = true;
        Console.Write("Did you finish the job (yes,no): ");
        string finished = Console.ReadLine();
        if (finished == "yes")
        {
            _active = false;
        }
        else
        {
            // allowes you to change cost items and which employee is on the job
            while (run)
            {
                Console.Clear();
                DisplayJob();
                Console.WriteLine();
                Console.WriteLine("Change: ");
                Console.WriteLine(" 0.Continue");
                Console.WriteLine(" 1.Cost");
                Console.WriteLine(" 2.Needed Items");
                Console.WriteLine(" 3.Employee");
                Console.Write("What do you want to do:");
                int whatDo = int.Parse(Console.ReadLine());
                
                if (whatDo == 1)
                {
                    Console.Write($"Your current cost is ${_cost} what would you like the new cost to be: ");
                    _cost = int.Parse(Console.ReadLine());
                }
                else if (whatDo == 2)
                {
                    AddMaterial();
                }
                //changes the employee on the job
                else if (whatDo == 3)
                {
                    Load load = new Load();
                    List<Employs> employs = load.LoadEmploys("employs.txt");
                    foreach (Employs E in employs)
                    {E.Display();}
                    Console.Write("What employee do you want to change the Job to: ");
                    int change = int.Parse(Console.ReadLine());
                    foreach (Employs e in employs)
                    {
                        if (e.GetID() == change)
                        {
                            _onTheJob = e;
                        }
                    }
                }
                else
                {run = false;}
            }
        }
    }
    // Creates new job that is already in a list
    public virtual void CreateJob()
    {
        Console.WriteLine("What is the address");
        _address = Console.ReadLine();

        Load load = new Load();
        List<Item> Inventory;
        List<Employs> employs;
        employs = load.LoadEmploys("employs.txt");
        Inventory = load.LoadInventory("item.txt");

        _neededItems = [];
        
        int itemToAdd = 1;
        while(itemToAdd != 0)
        {
            Console.WriteLine("0. quit");
            foreach (Item i in Inventory) // displays inventory
            {
                i.Display();
            }
            Console.Write("\nWhat item would you like to add: ");
            itemToAdd = int.Parse(Console.ReadLine());
            if (itemToAdd != 0)
            {
                string itemName = "";
                Console.Write("What quantity of items are needed for this: ");
                int quantityNeeded = int.Parse(Console.ReadLine()); // gets quantity
                foreach (Item i in Inventory) // removes inventory from the master list
                {
                    if(i.ItemNum() == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Save save = new Save();
                save.saveInventory("Item.txt",Inventory); // saves updated inventory
                Item item = new Item(itemName,quantityNeeded,itemToAdd);
                bool notIn = true;
                // Checks to see if item is already in the list and if it is it just adds the amount to the existing
                // item or if its not in the list it adds a new item
                foreach (Item i in _neededItems)
                {
                    if (i == item)
                    {
                        i.AddInv(quantityNeeded);
                        notIn = false;
                    }
                }
                if (notIn)
                {
                    _neededItems.Add(item);
                }
            }
        }
        // Sets job to active
        _active = true;
        // Gets cost
        Console.Write("What is the cost in $");
        _cost = float.Parse(Console.ReadLine());
        // displays the employees and adds one to the job
        employs = load.LoadEmploys("employs.txt");
        foreach (Employs i in employs)
        {
            i.Display();
        }
        Console.WriteLine("Which employ do you want on the job?");
        int whatNum = int.Parse(Console.ReadLine());
        foreach (Employs i in employs) //adds employee to the list
        {
            if (i.GetID() == whatNum)
            {
                _onTheJob = i;
            }
        }
    }

    // this is very similar to the inventory adder in CreateJob()
    public void AddMaterial()
    {
        Load load = new Load();
        List<Item> Inventory;
        Inventory = load.LoadInventory("item.txt");

        int itemToAdd = 1;
        while(itemToAdd != 0)
        {
            Console.WriteLine("0. quit");
            foreach (Item i in Inventory)
            {
                i.Display();
            }
            Console.Write("\nWhat item would you like to add: ");
            itemToAdd = int.Parse(Console.ReadLine());
            if (itemToAdd != 0)
            {
                string itemName = "";
                Console.Write("What quantity of items are needed for this: ");
                int quantityNeeded = int.Parse(Console.ReadLine());
                foreach (Item i in Inventory) // removes from master list
                {
                    if(i.ItemNum() == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Save save = new Save();
                save.saveInventory("item.txt",Inventory); // saves updated list
                Item item = new Item(itemName,quantityNeeded,itemToAdd);
                bool notIn = true;
                foreach (Item i in _neededItems) // checks if it is in list already and if not adds it
                {
                    if (i.ItemNum() == item.ItemNum())
                    {
                        i.AddInv(quantityNeeded);
                        notIn = false;
                    }
                }
                if (notIn)
                {
                    _neededItems.Add(item);
                }
            }
        }
    }
 
    // displays the Job
    public virtual void DisplayJob()
    {
        Console.WriteLine($"{_address}:");
        Console.WriteLine($"Cost: ${_cost}");
        Console.WriteLine($"Employee:");
        _onTheJob.Display();
        Console.WriteLine( "Items:");
        foreach (Item i in _neededItems) // Displays the items
        {
            Console.Write( "     ");
            i.Display();
        }
    }
    
    // returns a string that is formatted to how it is saved
    public virtual string SaveFormat()
    {
        string toReturn = ($"{_address},{_active},{_cost},{_onTheJob.SaveFormat(2)}");
        foreach (Item i in _neededItems)
        {
            toReturn = toReturn + "," + i.SaveFormat(2);
        } 
        return toReturn;
    }

    // returns a report on the item for the report document
    public virtual string ReportDisplay()
    {
        string toReturn = ($"{_address}: ${_cost}\nEmployee:\n{_onTheJob.ReportDisplay()}\n Items:\n");
        foreach (Item i in _neededItems) // adds the items to the string
        {
            toReturn = toReturn + i.ReportDisplay();
        } 
        return toReturn;
    }
}