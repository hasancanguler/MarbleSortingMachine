using MarbleSortingMachine.Contracts.Arm;
using MarbleSortingMachine.Domain.Common;
using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Domain.Marbles;
using MarbleSortingMachine.Infrastructure.Interfaces.Arm;
using MarbleSortingMachine.Infrastructure.Interfaces.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Services.Container;
using Serilog;

namespace MarbleSortingMachine.Infrastructure.Services.Arm
{
    public class ArmService : IArmService
    {
        private readonly IContainerGenerator _containerGenerator;
        private readonly IContainerService _containerService;
        private const int FailTreshold = 3;

        public ArmService(IContainerGenerator containerGenerator, IContainerService containerService)
        {
            _containerGenerator = containerGenerator;
            _containerService = containerService;
        }

        private ArmResponse Sort(ContainerBase bigContainer, List<ColorContainer> colorContainers)
        {
            for (int index = bigContainer.Marbles.Count - 1; index >= 0; index--)
            {
                var marble = bigContainer.Marbles[index];

                var targetContainer = Find(colorContainers, marble);

                if (targetContainer != null)
                {
                    Send(bigContainer, targetContainer, marble);
                }
                else
                {
                    _containerService.Shuffle(bigContainer);
                    ReTry(bigContainer, colorContainers, marble);
                }
            }

            var result = new ArmResponse()
            {
                Containers = new List<ContainerResult>()
            };

            foreach (var item in colorContainers)
            {
                result.Containers.Add(
                    new ContainerResult()
                    {
                        Color = item.Color.ToString(),
                        Count = item.Marbles.Count
                    });
            }

            Log.Information("{Result}", result.Containers);

            return result;
        }

        public ArmResponse Sort(ContainerBase bigContainer)
        {            
            var colorContainers = _containerGenerator.GenerateColorContainers(new Domain.Marble.Marble());

            return Sort(bigContainer, colorContainers);
        }
        public ArmResponse Sort(ContainerBase bigContainer, Colors color)
        {
            var colorContainers = _containerGenerator.GenerateColorContainers(new Domain.Marble.Marble());
            bigContainer.Marbles.RemoveAll(x => x.Color != color);

            return Sort(bigContainer, colorContainers);
        }
        private static ColorContainer? Find(List<ColorContainer> containers, MarbleBase marble)
        {
            var targetContainer = containers.Find(x => x.Color == marble.Color);
            return targetContainer;
        }
        private static void Send(ContainerBase bigContainer, ColorContainer targetContainer, MarbleBase marble)
        {
            targetContainer.Marbles.Add(marble);
            bigContainer.Marbles.Remove(marble);
        }
        private static void ReTry(ContainerBase bigContainer, List<ColorContainer> containers, MarbleBase marble)
        {
            for (int failCount = 0; failCount < FailTreshold; failCount++)
            {
                var targetContainer = Find(containers, marble);
                if (targetContainer != null)
                {
                    Send(bigContainer, targetContainer, marble);
                    return;
                }
            }
            bigContainer.Marbles.Remove(marble);
        }
    }
}
