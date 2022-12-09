using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, ICompostProducing seed)
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

                List<NaturalField> fields = farm.NaturalFields.Where(x => x.SeedAmount < x.Capacity).ToList();

                for (int i = 0; i < fields.Count; i++)
                {
                    Dictionary<string, int> seedCount = new Dictionary<string, int>();
                    foreach (ISeedProducing s in fields[i].Seeds)
                    {
                        if (!seedCount.ContainsKey(s.GetType().Name))
                        {
                            seedCount.Add(s.GetType().Name, 1);
                        }
                        else
                        {
                            seedCount[s.GetType().Name]++;
                        }
                    }
                    string groupString = seedCount.Count > 0 ? String.Join(", ", seedCount.Select(x => x.Value + " " + x.Key).ToList()) : "0 seeds";
                    Console.WriteLine($"{i + 1}. Natural Field ({groupString})");
                }

                Console.WriteLine();

                // How can I output the type of seed chosen here?
                Console.WriteLine($"Place the {seed.GetType().Name} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                try
                {
                    for (short i = 0; i < 6; i++)
                    {
                        fields[choice - 1].AddResource(seed);
                    }
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
            // farm.PurchaseResource<NaturalField>(naturalField, choice);

        }
    }
}