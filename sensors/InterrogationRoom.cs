using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sensors
{
    internal class InterrogationRoom
    {
        Agent agent = new Agent("reguler");
        public Dictionary<string,int> GetSensorsList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (string senstype in agent.sensors)
            {
                if (!list.ContainsKey(senstype))
                {
                    list[senstype] = 1;
                }
                else
                {
                    list[senstype]++;
                }
            }return list;
        }
        public void interrogat()
        {
            int numberOfSensors = agent.sensorSensitive.Count;
            Dictionary<string, int> list = GetSensorsList();
            Console.WriteLine("Interrogation start");
            Console.WriteLine($"you have to find {numberOfSensors} \nsensor to activet on this agent");
            for (int i = 0; i < numberOfSensors; i++) 
            {
                Console.WriteLine($"choose number {i+1} sensor");
                string chioce = Console.ReadLine();
                if (list.ContainsKey(chioce)) 
                {
                    Console.WriteLine("nice goob");
                    list[chioce]--;
                    if (list[chioce] == 0)
                    {
                        list.Remove(chioce);
                    }
                }
                else
                {
                    Console.WriteLine("worng choice");
                }
                Console.WriteLine($"you found {i + 1} sensors out of {numberOfSensors}");
            }Console.WriteLine("congrats you matched all sensors");
        }
    }
}
