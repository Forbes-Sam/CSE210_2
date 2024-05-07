using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Course course1 = new Course();
        course1._ClassName = "Programing with Classes";
        course1._Color = "Green";
        course1._CourseCode = "CSE 210";
        course1._NumberOfCredits = 3;
        course1.Display();
    
    }
}