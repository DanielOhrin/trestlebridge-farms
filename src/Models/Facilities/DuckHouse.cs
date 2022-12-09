using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.Animals;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _ducks = new List<Duck>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public double DuckAmount
        {
            get
            {
                return _ducks.Count;
            }
        }

        public void AddResource(Duck duck)
        {
            _ducks.Add(duck);
        }

        public void AddResource(List<Duck> ducks)
        {
            if (_capacity - _ducks.Count - ducks.Count <= 0)
            {
                Console.WriteLine("That would exceed its capacity!");
            }
            else
            {
                foreach (Duck duck in ducks)
                {
                    _ducks.Add(duck);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck house {shortId} has {this._ducks.Count} ducks\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}