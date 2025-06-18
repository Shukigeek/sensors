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
        public abstract string Name { get; }

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
}
