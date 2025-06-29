﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using sensors.DataBase;
using sensors.GameFlow;
using sensors.Sensors;
namespace sensors
{
   
    internal class InterrogationRoom
    {
        BestScore bestScore = new BestScore();
        bool finishLevel = false;
        public Dictionary<Sensor, int> GetSensorsList(Agent agent)
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
            }
            return list;
        }

        public (Dictionary<Sensor,int> list,int numberOfSensors)  InterrogationStart(Agent agent)
        {
            
            int numberOfSensors = agent.sensorSensitive.Count;
            Dictionary<Sensor, int> list = GetSensorsList(agent);
            Console.WriteLine("\nInterrogation start");
            Console.WriteLine($"you have to find {numberOfSensors} sensor to activet on this agent\n");
            return (list, numberOfSensors);
        }

        public Sensor ChosseSensor()
        {
            Sensor chosenSensor = null;
            while (chosenSensor == null)
            {
                Console.WriteLine($"Enter a number between 1-7 to choose a sensor:");
                chosenSensor = Menu.ShowMenu();
                if (chosenSensor == null)
                {
                    
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
            return chosenSensor;
        }

        public void ActivateAndRemoveBroken(Agent agent,Dictionary<Sensor,int> list)
        {
            foreach (var sensor in agent.sensorsAttached.ToList())
            {
                sensor.Activate();
                if (sensor.IsBroken)
                {
                    Console.WriteLine($"{sensor.Name} is broken you could not use it any more\n and it been removed from attached sensors");
                    agent.sensorsAttached.Remove(sensor);
                    string name = sensor.Name;
                    foreach (Sensor type in SensorService.sensors)
                    {
                        if (type.Name == name)
                        {
                            if (list.ContainsKey(type))
                            {
                                list[type] += 1;
                            }
                            else
                            {
                                list.Add(type, 1);
                            }
                        }
                    }
                }
            }
        }
        
        public void ProcessChioce(Agent agent,Sensor sens,Dictionary<Sensor,int> list,int numberOfSensors)
        {
            if (list.ContainsKey(sens))
            {             
                Console.WriteLine($"\nnice goob one of the agent sensetive sensors is: {sens.Name}");
                agent.AttachSensor(sens);
                if (sens is ThermalSensor thermalSensor)
                {
                    Sensor reveal = thermalSensor.RevealsOneSecreatSensor(agent);
                    if (reveal != null)
                    {
                        Console.WriteLine($"Hint: one of the remaining sensitive sensors is: {reveal.Name}");
                    }
                }
                if(sens is ISensorThatPrint s)
                {
                    s.Print(agent);
                }
                list[sens]--;
                if (list[sens] == 0)
                {
                    list.Remove(sens);
                }
            }
            else
            {
                //Console.Clear();
                Console.WriteLine($"\nworng choice the agent is not sensetive to {sens.Name}");
            }
            Console.WriteLine($"you found {agent.sensorsAttached.Count} sensors out of {numberOfSensors}\n");

            if (agent.sensorsAttached != null && agent.sensorsAttached.Count == agent.sensorSensitive.Count)
            {
                Console.WriteLine("congrats you matched all sensors");
                
            }
            
        }
        public int InterrogateAgent(Agent agent)
        {
            var agentSattings = InterrogationStart(agent);
            Dictionary<Sensor, int> list = agentSattings.list;
            int numberOfSensors = agentSattings.numberOfSensors;

            int turn = 0;
            while (agent.sensorsAttached == null || agent.sensorsAttached.Count < agent.sensorSensitive.Count)
            {
                turn++;
                List<Sensor> addSensor = agent.CounterattackBehavior(turn);
                if (addSensor != null && addSensor.Count > 0)
                {
                    for (int i = 0; i < addSensor.Count; i++)
                    {
                        if (list.ContainsKey(addSensor[i]))
                        {
                            list[addSensor[i]]++;

                        }
                        else
                        {
                            list[addSensor[i]] = 1;

                        }
                    }
                }
                Sensor sens = ChosseSensor();
                ActivateAndRemoveBroken(agent, list);
                ProcessChioce(agent, sens, list, numberOfSensors);
                if (turn > 9)
                {
                    Console.WriteLine("turn limit execded");
                    break;
                }
            }

            if (agent.sensorsAttached.Count == agent.sensorSensitive.Count)
            {
                CalcoletScore calc = new CalcoletScore();
                int score = calc.Score(agent, turn);
                finishLevel = true;
                return score;
            }
            return 0;
        }

    }
}
