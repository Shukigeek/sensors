using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    abstract class Sensor
    {
        protected int ActivationCount;
        public bool IsBroken { get; protected set; } = false;
        //public Sensor()
        //{
        //    ActivetionCount = 0;
        //}
        public abstract string Name {get; }

        public abstract void Activate();
        //public abstract void RevealsOneSecreat();


    }
    class AudioSensor : Sensor
    {
        public override string Name => "Audio_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
    class ThermalSensor : Sensor
    {
        
        public override string Name => "Thermal_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
        public Sensor RevealsOneSecreatSensor(Agent agent)
        {
            Random rand = new Random();
            var hidden = agent.sensorSensitive
                         .Where(s => !agent.sensorsAttached.Contains(s))
                         .ToList();
            if(hidden.Count == 0 ) { return null;}
            return hidden[rand.Next(hidden.Count)];
        }
    }
    class PulseSensor : Sensor
    {
        public override string Name => "Pulse_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
            if (ActivationCount >= 3)
            {
                IsBroken = true;
            }

        }

    }
    class MotionSensor : Sensor
    {
        public override string Name => "Motion_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
            if (ActivationCount >= 3) 
            {
                IsBroken = true;
            }

        }
    }
    class Magnetic : Sensor
    {
        public override string Name => "Magnetic";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
    class SignalSensor : Sensor
    {
        public override string Name => "Signal_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
    class LightSensor : Sensor
    {
        public override string Name => "Light_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
}
