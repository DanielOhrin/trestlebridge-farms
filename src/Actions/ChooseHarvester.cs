using System;
using Trestlebridge.Models;
using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Actions
{
    public class ChooseHarvester
    {
        public static void Process(Farm farm)
        {
            Console.WriteLine("1. Seed Harvester");
            Console.WriteLine("2. Meat Processor");
            Console.WriteLine("3. Egg Gatherer");
            Console.WriteLine("4. Composter");
            Console.WriteLine("5. Feather Harvester");

            Console.WriteLine();
            Console.WriteLine("Choose a tool");

            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (Int32.Parse(choice))
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    Composter.Harvest(farm);
                    break;
                case 5:

                    break;
                default:
                    break;
            }


        }
    }
}