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
        public List<Sensor> sensorSensitive;
        public override List<Sensor> sensorsAttachet { set; get; }
        


        public SeniorCommanderAgent(AgentType type) : base(type)
        {
            //Type = type;
            sensorSensitive = SensorService.GetSensorsSet(type);

        }
    }
}
