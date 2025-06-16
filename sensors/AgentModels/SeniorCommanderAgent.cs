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
    }
}
