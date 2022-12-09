using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Harvesters
{
    public class Composter : Harvester
    {
        public static void Harvest(Farm farm)
        {
            Utils.Clear();

            // List of fields that contain harvestable resources with Composter
            List<GrazingField> gFields = farm.GrazingFields.Where(x => x.Animals.Where(y => y.GetType().Name == "Goat").ToList().Count > 0).ToList();
            List<PlowedField> pFields = farm.PlowedFields.Where(x => x.Seeds.Where(y => y.GetType().Name == "Sunflower").ToList().Count > 0).ToList();
            List<NaturalField> nFields = farm.NaturalFields.Where(x => x.Seeds.Where(y => y.GetType().Name == "Sunflower" || y.GetType().Name == "Wildflower").ToList().Count > 0).ToList();

            for (int i = 0; i < gFields.Count + pFields.Count + nFields.Count; i++)
            {
                if (i < gFields.Count)
                {
                    Console.WriteLine($"{i + 1}. Grazing Field ({gFields[i].Animals.Where(x => x.GetType().Name == "Goat").ToList().Count} Goats)");
                }
                else if (i > gFields.Count && i < gFields.Count + pFields.Count)
                {
                    Console.WriteLine($"{i + 1}. Plowed Field ({pFields[i - gFields.Count].Seeds.Where(x => x.GetType().Name == "Sunflower").ToList().Count})");
                }
                else
                {
                    string groupString = String.Join(", ", nFields[i - gFields.Count - pFields.Count].Seeds.GroupBy(x => x.GetType().Name).Select(y => $"{y.Count()} {y.Key}").ToList());
                    Console.WriteLine($"{i + 1}. Natural Field ({groupString})");
                }
            }

            Console.WriteLine("Choose a facility to harvest from");
            Console.WriteLine();

            Console.Write("> ");

            int index = Int32.Parse(Console.ReadLine());

            // Use if conditionals to select the proper list item.
            if (index > gFields.Count + pFields.Count)
            {
                // nFields
                index -= (1 + gFields.Count + pFields.Count);
                _ChooseResource(nFields[index]);
                Console.ReadLine();
            }
            else if (index > gFields.Count)
            {
                // pFields
                index -= (1 + gFields.Count);
                _ChooseResource(pFields[index]);
                Console.ReadLine();
            }
            else
            {
                // gFields
                index--;
                _ChooseResource(gFields[index]);
                Console.ReadLine();
            }
        }
        //TODO: Finish _ChooseResource Method with all overloads

        private static void _ChooseResource(GrazingField field)
        {
            Utils.Clear();

            Console.WriteLine("The following animals are available for processing");
            Console.WriteLine();

            Console.WriteLine($"1. {field.Animals.Where(x => x.GetType().Name == "Goat").ToList().Count} Goat");
        }

        private static void _ChooseResource(PlowedField field)
        {
            Utils.Clear();

            Console.WriteLine("The following seeds are available for processing");
            Console.WriteLine($"1. {field.Seeds.Where(x => x.GetType().Name == "Sunflower").ToList().Count} Goat");
        }

        private static void _ChooseResource(NaturalField field)
        {
            Utils.Clear();

            Console.WriteLine("The following seeds are available for processing");
            Console.WriteLine();

            List<string> writeLines = field.Seeds.GroupBy(x => x.GetType().Name).Select(x => $"{x.Count()} {x.Key}").ToList();

            foreach (string seed in writeLines)
            {
                Console.WriteLine($"{writeLines.IndexOf(seed) + 1}. {seed}");
            }
        }

    }
}
