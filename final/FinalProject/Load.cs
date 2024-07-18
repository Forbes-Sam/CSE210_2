using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

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
            int quantity = int.Parse(parts[1]);
            int itemNumber = int.Parse(parts[2]);
            

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
            
            string firstname = parts[0];
            string lastname = parts[1];
            float money = float.Parse(parts[2]);
            int employsNum = int.Parse(parts[3]);
            bool contractor = bool.Parse(parts[4]);

            // Create a new Item object and add it to the list
            employs.Add(new Employs(firstname,lastname,money,employsNum,contractor));
        }

        return employs;
    }

    public List<Job> LoadJob(string filePath)
    {
        List<Job> jobs = new List<Job>();

        // Read all lines from the text file
        string[] lines = File.ReadAllLines(filePath);

        // Skip the header line (assuming the first line has column names)
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            // Split the line into comma-separated values
            string[] parts = line.Split(',');

            if (parts[0] == "Rough")
            {
                // Extract item name, item number, and quantity
                string address = parts[1];
                bool active = bool.Parse(parts[2]);
                float cost = float.Parse(parts[3]);
                string company = parts[4];
                bool rough = bool.Parse(parts[5]);
                bool trim = bool.Parse(parts[6]);
            
                //gets the employee stuff
                string[] emp = parts[7].Split(':');
                //firstname,lastname,money,employsNum,contractor,
                Employs employs = new Employs(emp[0],emp[1],float.Parse(emp[2]),int.Parse(emp[3]),bool.Parse(emp[4]));
            
                List<Item> items = [];
                int count = 0;
                foreach (string inventory in parts)
                {
                    if (count > 7)
                    {
                        string[] g = inventory.Split(":");
                        Item f = new Item(g[0],int.Parse(g[1]),int.Parse(g[2])); 
                        items.Add(f);    
                    }
                    count ++;
                }
                // Create a new Item object and add it to the list
                jobs.Add(new Rough(company,rough,trim,address, items, active, cost, employs));
            }
            else
            {

                // Extract item name, item number, and quantity
                string address = parts[0];
                bool active = bool.Parse(parts[1]);
                float cost = float.Parse(parts[2]);
            
                //gets the employee stuff
                string[] emp = parts[3].Split(':');
                //firstname,lastname,money,employsNum,contractor,
                Employs employs = new Employs(emp[0],emp[1],float.Parse(emp[2]),int.Parse(emp[3]),bool.Parse(emp[4]));
            
                List<Item> items = [];
                int count = 0;
                foreach (string inventory in parts)
                {
                    if (count > 3)
                    {
                        string[] g = inventory.Split(":");
                        Item f = new Item(g[0],int.Parse(g[1]),int.Parse(g[2])); 
                        items.Add(f);    
                    }
                    count ++;
                }
                // Create a new Item object and add it to the list
                jobs.Add(new Job(address, items, active, cost, employs));
            }
        }
        return jobs;
    }

}