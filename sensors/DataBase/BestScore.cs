using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.DataBase
{
    internal class BestScore
    {
        DalConnction dal = new DalConnction();
        public void GetBestScore(string name)
        {
            string query = "SELECT MAX(Total_Score) AS bestScore FROM GameScore g WHERE g.Name = @name";
            MySqlDataReader reader = null;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, dal.openConnction()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var bestScore = reader["bestScore"];
                            if (bestScore != DBNull.Value)
                            {
                                Console.WriteLine($"{name}, your highest score is: {bestScore}");
                            }
                            else
                            {
                                Console.WriteLine($"{name} has no scores recorded yet.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error faching best score: {ex.Message}");
            }
        }
    }
}
