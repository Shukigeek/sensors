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
    }
}
