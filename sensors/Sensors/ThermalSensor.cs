using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.Sensors
{
    internal class ThermalSensor : Sensor
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
            if (hidden.Count == 0) { return null; }
            return hidden[rand.Next(hidden.Count)];
        }
    }
}

