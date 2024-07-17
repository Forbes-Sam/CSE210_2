using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Load load = new Load();
        Save save = new Save();
        List<Item> Inventory;
        List<Employs> employs;
        List <Job> jobs;


        Inventory = load.LoadInventory("inventory.txt");
        foreach (Item i in Inventory)
        {
            i.Display();
        }
        save.saveInventory("inventory.txt", Inventory);

        employs = load.LoadEmploys("employs.txt");
        foreach (Employs i in employs)
        {
            i.Display();
        }
        save.saveEmploys("employs.txt",employs);

        jobs = load.LoadJob("jobs.txt");
        foreach (Job i in jobs)
        {
            i.DisplayJob();
        }

    }
}