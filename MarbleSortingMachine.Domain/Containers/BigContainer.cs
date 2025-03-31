namespace MarbleSortingMachine.Domain.Containers
{
    /// <summary>
    /// Represents a big container that can hold marbles.
    /// width, height and depth are all 1500mm.
    /// </summary>
    public class BigContainer : ContainerBase
    {
        private static readonly int width = 1500;
        private static readonly int height = 1500;
        private static readonly int depth = 1500;
        public BigContainer() : base(width, height, depth)
        {
        }
    }
}
