using System;
using System.Collections.Generic;
using System.Text;
using Warships.Entities;
using Warships.Views;

namespace Warships.Controllers
{
    public class GameController
    {
        private const char VIEW_CELL = '▒';
        private const char DESTROY_CELL = '▓';
        private const char SHIP_CELL = 'o';
        public Game _game { get; private set; }
        public List<CellState> _cells { get; set; } = new List<CellState>();
        public GameController(Game game)
        {
            _game = game;
            InitGameBoard();
        }

        private void InitGameBoard()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    _cells.Add(new CellState { Cell = new Cell { IsAlive = true, X = x, Y = y } , State = VIEW_CELL });
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

            ship.XCoor = new int[type];
            ship.YCoor = new int[type];

            _cells.Find(x => x.);

            for (int i = 0; i < type; i++)
            {
                if (direction == Direction.Up)
                {
                    ship.XCoor[i] = x;
                    ship.YCoor[i] = y - i;
                }
                else if (direction == Direction.Left)
                {
                    ship.XCoor[i] = x + i;
                    ship.YCoor[i] = y;
                }
                else if (direction == Direction.Right)
                {
                    ship.XCoor[i] = x - i;
                    ship.YCoor[i] = y;
                }
                else if (direction == Direction.Down)
                {
                    ship.XCoor[i] = x;
                    ship.YCoor[i] = y + i;
                }
            }


            ship.IsDestroy = new bool[type];

            for (int i = 0; i < type; i++)
            {
                ship.IsDestroy[i] = true;
            }

            ship.Direction = direction;

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
                    for(int i = 0; i < _cells.Count; i++)
                    {
                        if(_cells[i].IsShip)
                        {
                            _cells.Find
                        }
                    }
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
                if (c.X == x && c.Y == y && victimCell.IsShip == true)
                {
                    c.IsAlive = false;
                    c.IsShip = true;
                    c.ViewSym = victimCell.ViewSym;
                }
                if (c.X == x && c.Y == y && victimCell.IsShip == false)
                {
                    c.IsAlive = false;
                    c.IsShip = false;
                    c.ViewSym = DESTROY_CELL;
                }
            }
        }

        public Ship CheckShoot(int xCoor, int yCoor, ref Cell cell)
        {
            foreach (var ship in _game.Ships)
            {
                for (int i = 0; i < ship.Type; i++)
                {
                    if (ship.XCoor[i] == xCoor && ship.YCoor[i] == yCoor)
                    {
                        cell.ViewSym = ship.Symbol;
                        cell.X = xCoor;
                        cell.Y = yCoor;
                        cell.IsShip = true;
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
