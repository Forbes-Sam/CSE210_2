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
    public void RemoveInv(int Remove, int ItemNum, List<Item> items)
    {
        foreach (Item item in items)
        {
            if (item._itemNumber == ItemNum)
            {
                item._quantity += Remove;
            }
        }
    }

    public void Display()
    {
        Console.WriteLine($"{_itemNumber}: {_item} {_quantity}");
    }
}