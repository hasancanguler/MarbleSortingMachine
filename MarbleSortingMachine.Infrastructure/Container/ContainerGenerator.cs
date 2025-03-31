using MarbleSortingMachine.Domain.Common;
using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Domain.Marbles;
using MarbleSortingMachine.Infrastructure.Interfaces.Container;

namespace MarbleSortingMachine.Infrastructure.Container
{
    public class ContainerGenerator : IContainerGenerator
    {
        /// <summary>
        /// Generates a container for the given marble.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="marble"></param>
        /// <returns></returns>
        public ContainerBase GenerateContainer(ContainerBase container, MarbleBase marble)
        {
            double volumeForMarble = Math.Round((4.0 / 3.0) * Math.PI * Math.Pow(marble.HalfDiameter / 10, 3), 3);
            long maxCountForMarble = (long)Math.Round((container.Volume / 1000 / volumeForMarble), 0);
            long capasityForMarble = (long)Math.Round((maxCountForMarble * marble.Density), 0);

            container.Capasity = capasityForMarble;

            return container;
        }

        public List<ColorContainer> GenerateColorContainers(MarbleBase marble)
        {
            return new List<ColorContainer> {
                (ColorContainer)GenerateContainer(new ColorContainer(Colors.red), marble),
                (ColorContainer)GenerateContainer(new ColorContainer(Colors.white), marble),
                (ColorContainer)GenerateContainer(new ColorContainer(Colors.green), marble),
                (ColorContainer)GenerateContainer(new ColorContainer(Colors.black), marble),
                (ColorContainer)GenerateContainer(new ColorContainer(Colors.yellow), marble),
                (ColorContainer)GenerateContainer(new ColorContainer(Colors.other), marble)
            };
        }
    }
}
