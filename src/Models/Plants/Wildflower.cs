using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, ICompostProducing
    {
        private double _compostProduced = 21.6;
        public string Type { get; } = "Wildflower";
        public double Scoop()
        {
            return _compostProduced;
        }

        public override string ToString()
        {
            return $"Wildflower. Yum!";
        }
    }
}