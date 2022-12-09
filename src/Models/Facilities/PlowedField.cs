using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<ISeedProducing>
    {
        private int _capacity = 65;
        private Guid _id = Guid.NewGuid();
        public int rows { get; } = 13;
        public int seedsPerRow { get; } = 5;
        private List<ISeedProducing> _seeds = new List<ISeedProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public List<ISeedProducing> Seeds
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

        public void AddResource(ISeedProducing seed)
        {
            _seeds.Add(seed);
        }

        public void AddResource(List<ISeedProducing> seeds)
        {
            if (_capacity - _seeds.Count - seeds.Count <= 0)
            {
                Console.WriteLine("That would exceed its capacity!");
            }
            else
            {
                foreach (ISeedProducing seed in seeds)
                {
                    _seeds.Add(seed);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._seeds.Count} seeds\n");
            this._seeds.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}