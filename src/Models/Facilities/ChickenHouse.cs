using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.Animals;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : IFacility<Chicken>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _chickens = new List<Chicken>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public double ChickenAmount
        {
            get
            {
                return _chickens.Count;
            }
        }

        public void AddResource(Chicken chicken)
        {
            _chickens.Add(chicken);
        }

        public void AddResource(List<Chicken> chickens)
        {
            if (_capacity - _chickens.Count - chickens.Count <= 0)
            {
                Console.WriteLine("That would exceed its capacity!");
            }
            else
            {
                foreach (Chicken chicken in chickens)
                {
                    _chickens.Add(chicken);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken house {shortId} has {this._chickens.Count} chickens\n");
            this._chickens.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}