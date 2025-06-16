using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sensors
{
    internal class InterrogationRoom
    {
        Agent agent = new SeniorCommanderAgent(AgentType.Senior_Commander);
        public Dictionary<Sensor,int> GetSensorsList()
        {
            Dictionary<Sensor, int> list = new Dictionary<Sensor, int>();
            foreach (var senstype in agent.sensorSensitive)
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
            Dictionary<Sensor, int> list = GetSensorsList();
            Console.WriteLine("Interrogation start");
            Console.WriteLine($"you have to find {numberOfSensors} \nsensor to activet on this agent");

            
            while(agent.sensorsAttached.Count < agent.sensorSensitive.Count) 
            {

                Sensor sens = Menu();
                sens.Activet();
                if (list.ContainsKey(sens)) 
                {
                    Console.WriteLine("nice goob");
                    agent.AttachSensor(sens);
                    list[sens]--;
                    if (list[sens] == 0)
                    {
                        list.Remove(sens);
                    }
                }
                else
                {
                    Console.WriteLine("worng choice");
                }
                Console.WriteLine($"you found {agent.sensorsAttached.Count} sensors out of {numberOfSensors}");
            }Console.WriteLine("congrats you matched all sensors");
        }

        public Sensor Menu()
        {
            Console.WriteLine($"choose number sensor from list\n {SensorService.PrintSensors()}");
            string choice = Console.ReadLine();
            switch (choice) 
            {
                case "1":
                    return new AudioSensor();
                case "2":
                    return new ThermalSensor();
                case "3":
                    return new PulseSensor();
                case "4":
                    return new MotionSensor();
                case "5":
                    return new Magnetic();
                case "6":
                    return new SignalSensor();
                case "7":
                    return new LightSensor();
                default: return null;

            }
        }
    }
}
