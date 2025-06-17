using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors
{
    abstract class Sensor
    {
       
        public int ActivationCount;
        public bool IsBroken { get; protected set; } = false;
        public Sensor()
        {
            this.ActivationCount = 0;
        }
        public abstract string Name {get; }

        public abstract void Activate();

        //הפונקציה הזו והבאה אחריה זה כדי להשוות שני מופעים שונים של אותו המחלקה
        public override bool Equals(object obj)
        {
            if (obj is Sensor other)
            {
                return this.Name == other.Name;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        


    }
    class AudioSensor : Sensor
    {
        public override string Name => "Audio_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
    class ThermalSensor : Sensor
    {
        
        public override string Name => "Thermal_Sensor";
        public override void Activate()
        {
            
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
            

        }
        public Sensor RevealsOneSecreatSensor(Agent agent)
        {
            Random rand = new Random();
            var hidden = agent.sensorSensitive
                         .Where(s => !agent.sensorsAttached.Contains(s))
                         .ToList();
            if(hidden.Count == 0 ) { return null;}
            return hidden[rand.Next(hidden.Count)];
        }
    }
    class PulseSensor : Sensor
    {
        public override string Name => "Pulse_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
            if (ActivationCount > 3)
            {
                IsBroken = true;
            }

        }

    }
    class MotionSensor : Sensor
    {
        public override string Name => "Motion_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
            if (ActivationCount > 3) 
            {
                IsBroken = true;
            }

        }
    }
    class Magnetic : Sensor
    {
        public override string Name => "Magnetic";
        private int remainingBlocks = 2;

        public bool CanBlockCounterAttack()
        {
            return remainingBlocks > 0;
        }

        public void UseBlock()
        {
            if (remainingBlocks > 0)
                remainingBlocks--;
        }

        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");

        }
    }
    
    class SignalSensor : Sensor,ISensorThatPrint
    {
        Random random = new Random();
        public override string Name => "Signal_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
        }
        public void Print()
        {
            Console.WriteLine($"this agent rank: {random.Next(10)}");
        }
    }
    class LightSensor : Sensor,ISensorThatPrint
    {
        Random random = new Random();
        List<string> terrorOrganizations = new List<string>
        {
            "Al-Qaeda",
            "ISIS",
            "Hezbollah",
            "Hamas",
            "Boko Haram",
            "Taliban",
            "Palestinian Islamic Jihad"
        };
        public override string Name => "Light_Sensor";
        public override void Activate()
        {
            ActivationCount++;
            Console.WriteLine($"{Name} sensor activeted {ActivationCount} times");
        }
        public void Print() 
        {
            Console.WriteLine($"this agent is mamber in {terrorOrganizations[random.Next(terrorOrganizations.Count)]}");
        }
    }
}
