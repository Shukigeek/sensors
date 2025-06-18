using sensors.AgentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.Sensors;

namespace sensors
{
    internal class SeniorCommanderAgent : Agent
    {
        public int Rank;
        public string Organization;
        Random random = new Random();
        public override List<Sensor> sensorsAttached { set; get; }



        public SeniorCommanderAgent(AgentType type) : base(AgentType.Senior_Commander) 
        {
            Rank = random.Next(1, 10);
            Organization = GetAffiltion.Affiletion();
        }
       

        public override void AttachSensor(Sensor sensor)
        {

            sensorsAttached.Add(sensor);

        }
        public override List<Sensor> CounterattackBehavior(int counter)
        {
            if (counter % 3 == 0)
            {
                 var magneticSensor = sensorsAttached.OfType<Magnetic>()
                    .FirstOrDefault(s => s.CanBlockCounterAttack());
                if (magneticSensor != null)
                {
                    magneticSensor.UseBlock();
                    Console.WriteLine("magnetic sensor block one counterAttack");
                    return null;
                } 
                if (sensorsAttached == null || sensorsAttached.Count == 0)
                    return null;
                List<Sensor> sensorToReturn = new List<Sensor>();
                Random random = new Random();
                int index1 = random.Next(sensorsAttached.Count);
                sensorToReturn.Add(sensorsAttached[index1]);
                sensorsAttached.RemoveAt(index1);
                Console.WriteLine("the agent counter attck and unattached 1 sensor");

                if(sensorsAttached != null && sensorsAttached.Count > 0)
                {
                    int index2 = random.Next(sensorsAttached.Count);
                    sensorToReturn.Add(sensorsAttached[index2]);
                    sensorsAttached.RemoveAt(index2);
                    Console.WriteLine("the agent counter attck and unattached the seconed sensor");

                }

                return sensorToReturn;

            }
            return null;
        }
    }
}
