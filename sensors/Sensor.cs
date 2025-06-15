using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal abstract class Sensor
    {
        int count;
        protected Sensor()
        {
            int count = 0;
            this.count = count;
        }
        public void Activet()
        {
            Console.WriteLine("sensor activeted");
            count++;
        }
    }
}
