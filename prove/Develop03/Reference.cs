class Reference
{
    private string _reference;
    private string _book;
    private string _verse;
    
    //sets the variables so that we don't have to set them later
    public Reference()
    {
        _reference = "Alma 41:10";
        _book = "Book of Mormon";
        _verse = "Do not suppose, because it has been spoken concerning restoration, that ye shall be restored from sin to happiness. Behold, I say unto you, wickedness never was happiness.";
    }

    //gets the reference book and verse and returns them as strings
    public string GetReference()
    {
        string g = _reference;
        return g;
    }
    public string GetBook()
    {
        string g = _book;
        return g;
    }
    public string GetVerse()
    {
        string g = _verse;
        return g;
    }
}