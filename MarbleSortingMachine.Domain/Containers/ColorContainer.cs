using MarbleSortingMachine.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleSortingMachine.Domain.Containers
{
    public class ColorContainer : ContainerBase
    {
        private static readonly int width = 1500;
        private static readonly int height = 1500;
        private static readonly int depth = 1500;
        public Colors Color { get; set; }
        public ColorContainer(Colors color) : base(width, height, depth)
        {
            Color = color;
        }


    }
}
