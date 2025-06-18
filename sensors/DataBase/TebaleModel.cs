using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.DataBase
{
    internal class TebaleModel
    {
        public string Name;
        public int? room1;
        public int? room2;
        public int? room3;
        public int? room4;
        public TebaleModel()
        {
            this.Name = "";
            this.room1 = 0;
            this.room2 = 0;
            this.room3 = 0;
            this.room4 = 0;
        }
    }
}
