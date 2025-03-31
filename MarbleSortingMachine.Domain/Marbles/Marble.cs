using MarbleSortingMachine.Domain.Marbles;

namespace MarbleSortingMachine.Domain.Marble
{
    public class Marble : MarbleBase
    {
        private static double halfDiameter = 7.5;
        private static double density = 0.74;
        public Marble() : base(halfDiameter, density)
        {
        }

    }
}
