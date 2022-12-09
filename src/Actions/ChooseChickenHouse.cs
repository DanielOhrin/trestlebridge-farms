using System;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, Chicken chicken)
        {
            string error = ""; // Updated depending on fail case

            // Loop continues until valid choice is selected
            while (true)
            {
                Utils.Clear();

                if (error != "")
                {
                    Console.WriteLine(error);
                    Console.WriteLine();
                    Console.WriteLine();
                }

                for (int i = 0; i < farm.ChickenHouses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Chicken House ({farm.ChickenHouses[i].ChickenAmount} chickens)");
                }

                Console.WriteLine();

                // How can I output the type of seed chosen here?
                Console.WriteLine($"Place the {chicken.GetType().Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                try
                {
                    if (farm.ChickenHouses[choice - 1].ChickenAmount < farm.ChickenHouses[choice - 1].Capacity)
                    {
                        farm.ChickenHouses[choice - 1].AddResource(chicken);
                        break;
                    }
                    else
                    {
                        throw new OverflowException();
                    }
                }
                catch (OverflowException)
                {
                    error = @"**** That facililty is not large enough ****
**** Please choose another one ****";
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    error = @"**** That facililty does not exist ****
**** Please choose another one ****";
                    continue;
                }
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<Chicken>(chicken, choice);

        }
    }
}