using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class SeniorCommanderAgent : Agent
    {
        //AgentType Type;
        //public List<Sensor> sensorSensitive;
        public override List<Sensor> sensorsAttached { set; get; }



        public SeniorCommanderAgent(AgentType type) : base(AgentType.Senior_Commander) { }
       

        public override void AttachSensor(Sensor sensor)
        {

            sensorsAttached.Add(sensor);

        }
        public override List<Sensor> CounterattackBehavior(int counter)
        {
            if (counter % 3 == 0)
            {
                if (sensorsAttached == null || sensorsAttached.Count == 0)
                    return null;
                List<Sensor> sensorToReturn = new List<Sensor>();
                Random random = new Random();
                int index1 = random.Next(sensorsAttached.Count);
                sensorToReturn.Add(sensorsAttached[index1]);
                sensorsAttached.RemoveAt(index1);

                if(sensorsAttached != null && sensorsAttached.Count > 0)
                {
                    int index2 = random.Next(sensorsAttached.Count);
                    sensorToReturn.Add(sensorsAttached[index2]);
                    sensorsAttached.RemoveAt(index2);
                }

                return sensorToReturn;

            }
            return null;
        }
    }
}
