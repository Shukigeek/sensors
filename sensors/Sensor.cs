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
        public bool IsBroken { get; protected set; } = false;
        //public Sensor()
        //{
        //    ActivetionCount = 0;
        //}
        public abstract string Name {get; }

        public abstract void Activate();
        
    }
    class AudioSensor : Sensor
    {
        public override string Name => "Audio_Sensor";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
    class ThermalSensor : Sensor
    {
        public override string Name => "Thermal_Sensor";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
    class PulseSensor : Sensor
    {
        public override string Name => "Pulse_Sensor";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
    class MotionSensor : Sensor
    {
        public override string Name => "Motion_Sensor";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
    class Magnetic : Sensor
    {
        public override string Name => "Magnetic";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
    class SignalSensor : Sensor
    {
        public override string Name => "Signal_Sensor";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
    class LightSensor : Sensor
    {
        public override string Name => "Light_Sensor";
        public override void Activate()
        {
            ActivetionCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivetionCount} times");

        }
    }
}
