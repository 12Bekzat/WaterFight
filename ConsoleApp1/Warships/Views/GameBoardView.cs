using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Views
{
    public class GameBoardView
    {

        public void DrawBorder(int xSt, int ySt, int maxX, int maxY)

        {
            for (int x = 0; x < maxX; x++)
            {
                Console.SetCursorPosition(xSt + x + 1, ySt);
                Console.Write($"{x}");
            }
            for (int y = 0; y < maxY; y++)
            {
                if (y != 0 || y != maxY - 1)
                {
                    Console.SetCursorPosition(xSt, ySt + y + 1);
                    Console.Write(y);
                }
                for (int x = 0; x < maxX; x++)
                {
                    Console.SetCursorPosition(xSt + x + 1, ySt + y + 1);
                    Console.Write(" ");
                }
            }
        }
    }
}
