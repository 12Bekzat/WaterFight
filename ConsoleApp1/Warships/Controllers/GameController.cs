using System;
using System.Collections.Generic;
using System.Text;
using Warships.Entities;

namespace Warships.Controllers
{
    public class GameController
    {
        public Game _game { get; private set; }
        public GameController(Game game)
        {
            _game = game;
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
                Symbol = (char)9
            };

            ship.IsDestroy = new bool[type - 1];

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
            TakeDamage(CheckShoot(x, y));
            _game.Cells.Add(new Cell { IsAlive = false, X = x, Y = y });
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
                                    return ship;
                                }
                            }
                            break;
                    }
                }
            }
            return null;
        }

        public void Draw()
        {

        }
    }
}
