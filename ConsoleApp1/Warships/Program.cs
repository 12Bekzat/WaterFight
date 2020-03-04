using System;
using Warships.Controllers;
using Warships.Entities;
using Warships.Views;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoardView border = new GameBoardView();
            GameController controller = new GameController(new Game());

            controller.AddShip(4, 4, 0, 0, Direction.Left);
            controller.AddShip(3, 3, 3, 0, Direction.Down);
            controller.AddShip(3, 3, 3, 3, Direction.Down);
            controller.AddShip(2, 2, 2, 6, Direction.Left);
            controller.AddShip(2, 2, 0, 9, Direction.Up);
            controller.AddShip(2, 2, 5, 6, Direction.Left);
            controller.AddShip(1, 1, 9, 9, Direction.Up);
            controller.AddShip(1, 1, 7, 0, Direction.Left);
            controller.AddShip(1, 1, 6, 4, Direction.Left);
            controller.AddShip(1, 1, 3, 8, Direction.Left);

            while (true)
            {

                border.DrawBorder(0, 0, 10, 10);
                controller.DrawCell(1, 1);

                Console.SetCursorPosition(0, Console.WindowHeight - 4);
                Console.WriteLine("Введите координаты: ");
                if (int.TryParse(Console.ReadLine(), out var x) && int.TryParse(Console.ReadLine(), out var y))
                {

                    controller.Shoot(x, y);
                }
                Console.Clear();
            }

            Console.ReadLine();
        }
    }
}
