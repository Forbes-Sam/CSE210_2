using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> sfNumList = new();
        string sfUserStr;
        int sfUserNum = 1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while (sfUserNum != 0){
            Console.Write("Enter number: ");
            sfUserStr = Console.ReadLine();
            sfUserNum = int.Parse(sfUserStr);

            if (sfUserNum != 0){
                sfNumList.Add(sfUserNum);
            }

        }
        int sfSum = 0;
        int sfLargestNum = 0;
        int sfQuantity = 0;
        float sfAverage = 0;

        for (int i = 0; i < sfNumList.Count; i++ ){
            sfSum += sfNumList[i];
            sfQuantity = i;

            if (sfLargestNum < sfNumList[i]){
                sfLargestNum = sfNumList[i];
            }
        }
        sfQuantity += 1;
        sfAverage = sfSum / sfQuantity;

        Console.WriteLine($"The sum is: {sfSum}");
        Console.WriteLine($"The average is: {sfAverage}");
        Console.WriteLine($"The largest number is: {sfLargestNum}");


    }
}