using System.Security.AccessControl;

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

    public Employs WhoOnTheJob()
    {
        return _onTheJob;
    }
    public bool IsActive()
    {return _active;}
    public virtual void UpdateJob()
    {
        bool run = true;
        Console.Write("Did you finish the job (yes,no): ");
        string finished = Console.ReadLine();
        if (finished == "yes")
        {
            _active = false;
        }
        else
        {
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
                foreach (Item i in Inventory)
                {
                    if(i.ItemNum() == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Save save = new Save();
                save.saveInventory("Item.txt",Inventory);
                Item item = new Item(itemName,quantityNeeded,itemToAdd);
                bool notIn = true;
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
        _active = true;

        Console.Write("What is the cost in $");
        _cost = float.Parse(Console.ReadLine());

        employs = load.LoadEmploys("employs.txt");
        foreach (Employs i in employs)
        {
            i.Display();
        }
        Console.WriteLine("Which employ do you want on the job?");
        int whatNum = int.Parse(Console.ReadLine());
        foreach (Employs i in employs)
        {
            if (i.GetID() == whatNum)
            {
                _onTheJob = i;
            }
        }
    }

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
                foreach (Item i in Inventory)
                {
                    if(i.ItemNum() == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Save save = new Save();
                save.saveInventory("item.txt",Inventory);
                Item item = new Item(itemName,quantityNeeded,itemToAdd);
                bool notIn = true;
                foreach (Item i in _neededItems)
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

    public void Done()
    {
        _active = false;
    }

    public virtual void DisplayJob()
    {
        Console.WriteLine($"{_address}:");
        Console.WriteLine($"Cost: ${_cost}");
        Console.WriteLine($"Employee:");
        _onTheJob.Display();
        Console.WriteLine( "Items:");
        foreach (Item i in _neededItems)
        {
            Console.Write( "     ");
            i.Display();
        }
    }
    

    public virtual string SaveFormat()
    {
        string toReturn = ($"{_address},{_active},{_cost},{_onTheJob.SaveFormat(2)}");
        foreach (Item i in _neededItems)
        {
            toReturn = toReturn + "," + i.SaveFormat(2);
        } 
        return toReturn;
    }

    public virtual string ReportDisplay()
    {
        string toReturn = ($"{_address}: ${_cost}\nEmployee:\n{_onTheJob.ReportDisplay()}\n Items:\n");
        foreach (Item i in _neededItems)
        {
            toReturn = toReturn + i.ReportDisplay();
        } 
        return toReturn;
    }
}