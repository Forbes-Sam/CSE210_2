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

    public void AddInv(int Add, int ItemNum, List<Item> items)
    {
        foreach (Item item in items)
        {
            if (item._itemNumber == ItemNum)
            {
                item._quantity += Add;
            }
        }
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
    public string SaveFormat()
    {return ($"{_itemNumber},{_item},{_quantity}");}
}