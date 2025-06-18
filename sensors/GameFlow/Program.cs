using sensors.DataBase;
using sensors.GameFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sensors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManger room = new GameManger();
            room.interrogat();
            //CreatTable creatTable = new CreatTable();
            //creatTable.CreatNewTable();

        }
    }

}

