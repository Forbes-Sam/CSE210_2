class Journal
{
    public List<Entry> _sfEntries;

// Passes a random prompt and an entry that is returned and added to the main journal //
    public Entry sfAddEntry(string prompt, Entry sfEntry) 
    {
        // gets all the proper information for the prompt
        DateTime today = DateTime.Today;
        sfEntry._sfDate = today.ToString("MM/dd/yyyy");
        sfEntry._sfPrompt = prompt;
        Console.WriteLine($"{prompt}");
        sfEntry._sfText = Console.ReadLine();
        Console.Write("What tag would you like this under: ");
        sfEntry._sfTags = Console.ReadLine();
        
        return sfEntry; // returns all the information to add a new entry to the list
    }

    public void sfDisplayAll(Journal journal)
    { // Displays all of the entries saved in the newJournal 
        for (int i = 0; i < journal._sfEntries.Count; i++)
        {
            Entry sfEntry = journal._sfEntries[i];
            Console.WriteLine($"{sfEntry._sfTags}");
            Console.WriteLine($"{sfEntry._sfPrompt}:");
            Console.WriteLine($"{sfEntry._sfText} {sfEntry._sfDate}");
        }
    }

}