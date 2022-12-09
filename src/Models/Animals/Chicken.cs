using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Models.Animals
{
    public class Chicken : IResource, IMeatProducing, IEggProducing, IFeatherProducing
    {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 1.7;
        private double _eggsProduced = 7;
        private double _feathersProduced = 0.5;
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double GrassPerDay { get; set; } = 0.9;
        public string Type { get; } = "Chicken";

        // Methods

        public double Process(MeatProcessor equipment)
        {
            return _meatProduced;
        }

        public double Process(EggGatherer equipment)
        {
            return _eggsProduced;
        }

        public double Process(FeatherHarvester equipment)
        {
            return _feathersProduced;
        }

        public override string ToString()
        {
            return $"Chicken {this._shortId}. Bah Kaaaaa!";
        }
    }
}