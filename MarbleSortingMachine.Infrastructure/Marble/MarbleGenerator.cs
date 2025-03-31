using MarbleSortingMachine.Domain.Common;
using MarbleSortingMachine.Infrastructure.Interfaces.Marble;


namespace MarbleSortingMachine.Infrastructure.Marble
{
    public class MarbleGenerator : IMarbleGenerator
    {
        public Domain.Marble.Marble Generate()
        {
            var marble = new Domain.Marble.Marble();

            var random = new Random();
            int color = random.Next(0, 5);

            marble.Color = (Colors)Enum.ToObject(typeof(Colors), color);

            return marble;
        }

        public Domain.Marble.Marble Generate(Colors color)
        {
            var marble = new Domain.Marble.Marble();
            marble.Color = color;
            return marble;
        }

    }
}
