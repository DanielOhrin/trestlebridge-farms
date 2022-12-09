using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

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
                }

                List<GrazingField> fields = farm.GrazingFields.Where(x => x.AnimalAmount < x.Capacity).ToList();

                for (int i = 0; i < fields.Count; i++)
                {
                    Dictionary<string, int> animalCount = new Dictionary<string, int>();
                    foreach (IGrazing a in fields[i].Animals)
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

                    string groupString = animalCount.Count > 0 ? String.Join(", ", animalCount.Select(x => x.Value + " " + x.Key).ToList()) : "0 animals";
                    Console.WriteLine($"{i + 1}. Grazing Field ({groupString})");
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the {animal.GetType().Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                try
                {
                    farm.GrazingFields[choice - 1].AddResource(animal);
                    break;
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