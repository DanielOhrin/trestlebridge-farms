using Trestlebridge.Models.Harvesters;

namespace Trestlebridge.Interfaces
{
    public interface ICompostProducing
    {
        double Process(Composter equipment);
    }
}