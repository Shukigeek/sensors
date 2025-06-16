using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal static class SensorService
    {
        public static Sensor Audio = new AudioSensor();
        public static Sensor Thermal= new ThermalSensor();
        public static Sensor Pulse = new PulseSensor();
        public static Sensor Motion = new MotionSensor();
        public static Sensor Magnetic = new Magnetic();
        public static Sensor signal = new SignalSensor();
        public static Sensor Light = new LightSensor();
        public static List<Sensor> sensors = new List<Sensor>()
        {
            Audio,Thermal, Pulse, Motion, Magnetic,signal, Light
        };
        
        public static List<Sensor> GetSensorsSet(AgentType type)
        {
            Random random = new Random();
            List<Sensor> sensorSensitive = new List<Sensor>();
            int count = GetNumberOfSensitiveSensors(type);
            for (int i = 0; i < count; i++)
            {
                sensorSensitive.Add(sensors[random.Next(sensors.Count)]);
            }
            return sensorSensitive;

        }

        public static int GetNumberOfSensitiveSensors(AgentType type)
        {
            switch (type)
            {
                case AgentType.Foot_Soldier:
                    return 2;
                case AgentType.Squad_Leader:
                    return 4;
                case AgentType.Senior_Commander:
                    return 6;
                case AgentType.Organization_Leader:
                    return 8;
                default:
                    return 2;
            }
        }
        public static string PrintSensors()
        {
            int count = 1;
            string res = "";
            foreach (Sensor sensor in sensors)
            {
                res += $"{count}: {sensor.Name}.\n";
                ++count;
            }return res;
        }
    }
}
