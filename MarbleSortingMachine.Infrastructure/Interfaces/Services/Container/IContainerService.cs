using MarbleSortingMachine.Domain.Containers;

namespace MarbleSortingMachine.Infrastructure.Interfaces.Services.Container
{
    public interface IContainerService
    {
        long Fill(ContainerBase container, long marbleCount);
        void Shuffle(ContainerBase container);
    }
}
