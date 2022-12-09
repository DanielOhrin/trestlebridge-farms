using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, ICompostProducing
    {
        private double _compostProduced = 21.6;
        public string Type { get; } = "Wildflower";
        public double Process(Composter equipment)
        {
            return _compostProduced;
        }

        public override string ToString()
        {
            return $"Wildflower. Yum!";
        }
    }
}