using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Models.Animals
{
    public class Ostrich : IResource, IGrazing, IMeatProducing, IEggProducing
    {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 2.6;
        private double _eggsProduced = 3;

        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double GrassPerDay { get; set; } = 2.3;
        public string Type { get; } = "Ostrich";

        // Methods
        public void Graze()
        {
            Console.WriteLine($"Ostrich {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }

        public double Process(MeatProcessor equipment)
        {
            return _meatProduced;
        }

        public double Process(EggGatherer equipment)
        {
            return _eggsProduced;
        }

        public override string ToString()
        {
            return $"Ostrich {this._shortId}. Squack!";
        }
    }
}