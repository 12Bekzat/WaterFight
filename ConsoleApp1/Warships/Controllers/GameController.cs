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
                XCoor = x,
                YCoor = y,
                IsAlive = true,
                Symbol = '○'
            };

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

        public bool TakeDamage(Ship ship)
        {
            if (ship != null)
            {
                ship.Health--;

                if (ship.Health <= 0)
                {
                    ship.IsAlive = false;
                }
                return true;
            }
            else return false;
        }

        public void Shoot(int x, int y)
        {
            if (!TakeDamage(CheckShoot(x, y)))
            {
                foreach (var c in _cells)
                {
                    if (c.X == x && c.Y == y)
                    {
                        c.IsAlive = false;
                        c.ViewSym = DESTROY_CELL;
                    }
                }
            }
        }

        public Ship CheckShoot(int xCoor, int yCoor)
        {
            foreach (var ship in _game.Ships)
            {
                for (int i = 0; i < ship.Type; i++)
                {
                    switch (ship.Direction)
                    {
                        case Direction.Up:
                            for (int y = yCoor, j = 0; y > yCoor - ship.Type + 1; y--)
                            {
                                j++;
                                if (xCoor == ship.XCoor && y == ship.YCoor && ship.IsDestroy[j] == true)
                                {
                                    ship.IsDestroy[j] = false;
                                    foreach (var c in _cells)
                                    {
                                        if (c.X == ship.XCoor && c.Y == ship.YCoor)
                                        {
                                            c.IsAlive = false;
                                            c.ViewSym = ship.Symbol;
                                        }
                                    }
                                    return ship;
                                }
                            }
                            break;
                        case Direction.Left:
                            for (int x = xCoor, j = 0; x < xCoor + ship.Type - 1; x++)
                            {
                                j++;
                                if (x == ship.XCoor && x == ship.YCoor && ship.IsDestroy[j] == true)
                                {
                                    ship.IsDestroy[j] = false;
                                    foreach (var c in _cells)
                                    {
                                        if (c.X == ship.XCoor && c.Y == ship.YCoor)
                                        {
                                            c.IsAlive = false;
                                            c.ViewSym = ship.Symbol;
                                        }
                                    }
                                    return ship;
                                }
                            }
                            break;
                        case Direction.Right:
                            for (int x = xCoor, j = 0; x > xCoor - ship.Type + 1; x--)
                            {
                                j++;
                                if (x == ship.XCoor && yCoor == ship.YCoor && ship.IsDestroy[j] == true)
                                {
                                    ship.IsDestroy[j] = false;
                                    foreach (var c in _cells)
                                    {
                                        if (c.X == ship.XCoor && c.Y == ship.YCoor)
                                        {
                                            c.IsAlive = false;
                                            c.ViewSym = ship.Symbol;
                                        }
                                    }
                                    return ship;
                                }
                            }
                            break;
                        case Direction.Down:
                            for (int y = yCoor, j = 0; y < yCoor + ship.Type - 1; y++)
                            {
                                j++;
                                if (xCoor == ship.XCoor && y == ship.YCoor && ship.IsDestroy[j] == true)
                                {
                                    ship.IsDestroy[j] = false;
                                    foreach (var c in _cells)
                                    {
                                        if (c.X == ship.XCoor && c.Y == ship.YCoor)
                                        {
                                            c.IsAlive = false;
                                            c.ViewSym = ship.Symbol;
                                        }
                                    }
                                    return ship;
                                }
                            }
                            break;
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
