using System;
using System.Collections.Generic;
using System.Text;
using Warships.Interfaces;

namespace Warships.Entities
{
    public class Game : BaseEntity, IGameRepository
    {
        public IList<Ship> Ships { get; set; } = new List<Ship>();
        public User Player { get; set; }
    }
}
