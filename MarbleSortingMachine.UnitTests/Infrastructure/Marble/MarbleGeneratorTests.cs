using Autofac.Extras.Moq;
using MarbleSortingMachine.Infrastructure.Interfaces.Marble;
using MarbleSortingMachine.Infrastructure.Marble;

namespace MarbleSortingMachine.UnitTests.Infrastructure.Marble
{
    public class MarbleGeneratorTests
    {
        private readonly AutoMock _mock = AutoMock.GetStrict();
        private readonly IMarbleGenerator _marbleGenerator;

        public MarbleGeneratorTests()
        {
            _marbleGenerator = _mock.Create<MarbleGenerator>();
        }

        [Fact]
        public void Generate_Should_Return_Marble()
        {
            var marble = _marbleGenerator.Generate();            

            Assert.NotNull(marble);
        }
    }
}
