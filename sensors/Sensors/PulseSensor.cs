using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.Sensors
{
    internal class PulseSensor : Sensor
    {
        public override string Name => "Pulse_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
            if (ActivationCount > 3)
            {
                IsBroken = true;
            }

        }
    }
}
