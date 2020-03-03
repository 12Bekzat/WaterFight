using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Entities
{
    public class Ship : BaseEntity
    {
        public Direction Direction { get; set; }
        public int Type { get; set; }
        public int Health { get; set; }
        public int XCoor { get; set; }
        public int YCoor { get; set; }
        public bool IsAlive { get; set; }
        public char Symbol { get; set; }
        public bool[] IsDestroy { get; set; }
    }
}
