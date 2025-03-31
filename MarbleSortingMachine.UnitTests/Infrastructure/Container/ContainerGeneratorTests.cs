using Autofac.Extras.Moq;
using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Domain.Marble;
using MarbleSortingMachine.Infrastructure.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Container;

namespace MarbleSortingMachine.UnitTests.Infrastructure.Container
{
    public class ContainerGeneratorTests
    {
        private readonly AutoMock _mock = AutoMock.GetStrict();
        private  readonly IContainerGenerator _containerGenerator;

        public ContainerGeneratorTests()
        {
            _containerGenerator = _mock.Create<ContainerGenerator>();
        }

        [Fact]
        public void GenerateBigContainer_Capasity_Should_Be_Constant_1413413()
        {
            var capasityForMarble = 1413413;

            var container = new BigContainer();
            var marble = new Domain.Marble.Marble();

            var bigContainer = _containerGenerator.GenerateContainer(container,marble);

            Assert.Equal(capasityForMarble, bigContainer.Capasity);
        }

        [Fact]
        public void GenerateColorContainers_Should_Return_6_Containers()
        {
            var marble = new Domain.Marble.Marble();
            var colorContainers = _containerGenerator.GenerateColorContainers(marble);
            Assert.Equal(6, colorContainers.Count);
        }
    }
}
