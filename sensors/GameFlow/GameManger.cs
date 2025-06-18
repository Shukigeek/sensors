using sensors.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace sensors.GameFlow
{
    internal class GameManger
    {
        InterrogationRoom room = new InterrogationRoom();
        LevelManger levelM = new LevelManger();
        SecorPerRoom secorPerRoom = new SecorPerRoom();
        PlayerDataToTable player = new PlayerDataToTable();
        BestScore bestScore = new BestScore();
        StartGame game = new StartGame();
        bool finishLevel = false;
        public void interrogat()
        {
            string name = game.EnterName();
            int? level = game.GameStart(name);
            if (level != null)
            {
                for (int i = 0; i < level.Value; i++)
                {
                    levelM.LevelGame(true, name);
                }
            }
            while (true)
            {
                Agent agent = levelM.LevelGame(finishLevel, name);
                finishLevel = false;
                if (agent == null)
                {
                    break;
                }
                int score = room.InterrogateAgent(agent);
                TebaleModel model = secorPerRoom.SecorRoom(name, agent, score);

                if (AskToExit.Exit())
                {
                    player.InsertRow(model);
                    Console.WriteLine("Exiting the game...");

                    bestScore.GetCurrentScore(name);
                    bestScore.GetBestScore(name);
                    break;
                }
            }
        }
    }
}
