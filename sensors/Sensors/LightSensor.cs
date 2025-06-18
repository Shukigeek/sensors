using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.Sensors
{
    internal class LightSensor : Sensor, ISensorThatPrint
    {

        public override string Name => "Light_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
        }
        public void Print(Agent agent)
        {
            Console.WriteLine($"this agent is mamber in {agent.Organization}");
        }
        
    }
}
