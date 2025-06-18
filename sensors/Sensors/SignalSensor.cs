using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.Sensors
{
    internal class SignalSensor : Sensor, ISensorThatPrint
    {

        public override string Name => "Signal_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
        }
        public void Print(Agent agent)
        {
            Console.WriteLine($"this agent rank: {agent.Rank}");
        }
        
    }
}
