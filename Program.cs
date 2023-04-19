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


        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();

            DisplayMenu();

            var bandCount = context.Bands.Count();

            Console.WriteLine($"There are {bandCount} bands!");





        }
    }
}
