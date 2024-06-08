using System;

class Program
{
    static void Main(string[] args)
    {
        Math math = new Math("Sam Forbes", "Math", "7.3", "8-19");
        math.GetHomeworkList();

        Writing writing = new Writing("Sam Forbes", "European History", "The Causes of World War II by Mary Waters");
        writing.GetWritingAssignment();
    }
}