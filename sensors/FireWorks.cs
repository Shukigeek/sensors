using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sensors
{
    internal class FireWorks
    {
        public FireWorks() 
        {

            Console.CursorVisible = false;

            string[] fireworks = new string[]
            {
            "     .",
            "    ...",
            "   ..*..",
            "  .*****.",
            "   ..*..",
            "    ...",
            "     .",
            "      "
            };

            ConsoleColor[] colors = new ConsoleColor[]
            {
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.White
            };

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            Random rand = new Random();

            for (int explosion = 0; explosion < 10; explosion++)
            {
                int posX = rand.Next(10, width - 10);
                int posY = rand.Next(5, height - fireworks.Length - 5);

                for (int frame = 0; frame < fireworks.Length; frame++)
                {
                    Console.Clear();

                    Console.ForegroundColor = colors[frame % colors.Length];

                    for (int i = 0; i <= frame; i++)
                    {
                        int y = posY + i;
                        int x = posX;

                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(fireworks[i]);
                    }

                    Thread.Sleep(150);
                }

                // קצת ריספקט לפריים בין הפיצוצים
                Thread.Sleep(400);
            }

            Console.ResetColor();
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, height - 1);
        }
    }
}

