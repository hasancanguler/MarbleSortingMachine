using Autofac.Extras.Moq;
using MarbleSortingMachine.Domain.Common;
using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Infrastructure.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Marble;
using MarbleSortingMachine.Infrastructure.Interfaces.Services.Container;
using MarbleSortingMachine.Infrastructure.Marble;
using MarbleSortingMachine.Infrastructure.Services.Container;
using FluentAssertions;

namespace MarbleSortingMachine.UnitTests.Infrastructure.Services.Container
{
    public class ContainerServiceTests
    {
        private readonly AutoMock _mock = AutoMock.GetStrict();
        private readonly IContainerService _containerService;
        private readonly IMarbleGenerator _marbleGenerator;

        public ContainerServiceTests()
        {
            _containerService = _mock.Create<ContainerService>();
            _marbleGenerator = _mock.Create<MarbleGenerator>();
        }

        [Fact]
        public void Fill_ContainerIsEmpty_ReturnsCountOfMarbles()
        {
            // Arrange
            var container = new BigContainer();
            container.Capasity = 10;
            int marbleCount = 10;

            var marble = _marbleGenerator.Generate();

            var marbleGenerator = _mock.Mock<IMarbleGenerator>();
            marbleGenerator.Setup(x => x.Generate()).Returns(marble).Verifiable();

            // Act
            var result = _containerService.Fill(container, marbleCount);

            // Assert
            Assert.Equal(container.Capasity, result);
        }
        [Fact]
        public void Shuffle_ContainerIsNotEmpty_ReturnsShuffledMarbles()
        {
            // Arrange
            var container = new ContainerGenerator().GenerateContainer(new BigContainer(), new Domain.Marble.Marble());

            var marbleGreen = _marbleGenerator.Generate(Colors.green);
            var marbleRed = _marbleGenerator.Generate(Colors.red);
            var marbleYellow = _marbleGenerator.Generate(Colors.yellow);

            container.Marbles.Add(marbleGreen);
            container.Marbles.Add(marbleRed);
            container.Marbles.Add(marbleYellow);

            var expected = new ContainerGenerator().GenerateContainer(new BigContainer(), new Domain.Marble.Marble());

            expected.Marbles.Add(marbleGreen);
            expected.Marbles.Add(marbleRed);
            expected.Marbles.Add(marbleYellow);

            // Act
            _containerService.Shuffle(container);

            // Assert
            container.Marbles.Should().NotBeEquivalentTo(expected.Marbles, options => options.WithStrictOrdering());
        }
    }
}
