using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, ISeedProducing seed)
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
                }

                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].SeedAmount / 5} rows)");
                }

                Console.WriteLine();

                // How can I output the type of seed chosen here?
                Console.WriteLine($"Place the {seed.GetType().Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                try
                {
                    if (farm.PlowedFields[choice - 1].SeedAmount < farm.PlowedFields[choice - 1].Capacity)
                    {
                        for (short i = 0; i < 5; i++)
                        {
                            farm.PlowedFields[choice - 1].AddResource(seed);
                        }
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
            // farm.PurchaseResource<PlowedField>(plowedField, choice);

        }
    }
}