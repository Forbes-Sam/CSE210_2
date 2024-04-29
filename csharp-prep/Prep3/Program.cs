using System;

class Program
{
    static void Main(string[] args)
    {
        // gets the magic number from the user
        //Console.Write("What is the magic number? ");
        //string sfMagicStr = Console.ReadLine();
        //int sfMagicNum =int.Parse(sfMagicStr);

        Random random = new Random();
        int sfMagicNum = random.Next(1,101);

        //starts the loop until the user guesses the magic number
        int sfUserNum = 0;
        while (sfUserNum != sfMagicNum){
            Console.Write("What is your guess? ");
            string sfUserStr = Console.ReadLine();
            sfUserNum = int.Parse(sfUserStr);

            // Tells the user if they are higher or lower than the guess or if they guessed it
            if (sfUserNum > sfMagicNum){
                Console.WriteLine("Lower");
            }
            else if (sfUserNum < sfMagicNum){
                Console.WriteLine("Higher");
            }
            else{
                Console.WriteLine("You guessed it!!!");
            }
        }
    }
}