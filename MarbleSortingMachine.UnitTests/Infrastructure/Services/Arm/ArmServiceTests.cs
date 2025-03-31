using Autofac.Extras.Moq;
using FluentAssertions;
using MarbleSortingMachine.Contracts.Arm;
using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Infrastructure.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Arm;
using MarbleSortingMachine.Infrastructure.Interfaces.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Marble;
using MarbleSortingMachine.Infrastructure.Interfaces.Services.Container;
using MarbleSortingMachine.Infrastructure.Marble;
using MarbleSortingMachine.Infrastructure.Services.Arm;
using MarbleSortingMachine.Infrastructure.Services.Container;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleSortingMachine.UnitTests.Infrastructure.Services.Arm
{
    public class ArmServiceTests
    {
        private readonly AutoMock _mock = AutoMock.GetStrict();
        private readonly IContainerService _containerService;
        private readonly IMarbleGenerator _marbleGenerator;
        private readonly IContainerGenerator _containerGenerator;
        private readonly IArmService _armService;

        public ArmServiceTests()
        {
            _containerService = _mock.Create<ContainerService>();
            _marbleGenerator = _mock.Create<MarbleGenerator>();
            _armService = _mock.Create<ArmService>();
            _containerGenerator = _mock.Create<ContainerGenerator>();
        }

        [Fact]
        public void Sort_ReTry_Should_Remove_Marbles_From_BigContainer_When_There_Is_No_Match()
        {
            // Arrange
            long marbleCount = 10;

            var marble = new Domain.Marble.Marble()
            {
                Color = Domain.Common.Colors.red
            };

            var marbleGenerator = _mock.Mock<IMarbleGenerator>();
            marbleGenerator.Setup(x => x.Generate()).Returns(marble).Verifiable();

            var bigContainer = _containerGenerator.GenerateContainer(new BigContainer(), new Domain.Marble.Marble());
            _containerService.Fill(bigContainer, marbleCount);

            var containerGenerator = _mock.Mock<IContainerGenerator>();

            var colorContainer = new List<ColorContainer>()
            {
                new ColorContainer(Domain.Common.Colors.yellow)
            };

            containerGenerator.
                Setup(x => x.GenerateColorContainers(It.IsAny<Domain.Marble.Marble>())).
                Returns(colorContainer).
                Verifiable();

            var _containerServiceMock = _mock.Mock<IContainerService>();
            _containerServiceMock.Setup(x => x.Shuffle(bigContainer)).Verifiable();

            var expected = new ArmResponse()
            {
                Containers = new List<ContainerResult>()
                {
                    new ContainerResult
                    {
                        Color = Domain.Common.Colors.yellow.ToString(),
                        Count = 0
                    }
                }
            };

            // Act
            var result = _armService.Sort(bigContainer);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
