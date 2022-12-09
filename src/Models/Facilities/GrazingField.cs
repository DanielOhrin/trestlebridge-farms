using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public double AnimalAmount
        {
            get
            {
                return _animals.Count;
            }
        }

        public List<IGrazing> Animals
        {
            get
            {
                return _animals;
            }
        }
        public void AddResource(IGrazing animal)
        {
            _animals.Add(animal);
        }

        public void AddResource(List<IGrazing> animals)
        {
            if (_capacity - _animals.Count - animals.Count <= 0)
            {
                Console.WriteLine("That would exceed its capacity!");
            }
            else
            {
                foreach (IGrazing animal in animals)
                {
                    _animals.Add(animal);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}