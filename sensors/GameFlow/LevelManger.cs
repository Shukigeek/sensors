using sensors.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;

namespace sensors.GameFlow
{
    internal class LevelManger
    {
        int level = 0;
        BestScore bestScore = new BestScore();
        public static Agent CreatNewFootSoldier() => new FootSoldierAgent(AgentType.Foot_Soldier);
        public static Agent CreatNewSquadLeader() => new SquadLeaderAgent(AgentType.Squad_Leader);
        public static Agent CreatNewSeniorCommander() => new SeniorCommanderAgent(AgentType.Senior_Commander);
        public static Agent CreatNewOrganizationLeader() => new OrganizationLeaderAgent(AgentType.Organization_Leader);

        List<Func<Agent>> Agents = new List<Func<Agent>>()
        {
            CreatNewFootSoldier,
            CreatNewSquadLeader,
            CreatNewSeniorCommander,
            CreatNewOrganizationLeader,
        };
        public Agent LevelGame(bool Success, string name)
        {
            if (Success)
            {
                level++;
                if (level >= Agents.Count)
                {
                    bestScore.GetCurrentScore(name);
                    bestScore.GetBestScore(name);
                    Console.WriteLine("Congratulations! You finished the game.");
                    Console.Clear();
                    FireWorks fireWorks = new FireWorks();

                    return null;
                }
                Console.WriteLine($"You advanced to room number: {level + 1}");
            }
            else
            {
                Console.WriteLine($"you are in room number: {level + 1}");
            }
            return Agents[level]();
        }
    }
}
