using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
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

                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Dictionary<string, int> animalCount = new Dictionary<string, int>();
                    foreach (IGrazing a in farm.PlowedFields)
                    {
                        if (!animalCount.ContainsKey(a.GetType().Name))
                        {
                            animalCount.Add(a.GetType().Name, 1);
                        }
                        else
                        {
                            animalCount[a.GetType().Name]++;
                        }
                    }
                    Console.WriteLine($"{i + 1}. Plowed Field ({String.Join(", ", animalCount.Select(x => x.Value + x.Key).ToList())})");
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the {animal.GetType().Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                try
                {
                    if (farm.GrazingFields[choice - 1].AnimalAmount < farm.GrazingFields[choice - 1].Capacity)
                    {
                        farm.GrazingFields[choice - 1].AddResource(animal);
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
            // farm.PurchaseResource<GrazingField>(grazingField, choice);

        }
    }
}