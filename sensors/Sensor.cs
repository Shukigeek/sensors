using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    abstract class Sensor
    {
        protected int ActivetionCount;
        public Sensor()
        {
            ActivetionCount = 0;
        }
        public abstract string Name {get; }

        public bool Activet()
        {
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");
            ActivetionCount++;
            return true;
        }
    }
    class AudioSensor : Sensor
    {
        public override string Name => "Audio_Sensor";
    }
    class ThermalSensor : Sensor
    {
        public override string Name => "Thermal_Sensor";
    }
    class PulseSensor : Sensor
    {
        public override string Name => "Pulse_Sensor";
    }
    class MotionSensor : Sensor
    {
        public override string Name => "Motion_Sensor";
    }
    class Magnetic : Sensor
    {
        public override string Name => "Magnetic";
    }
    class SignalSensor : Sensor
    {
        public override string Name => "Signal_Sensor";
    }
    class LightSensor : Sensor
    {
        public override string Name => "Light_Sensor";
    }
}
