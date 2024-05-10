using System;

class Program
{
    static void Main(string[] args)
    {
        Job sfJob1 = new Job();
        sfJob1._sfJobTitle = "Electrical Engineer";
        sfJob1._sfCompany = "Intel";
        sfJob1._sfStartYear = 2000;
        sfJob1._sfEndYear = 2024;
        
        Job sfJob2 = new Job();
        sfJob2._sfJobTitle = "Electrical Engineer";
        sfJob2._sfCompany = "AMD";
        sfJob2._sfStartYear = 1990;
        sfJob2._sfEndYear = 2000;

        Resume sfResume1 = new Resume();
        sfResume1._sfName = "Sam Forbes";
        sfResume1._sfJobs = [sfJob1, sfJob2];
        sfResume1.Display();
    }
}