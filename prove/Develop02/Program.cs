using System;
using System.Transactions;

class Program
{
    static void Main()
    {
        // initiates my options variable and creates a journal list to store my new journal entries on.
        int sfOption = 10;
        Journal newJournal = new Journal();
        newJournal._sfEntries = new List<Entry>();
        PromptGenerator promptGenerator = new PromptGenerator();    //prepares the promptGenerator for use
        

        while (sfOption != 0) // While user dose not choose zero (quit keep running program)
        {
            sfOption = sfMenu();

            if (sfOption == 0) // Quit
            {
                Console.WriteLine("Good bye");
            }
            else if (sfOption == 1) // add new entry
            {
                Entry entry = new Entry();
                entry = newJournal.sfAddEntry(promptGenerator.sfGenerate(), entry);
                newJournal._sfEntries.Add(entry);
                
            }
            else if (sfOption == 2) // displays all entries
            {
                newJournal.sfDisplayAll(newJournal);
            }
            else if (sfOption == 3) // loads a file to newJournal._sfEntries
            {
                Entry entry = new Entry();
                newJournal._sfEntries = entry.sfRead();
            }
            else if (sfOption == 4) // saves all entries on newJournal._sfEntries to journal.txt
            {
                Entry entry = new Entry();
                entry.sfWrite(newJournal);
                Console.WriteLine("Saved");
            }
            else // no valid input but keep on looping
            {
                
                Console.WriteLine("Not an Option Try Again");
            }

        }

        
    }
    public static int sfMenu() // Menu for what to do with user input
    {
        int sfOption = 0;
        Console.WriteLine("0. Quit");
        Console.WriteLine("1. New Entry");
        Console.WriteLine("2. View all Entries");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        string s = Console.ReadLine();
        sfOption = int.Parse(s);

        return sfOption;
    }
}