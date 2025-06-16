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
        Agent FootSoldier = new FootSoldierAgent(AgentType.Foot_Soldier);
        Agent SquadLeader = new SquadLeaderAgent(AgentType.Squad_Leader);
        Agent SeniorCommander = new SeniorCommanderAgent(AgentType.Senior_Commander);
        Agent OrganizationLeader = new OrganizationLeaderAgent(AgentType.Organization_Leader);

        public Dictionary<Sensor,int> GetSensorsList(Agent agent)
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
            Agent agent = FootSoldier;
            int numberOfSensors = agent.sensorSensitive.Count;
            Dictionary<Sensor, int> list = GetSensorsList(agent);
            Console.WriteLine("Interrogation start");
            Console.WriteLine($"you have to find {numberOfSensors} \nsensor to activet on this agent");


            while (agent.sensorsAttached == null || agent.sensorsAttached.Count < agent.sensorSensitive.Count)
            {
                bool choiceValidtion = true;
                Sensor sens = Menu();
                if(sens != null ) choiceValidtion = false;
                while (choiceValidtion)
                {
                    Console.WriteLine("enter number between 1-7 only");
                    sens = Menu();
                    if (sens != null) choiceValidtion = false;
                }
                sens.Activate();
                if (!sens.IsBroken)
                {
                    if (list.ContainsKey(sens))
                    {
                        Console.Clear();
                        Console.WriteLine($"nice goob one of the agent sensetive sesors is: {sens}");
                        agent.AttachSensor(sens);
                        list[sens]--;
                        if (list[sens] == 0)
                        {
                            list.Remove(sens);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"worng choice the agent is not sensetive to {sens}");
                    }
                    Console.WriteLine($"you found {agent.sensorsAttached.Count} sensors out of {numberOfSensors}");
                }
                else
                {
                    Console.WriteLine($"{sens.Name} is broken you could not use it any more");
                    if (list.ContainsKey(sens))
                    {
                        Console.WriteLine("you lost!!");
                        return;
                    }
                }
                if (agent.sensorsAttached != null && agent.sensorsAttached.Count == agent.sensorSensitive.Count)
                {
                    Console.WriteLine("congrats you matched all sensors");
                }
            }
        }

        public Sensor Menu()
        {
            Console.WriteLine($"choose number sensor from list\n{SensorService.PrintSensors()}");
            string choice = Console.ReadLine();
            switch (choice) 
            {
                case "1":
                    return SensorService.Audio;
                case "2":
                    return SensorService.Thermal;
                case "3":
                    return SensorService.Pulse;
                case "4":
                    return SensorService.Motion;
                case "5":
                    return SensorService.Magnetic;
                case "6":
                    return SensorService.signal;
                case "7":
                    return SensorService.Light;
                default: return null;

            }
        }
    }
}
