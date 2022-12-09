using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Interfaces
{
    public interface IMeatProducing
    {
        double Process(MeatProcessor equipment);
    }
}