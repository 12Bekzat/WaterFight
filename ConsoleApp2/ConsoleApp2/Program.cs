using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] X = new int[4];
            int[] Y = new int[4];
            int direct = 1;
            int x = 0, y = 0;

            for (int i = 0; i < 4; i++)
            {
                switch (direct)
                {
                    case 0:
                        X[i] = x;
                        Y[i] = y - i;
                        break;
                    case 1:
                        X[i] = x + i;
                        Y[i] = y;
                        break;
                    case 2:
                        X[i] = x - i;
                        Y[i] = y;
                        break;
                    case 3:
                        X[i] = x;
                        Y[i] = y + i;
                        break;
                }
            }

            Console.WriteLine("X : Y");

            for (int i = 0; i < 4; i++)
                Console.WriteLine($"{X[i]} : {Y[i]}");
        }
    }
}
