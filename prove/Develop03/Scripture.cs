using System.Formats.Tar;

class Scripture
{
    private List<Word> _words;
    Reference Ref = new Reference();

    public Scripture()          //sets my list to be a list of nothing instead of Void
{
    _words = new List<Word>();
}
    public void Display()   //displays the the book reference and verses that are still visible
    {
        Console.WriteLine($"{Ref.GetBook()}");
        Console.WriteLine($"{Ref.GetReference()}");

        string v = Ref.GetVerse();
        string[] words = v.Split(' ');

        //Checks to see if the word should be visible or not visible
        for (int i = 0; i < words.Count(); i++)
        {
            if (_words[i].GetVisible() == false)    //if the word is hidden put ____ instead of the word
            {
                Console.Write("____ ");
            }
            else    //if it is not false or if it is supposed to be visible display the word
            {
                Console.Write($"{_words[i].GetText()} ");   
            }
        }
        
    }
    public void Reset()     //resets all the words to be visible 
    {
        for (int i =0;i < _words.Count(); i++)
        {
            _words[i].SetVisible(true);
        }
    }
    public bool RemoveWord()//sets 3 words at a time visible status to false 
    {
        Random random = new Random();
        
        // used Gemini for the && _words.Any(word => word.GetVisible())
        // Keeps looping until 3 random words have been set to invisible or all words are invisible (false)
        int i = 0;
        while (i < 3 && _words.Any(word => word.GetVisible()))
        {
            int ran = random.Next(0, _words.Count());
            bool TF =_words[ran].GetVisible();
            if (TF == true)
            {
                _words[ran].SetVisible(false);
                i++;
            }
            else{}

        }
        //returns a true if there are still words visible
        //returns a false if all words are invisible
        if(_words.Any(word => word.GetVisible()) == false)
        {
            return false;
        }
        return true;
    }

    public void AddWord()   //sets up or _words variable with a list of Word (maybe make it so the user can supply there own verses)
    {     
        //splits the verse up into a list divided by a ' '   
        string v = Ref.GetVerse();
        string[] words = v.Split(' ');

        //iterates through the above list and turns it into a List of Word with all words set to visible
        for (int i = 0; i < words.Count(); i++)
        {
            Word word = new Word();
            word.SetText(words[i]);
            word.SetVisible(true);
            _words.Add(word);
        }
    }
}