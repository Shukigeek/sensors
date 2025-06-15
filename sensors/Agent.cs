using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    internal class Agent
    {
        string Type;
        public List<string> sensorSensitive { set; get; }
        public string[] sensors = { "basic", "thermal" };
        Random random = new Random();
        public Agent(string type) 
        {
            Type = type;
            if (Type == "reguler")
            {
                sensorSensitive = new List<string>();
                for (int i = 0; i < 2; i++)
                {
                    sensorSensitive.Add(sensors[random.Next((sensors.Length))]);
                }
            }
        }
    }
}
