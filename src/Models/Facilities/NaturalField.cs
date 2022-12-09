using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ICompostProducing>
    {
        private int _capacity = 60;
        private Guid _id = Guid.NewGuid();
        public int rows { get; } = 10;
        public int seedsPerRow { get; } = 6;


        private List<ICompostProducing> _seeds = new List<ICompostProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public List<ICompostProducing> Seeds
        {
            get
            {
                return _seeds;
            }
        }

        public double SeedAmount
        {
            get
            {
                return _seeds.Count;
            }
        }

        public void AddResource(ICompostProducing seed)
        {
            _seeds.Add(seed);
        }

        public void AddResource(List<ICompostProducing> seeds)
        {
            if (_capacity - _seeds.Count - seeds.Count <= 0)
            {
                Console.WriteLine("That would exceed its capacity!");
            }
            else
            {
                foreach (ICompostProducing seed in seeds)
                {
                    _seeds.Add(seed);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._seeds.Count} seeds\n");
            this._seeds.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}