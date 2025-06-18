using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sensors.AgentModels;

namespace sensors.DataBase
{
    internal class PlayerDataToTable
    {
        DalConnction dal = new DalConnction();
        public void InsertRow(TebaleModel model)
        {
            string query = "INSERT INTO gamescore(Name,Room1,Room2," +
                "Room3,Room4) VALUES(@name,@room1,@room2,@room3,@room4)";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, dal.openConnction()))
                {
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@room1", model.room1);
                    cmd.Parameters.AddWithValue("@room2", model.room2);
                    cmd.Parameters.AddWithValue("@room3", model.room3);
                    cmd.Parameters.AddWithValue("@room4", model.room4);
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding score game {ex.ToString()}");
            }
        }
        public int? RecognizePlayer(string name)
        {
            string query = "SELECT Room1,Room2,Room3,Room4 FROM GameScore g WHERE g.Name = @name ORDER BY ID DESC LIMIT 1;";
            MySqlDataReader reader = null;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, dal.openConnction()))
                {
                    cmd.Parameters.AddWithValue("name", name);

                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            for (int i = 0; i < 4; i++)
                            {
                                int roomScore = reader.GetInt32(i);
                                if (roomScore == 0)
                                {
                                    
                                    return i;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding out if player play or where is he: {ex.Message}");
            }
            //אם כל החדרים מלאים או שהשחקן לא קיים צריך להתחיל מההתחלה
            return null;
           
        }
    }
}
