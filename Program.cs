using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    class Program
    {

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[A]dd a new band, album, or song");
            Console.WriteLine("[V]iew band and album info");
            Console.WriteLine("[U]pdate status of a band");
            Console.WriteLine("[Q]uit");
            Console.WriteLine();

        }
        public static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper();

            return userInput;
        }
         public static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer. ");
                return 0;
            }
        }


        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();

            DisplayMenu();

            var bandCount = context.Bands.Count();

            Console.WriteLine($"There are {bandCount} bands!");





        }
    }
}
