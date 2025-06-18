using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.Sensors;

namespace sensors
{
    internal static class SensorService
    {
        public static Sensor CreateAudioSensor() => new AudioSensor();
        public static Sensor CreateThermalSensor() => new ThermalSensor();
        public static Sensor CreatePulseSensor() => new PulseSensor();
        public static Sensor CreateMotionSensor() => new MotionSensor();
        public static Sensor CreateMagneticSensor() => new Magnetic();
        public static Sensor CreateSignalSensor() => new SignalSensor();
        public static Sensor CreateLightSensor() => new LightSensor();

        public static List<Sensor> sensors = new List<Sensor>()
        {
            CreateAudioSensor(),
            CreateThermalSensor(),
            CreatePulseSensor(),
            CreateMotionSensor(),
            CreateMagneticSensor(),
            CreateSignalSensor(),
            CreateLightSensor()
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
