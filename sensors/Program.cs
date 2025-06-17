using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sensors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InterrogationRoom room = new InterrogationRoom();
            //room.interrogat();
            //FireWorks fireWorks = new FireWorks();
            
            VictoryShimmerEffect();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            

            void VictoryShimmerEffect()
            {
                string victoryMessage = "🎉 YOU WIN! 🎉";
                ConsoleColor[] colors = new ConsoleColor[]
                {
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.White
                };

                for (int i = 0; i < 10; i++)
                {
                    Console.Clear();

                    // צבע משתנה לפי איטרציה
                    Console.ForegroundColor = colors[i % colors.Length];

                    // הדפסה של כוכבים בצדדים עם אפקט "זוהר"
                    string stars = new string('*', i % 6 + 1);
                    Console.WriteLine($"{stars} {victoryMessage} {stars}");

                    Thread.Sleep(300); // השהייה להדגשת האפקט
                }

                // אחרי הלולאה, הדפס את ההודעה בצבע זהב קבוע
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"***** {victoryMessage} *****");
                Console.ResetColor();
            }
        }
        //var s1 = SensorService.CreateAudioSensor();
        //var s2 = SensorService.CreateAudioSensor();

        //Console.WriteLine(s1.Name == s2.Name);
        //Console.WriteLine(s1 == s2); // ➜ False
        //Console.WriteLine(ReferenceEquals(s1, s2)); // ➜ F
    }

    }
//}
