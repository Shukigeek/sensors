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
            InterrogationRoom room = new InterrogationRoom();
            room.interrogat();


            //var s1 = SensorService.CreateAudioSensor();
            //var s2 = SensorService.CreateAudioSensor();

            //Console.WriteLine(s1.Name == s2.Name);
            //Console.WriteLine(s1 == s2); // ➜ False
            //Console.WriteLine(ReferenceEquals(s1, s2)); // ➜ F
        }

    }
}
