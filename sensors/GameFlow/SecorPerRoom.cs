using sensors.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.GameFlow
{
    internal class SecorPerRoom
    {
        TebaleModel model = new TebaleModel();
        public TebaleModel SecorRoom(string name,Agent agent ,int score) 
        {
            model.Name = name;
            if (agent is FootSoldierAgent) model.room1 = score;
            if (agent is SquadLeaderAgent) model.room2 = score;
            if (agent is SeniorCommanderAgent) model.room3 = score;
            if (agent is OrganizationLeaderAgent) model.room4 = score;
            return model;
        }
    }
}
