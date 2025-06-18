using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.GameFlow
{
    internal static class AskToExit
    {
        public static bool Exit()
        {
            Console.WriteLine("do you want to exit game?\nType (yes/no)");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                return true;
            }
            return false;
        }
    }
}
