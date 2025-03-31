using MarbleSortingMachine.Domain.Common;

namespace MarbleSortingMachine.Infrastructure.Interfaces.Marble
{
    public interface IMarbleGenerator
    {
        Domain.Marble.Marble Generate();
        Domain.Marble.Marble Generate(Colors color);
    }
}
