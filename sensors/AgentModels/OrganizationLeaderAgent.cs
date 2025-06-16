using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class OrganizationLeaderAgent : Agent
    {
        public override List<Sensor> sensorsAttached { set; get; }



        public OrganizationLeaderAgent(AgentType type) : base(AgentType.Organization_Leader) { }


        public override void AttachSensor(Sensor sensor)
        {

            sensorsAttached.Add(sensor);

        }
    }
}
