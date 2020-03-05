﻿namespace Warships.Entities
{
    public class Cell : BaseEntity
    {
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char ViewSym { get; set; }
        public bool IsShot { get; set; }
    }
}