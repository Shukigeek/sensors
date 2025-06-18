using sensors.AgentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sensors
{
    internal class SquadLeaderAgent : Agent
    {
        public override List<Sensor> sensorsAttached { set; get; }

        public int Rank;
        public string Organization;
        Random random = new Random();

        public SquadLeaderAgent(AgentType type) : base(AgentType.Squad_Leader) 
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
                if (sensorsAttached == null || sensorsAttached.Count == 0)
                    return null;
                if (magneticSensor != null)
                {
                    magneticSensor.UseBlock();
                    Console.WriteLine("magnetic sensor block one counterAttack");
                    return null;

                }
                List<Sensor> sensorToReturn = new List<Sensor>();
                Random random = new Random();
                int index = random.Next(sensorsAttached.Count);
                sensorToReturn.Add(sensorsAttached[index]);
                sensorsAttached.RemoveAt(index);
                Console.WriteLine("agent counter attack and unattached 1 sensor");
                return sensorToReturn;
            }
            return null;
        }
    }
}
