using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Infrastructure.Interfaces.Marble;
using MarbleSortingMachine.Infrastructure.Interfaces.Services.Container;

namespace MarbleSortingMachine.Infrastructure.Services.Container
{

    public class ContainerService : IContainerService
    {
        private readonly IMarbleGenerator _marbleGenerator;
        public ContainerService(IMarbleGenerator marbleGenerator)
        {
            _marbleGenerator = marbleGenerator;
        }
        public long Fill(ContainerBase container, long marbleCount)
        {
            long availableCapacity = container.Capasity - marbleCount;
            if (availableCapacity < 0)
            {
                throw new InvalidOperationException("There is no space in the container");
            }

            long countOfMarbles = 0;
            for (long index = container.CurrentAmount; index < marbleCount; index++)
            {
                var marble = _marbleGenerator.Generate();
                container.Marbles.Add(marble);

                countOfMarbles++;
            }

            return countOfMarbles;
        }

        public void Shuffle(ContainerBase container)
        {
            var random = new Random();
            container.Marbles = container.Marbles.OrderBy(x => random.Next()).ToList();
        }
    }
}
