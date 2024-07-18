
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
                    if(i._itemNumber == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Save save = new Save();
                save.saveInventory("Item.txt",Inventory);
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
                    if(i._itemNumber == itemToAdd)
                    {
                        itemName = i.GetName();
                        i.RemoveInv(quantityNeeded);
                    }
                }
                Save save = new Save();
                save.saveInventory("item.txt",Inventory);
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

    public bool Remove(string address)
    {
        if (address.ToLower() == _address.ToLower())
        {
            return true;
        } 
        else return false;
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
}