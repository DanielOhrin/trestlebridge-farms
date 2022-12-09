using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Interfaces
{
    public interface ISeedProducing
    {
        double Process(SeedHarvester equipment);
    }
}