using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Interfaces
{
    public interface IEggProducing
    {
        double Process(EggGatherer equipment);
    }
}