using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.GameFlow
{
    internal class CalcoletScore
    {
        public int Score(Agent agent,int turn)
        {
            int score = 100;
            if(agent == null) return 0;
            if(agent is FootSoldierAgent)
            {
                score -= ((turn - 2) * 10);    
            }
            else if(agent is SquadLeaderAgent)
            {
                score -= ((turn - 4) * 10);
            }
            else if (agent is SeniorCommanderAgent) 
            {
                score -= ((turn - 6) * 10);
            }
            else if(agent is OrganizationLeaderAgent)
            {
                score -= ((turn - 8) * 10);
            }
            return score;
        }
    }
}
