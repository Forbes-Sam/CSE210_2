public class Report
{
    private List<Job> _jobs;
    private List<Employs> _employs;
    private List<Item> _inventory;

    public Report()
    {
        // Loads up the master lists
        Load load = new Load();
        _jobs = load.LoadJob("jobs.txt");
        _employs = load.LoadEmploys("employs.txt");
        _inventory = load.LoadInventory("item.txt");
    }

    public void CreateList()
    {

        using (StreamWriter writer = new StreamWriter("Report.txt"))
        {
            // report on employees with no joab
            writer.WriteLine("Employees With no Active Job");
            foreach (Employs e in _employs)
            {
                bool noJob = true;
                foreach (Job j in _jobs)
                {
                    if ((j.WhoOnTheJob()).GetID() == e.GetID() && j.IsActive())
                    {
                        noJob = false;
                    }
                }

                if (noJob) 
                {writer.WriteLine(e.ReportDisplay());}
            }
            // reports on active jobs
            writer.WriteLine("\nActive Jobs");

            foreach (Job j in _jobs)
            {
                if (j.IsActive())
                {
                    writer.WriteLine($"{j.ReportDisplay()}\n");
                }
            }
            // report on low inventory
            writer.WriteLine("\nItems with no inventory: ");
            foreach (Item i in _inventory)
            {
                if (i.Quantity() <= 0)
                {
                    writer.WriteLine(i.ReportDisplay());
                }
            }
        }
    }

}