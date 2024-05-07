class Course
{
public string _CourseCode;
public string _ClassName;
public int _NumberOfCredits;
public string _Color;

//Method
public void Display()
{
    Console.WriteLine($"{_CourseCode} {_ClassName} {_NumberOfCredits} {_Color}");
}


}