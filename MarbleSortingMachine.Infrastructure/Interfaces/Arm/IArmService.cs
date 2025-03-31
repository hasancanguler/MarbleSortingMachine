using MarbleSortingMachine.Contracts.Arm;
using MarbleSortingMachine.Domain.Common;
using MarbleSortingMachine.Domain.Containers;

namespace MarbleSortingMachine.Infrastructure.Interfaces.Arm
{
    public interface IArmService
    {
        ArmResponse Sort(ContainerBase bigContainer);
        ArmResponse Sort(ContainerBase bigContainer, Colors color);
    }
}
