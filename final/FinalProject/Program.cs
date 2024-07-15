using System;

class Program
{
    static void Main(string[] args)
    {
        Load load = new Load();
        List<Item> Inventory;
        List<Employs> employs;


        Inventory = load.LoadInventory("inventory.txt");
        foreach (Item i in Inventory)
        {
            i.Display();
        }

        employs = load.LoadEmploys("employs.txt");
        foreach (Employs i in employs)
        {
            i.Display();
        }

    }
}