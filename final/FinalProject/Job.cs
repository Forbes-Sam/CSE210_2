
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

    public void CreateJob()
    {
        Console.WriteLine("What is the address");
        _address = Console.ReadLine();

        Load load = new Load();
        List<Item> Inventory;
        List<Employs> employs;
        employs = load.LoadEmploys("employs.txt");
        Inventory = load.LoadInventory("inventory.txt");
        
        int itemToAdd = 1;
        while(itemToAdd != 0)
        {
            Console.WriteLine("0. quit");
            foreach (Item i in Inventory)
            {
                i.Display();
            }
            Console.Write("\nWhat item would you like to add: ");
            if (itemToAdd != 0)
            {
                string itemName = "";
                itemToAdd = int.Parse(Console.ReadLine());
                Console.Write("What quantity of items are needed for this: ");
                int quantityNeeded = int.Parse(Console.ReadLine());
                foreach (Item i in Inventory)
                {
                    if(i._itemNumber == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Item item = new Item(itemName,quantityNeeded,itemToAdd);
                _neededItems.Add(item);
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
            if (i._employsNum == whatNum)
            {
                _onTheJob = i;
            }
        }
    }

    public void AddMaterial()
    {
        Load load = new Load();
        List<Item> Inventory;
        Inventory = load.LoadInventory("inventory.txt");

        int itemToAdd = 1;
        while(itemToAdd != 0)
        {
            Console.WriteLine("0. quit");
            foreach (Item i in Inventory)
            {
                i.Display();
            }
            Console.Write("\nWhat item would you like to add: ");
            if (itemToAdd != 0)
            {
                string itemName = "";
                itemToAdd = int.Parse(Console.ReadLine());
                Console.Write("What quantity of items are needed for this: ");
                int quantityNeeded = int.Parse(Console.ReadLine());
                foreach (Item i in Inventory)
                {
                    if(i._itemNumber == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Item item = new Item(itemName,quantityNeeded,itemToAdd);
                _neededItems.Add(item);
            }
        }
        }

    public void Done()
    {
        _active = false;
    }

    public virtual void DisplayJob()
    {
        Console.Write($"{_address}:");
        Console.WriteLine($"    Cost: ${_cost}");
        Console.WriteLine($"Employee:");
        _onTheJob.Display();
        Console.WriteLine( "Items:");
        foreach (Item i in _neededItems)
        {
            Console.Write( "     ");
            i.Display();
        }
    }
}