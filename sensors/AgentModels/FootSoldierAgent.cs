using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class FootSoldierAgent : Agent
    {
        public override List<Sensor> sensorsAttached { set; get; }



        public FootSoldierAgent(AgentType type) : base(AgentType.Foot_Soldier) { }


        public override void AttachSensor(Sensor sensor)
        {

            sensorsAttached.Add(sensor);

        }
        public override List<Sensor> CounterattackBehavior(int counter) { return null; }
    }
}
