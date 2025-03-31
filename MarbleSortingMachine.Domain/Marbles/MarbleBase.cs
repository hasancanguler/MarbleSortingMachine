using MarbleSortingMachine.Domain.Common;
using System.Drawing;

namespace MarbleSortingMachine.Domain.Marbles
{
    /// <summary>
    /// Sizes of the Diameter is mm.
    /// </summary>
    public class MarbleBase
    {
        public double HalfDiameter { get; set; }
        public double Density { get; set; }
        public Colors Color { get; set; }
        public MarbleBase(double halfDiameter, double density)  
        {
            HalfDiameter = halfDiameter;
            Density = density;
        }
    }
}
