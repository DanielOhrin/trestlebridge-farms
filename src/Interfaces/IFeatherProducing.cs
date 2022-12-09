using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Interfaces
{
    public interface IFeatherProducing
    {
        double Process(FeatherHarvester equipment);
    }
}