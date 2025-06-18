using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.Sensors
{
    internal class AudioSensor : Sensor
    {

        public override string Name => "Audio_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
}

