public class Item
{
    private string _item;
    public int _itemNumber;
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
    public void AddInv(int Add)
    {

        _quantity += Add;
    }
    public void RemoveInv(int Remove)
    {
        _quantity -= Remove;
    }

    public void Display()
    {
        Console.WriteLine($"{_itemNumber}: {_item} {_quantity}");
    }
    public string GetName()
    {
        return _item;
    }
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
}