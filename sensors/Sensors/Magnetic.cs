using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.Sensors
{
    internal class Magnetic : Sensor
    {
        public override string Name => "Magnetic";
        private int remainingBlocks = 2;

        public bool CanBlockCounterAttack()
        {
            return remainingBlocks > 0;
        }

        public void UseBlock()
        {
            if (remainingBlocks > 0)
                remainingBlocks--;
        }

        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
}
