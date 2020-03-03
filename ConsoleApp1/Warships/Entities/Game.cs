using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Entities
{
    public class Game : BaseEntity
    {
        public IList<Ship> Ships { get; set; } = new List<Ship>();
        public IList<Cell> Cells { get; set; } = new List<Cell>();
        public User Player { get; set; }
    }
}
