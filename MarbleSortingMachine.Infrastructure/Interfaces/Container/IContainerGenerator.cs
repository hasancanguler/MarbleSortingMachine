using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Domain.Marble;
using MarbleSortingMachine.Domain.Marbles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleSortingMachine.Infrastructure.Interfaces.Container
{
    public interface IContainerGenerator
    {
        ContainerBase GenerateContainer(ContainerBase container, MarbleBase marble);
        List<ColorContainer> GenerateColorContainers(MarbleBase marble);
    }
}
