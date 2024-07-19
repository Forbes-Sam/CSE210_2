public class Item
{
    private string _item;
    private int _itemNumber;
    private int _quantity;

    public Item(string item, int num, int itemNumber)
    {
        _item = item;
        _quantity = num;
        _itemNumber = itemNumber;
    }
    public Item()
    {
        _item = "";
        _quantity = 0;
        _itemNumber = 0;
    }
    // returns itemNum
    public int ItemNum()
    {
        return _itemNumber;
    }
    // return quantity
    public int Quantity()
    {
        return _quantity;
    }
    // creates a new item that is already in a list
    public void NewItem()
    {
        Console.Write("What is the items name: ");
        _item = Console.ReadLine();
        Console.Write("What is the quantity of this item: ");
        _quantity = int.Parse(Console.ReadLine());

        Load load = new Load();
        List<Item> items = load.LoadInventory("item.txt");
        int itemNum = items.Count() + 1;
        _itemNumber = itemNum;

    }
    // Adds to the quantity
    public void AddInv(int Add)
    {

        _quantity += Add;
    }
    // Removes from the quantity 
    public void RemoveInv(int Remove)
    {
        _quantity -= Remove;
    }
    // Displays the item
    public void Display()
    {
        Console.WriteLine($"{_itemNumber}: {_item} {_quantity}");
    }
    // gets the name
    public string GetName()
    {
        return _item;
    }
    // returns string in the save format
    public string SaveFormat(int format)
    {
        if (format == 2)
        {
            return ($"{_item}:{_quantity}:{_itemNumber}");
        }
        else
        {
        return ($"{_item},{_quantity},{_itemNumber}");
        }
    }
    // Returns a string with the report format
    public string ReportDisplay()
    {
        return ($"  {_itemNumber}: {_item} {_quantity}\n");
    }
}