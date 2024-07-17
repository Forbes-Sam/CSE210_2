public class Save
{
    public void saveInventory(string filePath, List<Item> items)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Inventory(ItemNum,Item,Quantity)");
            foreach(Item i in items)
            {
                writer.WriteLine(i.SaveFormat());
            }
        Console.WriteLine("Text saved to file successfully!");
        }

    }

    public void saveEmploys(string filePath, List<Employs> employs)
    {

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Employs(EmploysNum,firstName,lastName,money,contractor,amountOwed)");
            foreach(Employs i in employs)
            {
                writer.WriteLine(i.SaveFormat());
            }
        Console.WriteLine("Text saved to file successfully!");
        }
    }
}