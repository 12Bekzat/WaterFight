using System;
using System.Collections.Generic;
using System.Text;
using Warships.Interfaces;

namespace Warships.Entities
{
    public class Game : BaseEntity
    {
        public EnemyBoard EnemyBoard { get; set; }
        public MyBoard MyBoard { get; set; }
    }
}
