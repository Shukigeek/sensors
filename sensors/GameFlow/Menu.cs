using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.Sensors;

namespace sensors
{
    internal static class Menu
    {
        public static Sensor ShowMenu()
        {
            Console.WriteLine($"choose number sensor from list\n{SensorService.PrintSensors()}");
            string choice = Console.ReadLine();
            //זה לא עומד בהגדרת open/close
            switch (choice)
            {
                case "1":
                    return new AudioSensor();
                case "2":
                    return new ThermalSensor();
                case "3":
                    return new PulseSensor();
                case "4":
                    return new MotionSensor();
                case "5":
                    return new Magnetic();
                case "6":
                    return new SignalSensor();
                case "7":
                    return new LightSensor();
                default: return null;

            }
        }
    }
}
