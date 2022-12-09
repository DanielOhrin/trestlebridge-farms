using System;

namespace Trestlebridge.Models.Harvesters
{
    public class Harvester
    {
        public DateTime DateCreated { get; } = DateTime.Now;
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}