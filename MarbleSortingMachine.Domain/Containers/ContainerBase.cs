using MarbleSortingMachine.Domain.Marbles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleSortingMachine.Domain.Containers
{
    /// <summary>
    /// Sizes of the container are given in mm.
    /// </summary>
    public class ContainerBase
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public long Depth { get; set; }
        public long Volume { get;  }
        public long Capasity { get; set; }
        public long CurrentAmount { get; set; }
        public List<MarbleBase> Marbles { get; set; } = [];
        protected ContainerBase(long width, long height, long depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            Volume = width * height * depth;
        }
    }
}
