using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    enum AgentType
    {
        Foot_Soldier,
        Squad_Leader,
        Senior_Commander,
        Organization_Leader
    }
    abstract class Agent
    {
        AgentType Type;
        public List<Sensor> sensorSensitive { get; set; }
        public abstract List<Sensor> sensorsAttached { set; get; }


        protected Agent(AgentType type)
        {
            Type = type;
            sensorSensitive = SensorService.GetSensorsSet(type);

        }

        public void AttachSensor(Sensor sensor)
        {

    }
}
