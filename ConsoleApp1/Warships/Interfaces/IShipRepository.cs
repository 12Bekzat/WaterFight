using System;
using System.Collections.Generic;
using System.Text;
using Warships.Entities;

namespace Warships.Interfaces
{
	public interface IShipRepository
	{
        public Direction Direction { get; set; }
        public int Type { get; set; }
        public int Health { get; set; }
        public int[] XCoor { get; set; }
        public int[] YCoor { get; set; }
        public bool IsAlive { get; set; }
        public char Symbol { get; set; }
        public bool[] IsDestroy { get; set; }
    }
}
