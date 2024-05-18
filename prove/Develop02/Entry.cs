using System.IO;
class Entry
{
    public string _sfText;
    public string _sfDate;
    public string _sfPrompt;
    public string _sfTags;

//Reads a txt file and saves all the entries to the main journal newJournal
    public List<Entry> sfRead()
    {
        string filename = "Journal.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        List<Entry> sfLoadedEntries = new List<Entry>();

        //Splits the txt file lines into the entry files 
        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split("|");
            entry._sfPrompt = parts[0];
            entry._sfText = parts [1];
            entry._sfDate = parts[2];
            entry._sfTags = parts [3];
            sfLoadedEntries.Add(entry);
        }
        return sfLoadedEntries;
    }
    
    //Writes all of the entries in the newJournal to the txt file to save them
    public void sfWrite(Journal journal)
    {
        string fileName = "journal.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            for (int i = 0; i < journal._sfEntries.Count(); i++)
            {
                Entry entries = journal._sfEntries[i];
                outputFile.WriteLine($"{entries._sfPrompt}|{entries._sfText}|{entries._sfDate}|{entries._sfTags}");
            }
            
        }
    }
}