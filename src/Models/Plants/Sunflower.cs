using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, ICompostProducing
    {
        private int _seedsProduced = 650;
        private double _compostProduced = 21.6;
        public string Type { get; } = "Sunflower";

        public double Process(SeedHarvester equipment)
        {
            return _seedsProduced;
        }

        public double Process(Composter equipment)
        {
            return _compostProduced;
        }

        public override string ToString()
        {
            return $"Sunflower. Yum!";
        }
    }
}