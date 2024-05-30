using System.Security.Cryptography.X509Certificates;

class Word
{
    private string _text;
    private bool _visible;

    //returns the word 
    public string GetText() 
    {
        string t = _text;
        return t;
    } 

    //sets the text (maybe make it so you can add your own scriptures)
    public void SetText(string t)
    {
        _text = t;
    }

    //returns a true or false if the word should be displayed or not
    public bool GetVisible()
    {
        bool v = _visible;
        return v;
    }

    // sets the word to be visible or to not be visible
    public void SetVisible(bool v)
    {
        _visible = v;
    }

}