public class Load
{
    public List<Item> _inventory;


    public List<Item> LoadInventory(string filePath)
    {
    List<Item> items = new List<Item>();

        // Read all lines from the text file
        string[] lines = File.ReadAllLines(filePath);

        // Skip the header line (assuming the first line has column names)
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // Split the line into comma-separated values
            string[] parts = line.Split(',');

            // Extract item name, item number, and quantity
            string itemName = parts[0];
            int itemNumber = int.Parse(parts[1]);
            int quantity = int.Parse(parts[2]);

            // Create a new Item object and add it to the list
            items.Add(new Item(itemName, quantity, itemNumber));
        }

        return items;
    }

    public List<Employs> LoadEmploys(string filePath)
    {
    List<Employs> employs = new List<Employs>();

        // Read all lines from the text file
        string[] lines = File.ReadAllLines(filePath);

        // Skip the header line (assuming the first line has column names)
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // Split the line into comma-separated values
            string[] parts = line.Split(',');

            // Extract item name, item number, and quantity
            int employsNum = int.Parse(parts[0]);
            string firstname = parts[1];
            string lastname = parts[2];
            float money = float.Parse(parts[3]);
            bool contractor = bool.Parse(parts[4]);
            float amountOwed = float.Parse(parts[5]);

            // Create a new Item object and add it to the list
            employs.Add(new Employs(firstname,lastname,money,employsNum,contractor,amountOwed));
        }

        return employs;
    }

}