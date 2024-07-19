public class Save
{
    // These are all pretty much the same with the exception of the header on each save 
    // all of these just save the major classes to a txt file
    public void saveInventory(string filePath, List<Item> items)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Inventory(ItemNum,Item,Quantity)");
            foreach(Item i in items)
            {
                writer.WriteLine(i.SaveFormat(1));
            }
        }

    }
    public void saveEmploys(string filePath, List<Employs> employs)
    {

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Employs(EmploysNum,firstName,lastName,money,contractor)");
            foreach(Employs i in employs)
            {
                writer.WriteLine(i.SaveFormat(1));
            }
        }
    }
    public void SaveJobs(string filePath, List<Job> jobs)
    {

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Jobs(address,active,cost,employee(firstname:lastname:money:employsNum:contractor:amountOwed),items(item:quantity:itemNum)) Roughs(Rough,address,active,cost,company,rough,trim,employee(firstname:lastname:money:employsNum:contractor:amountOwed),items(item:quantity:itemNum))");
            foreach(Job i in jobs)
            {
                writer.WriteLine(i.SaveFormat());
            }
        }
    }
}