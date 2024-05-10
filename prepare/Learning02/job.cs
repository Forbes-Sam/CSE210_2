class Job
{
    public string _sfCompany;
    public string _sfJobTitle;
    public int _sfStartYear;
    public int _sfEndYear;

    public void Display()
    {
        Console.WriteLine($"{_sfJobTitle} ({_sfCompany}) {_sfStartYear}-{_sfEndYear}");
    }
}
