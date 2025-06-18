using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sensors.DataBase;

namespace sensors.GameFlow
{
    internal class StartGame
    {
        PlayerDataToTable player = new PlayerDataToTable();
        public string EnterName()
        {
            Console.WriteLine("Welcome to the Secret Interrogation Game!\n" +
                "Please enter your name to begin your mission:");
            string name = Console.ReadLine();
            return name;
        }

        public int? GameStart(string name)
        {
            
            var roomNumber = player.RecognizePlayer(name);
            if (roomNumber != null)
            {
                Console.WriteLine($"welcome back {name}!\n" +
                    $"choose from 1-2\n" +
                    $"1: continue from room number: {roomNumber}\n" +
                    $"2: start new game");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        return roomNumber;
                    case "2":
                        return null;
                    default:
                        return null;
                }
                
            }
            Console.WriteLine($"Hello, {name}! Starting a new game...\n");
            return null;
        }
    }
}
