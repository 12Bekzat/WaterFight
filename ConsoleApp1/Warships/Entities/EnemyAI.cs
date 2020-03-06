using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Entities
{
	public class EnemyAI
	{
		public void Attack(List<Cell> _cells)
        {
            Random rnd = new Random();
            int x, y;
            x = rnd.Next(10); // от 0 до 9
            y = rnd.Next(10);

            Ship victim = new Ship();
            Cell victimCell = new Cell();
            foreach (var cell in _cells)
            {
                if (cell.X == x && cell.Y == y)
                {
                    victim = CheckShoot(x, y, ref victimCell);
                    TakeDamage(victim);
                    break;
                }
            }
            foreach (var c in _cells)
            {
                if (c.X == x && c.Y == y && victimCell.IsShot == true)
                {
                    c.IsAlive = false;
                    c.ViewSym = victimCell.ViewSym;
                }
                if (c.X == x && c.Y == y && victimCell.IsShot == false)
                {
                    c.IsAlive = false;
                    c.ViewSym = DESTROY_CELL;
                }
            }
        }

        public Ship CheckShoot(int xCoor, int yCoor, ref Cell cell)
        {
            int c = 0;
            foreach (var ship in _game.Ships)
            {
                for (int i = 0; i < ship.Type; i++)
                {
                    if (ship.XCoor[i] == xCoor && ship.YCoor[i] == yCoor)
                    {
                        c = 1;
                        cell.ViewSym = ship.Symbol;
                        cell.X = xCoor;
                        cell.Y = yCoor;
                        cell.IsShot = true;
                        return ship;
                    }
                }
            }
            return null;
        }

        public void TakeDamage(Ship ship)
        {
            if (ship != null)
            {
                ship.Health--;

                if (ship.Health <= 0)
                {
                    ship.IsAlive = false;
                }
            }
        }

    }
}
