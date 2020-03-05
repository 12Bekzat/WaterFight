using System;
using System.Collections.Generic;
using System.Text;
using Warships.Entities;

namespace Warships.Controllers
{
    public class GameController
    {
        private const char VIEW_CELL = '▒';
        private const char DESTROY_CELL = '▓';
        public Game _game { get; private set; }
        private List<Cell> _cells { get; set; } = new List<Cell>();
        public GameController(Game game)
        {
            _game = game;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    _cells.Add(new Cell { IsAlive = true, X = x, Y = y, ViewSym = VIEW_CELL });
                }
            }
        }

        public void AddShip(int health, int type, int x, int y, Direction direction)
        {
            Ship ship = new Ship
            {
                Health = health,
                Type = type,
                IsAlive = true,
                Symbol = '○'
            };

            ship.XCoor = new int[ship.Type - 1];
            ship.YCoor = new int[ship.Type - 1];

            for (int i = 0; i < ship.Type - 1; i++)
            {
                switch (ship.Direction)
                {
                    case Direction.Up:
                        ship.XCoor[i] = x;
                        ship.YCoor[i] = y - i;
                        break;
                    case Direction.Left:
                        ship.XCoor[i] = x + i;
                        ship.YCoor[i] = y;
                        break;
                    case Direction.Right:
                        ship.XCoor[i] = x - i;
                        ship.YCoor[i] = y;
                        break;
                    case Direction.Down:
                        ship.XCoor[i] = x;
                        ship.YCoor[i] = y + i;
                        break;
                }
            }


            ship.IsDestroy = new bool[type - 1];

            for (int i = 0; i < type - 1; i++)
            {
                ship.IsDestroy[i] = true;
            }

            switch (direction)
            {
                case Direction.Up:
                    if (y > type - 2)
                    {
                        ship.Direction = direction;
                    }
                    break;
                case Direction.Left:
                    if (x < type - 2)
                    {
                        ship.Direction = direction;
                    }
                    break;
                case Direction.Right:
                    if (x > type - 2)
                    {
                        ship.Direction = direction;
                    }
                    break;
                case Direction.Down:
                    if (y < type - 2)
                    {
                        ship.Direction = direction;
                    }
                    break;
            }

            _game.Ships.Add(ship);
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

        public void Shoot(int x, int y)
        {
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
            foreach (var ship in _game.Ships)
            {
                for (int i = 0; i < ship.Type - 1; i++)
                {
                    if (ship.XCoor[i] == xCoor && ship.YCoor[i] == yCoor)
                    {
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

        public void DrawCell(int xSt, int ySt)
        {
            for (int i = 0, k = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(xSt + j, ySt + i);
                    Console.Write(_cells[k].ViewSym);
                    k++;
                }
                Console.WriteLine();
            }
        }
    }
}
