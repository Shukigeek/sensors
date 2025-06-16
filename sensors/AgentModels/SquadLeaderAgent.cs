using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class SquadLeaderAgent : Agent
    {
        public override List<Sensor> sensorsAttached { set; get; }



        public SquadLeaderAgent(AgentType type) : base(AgentType.Squad_Leader) { }


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
                int index = random.Next(sensorsAttached.Count);
                sensorToReturn.Add(sensorsAttached[index]);
                sensorsAttached.RemoveAt(index);
                return sensorToReturn;
            }
            return null;
        }
    }
}
