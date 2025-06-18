using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.DataBase
{
    internal class CreatTable
    {
        DalConnction dal = new DalConnction();
        public void CreatNewTable()
        {
            
            string query = "CREATE TABLE IF NOT EXISTS GameScore(" +
            "ID INT AUTO_INCREMENT PRIMARY KEY," +
            "Name VARCHAR(30)," +
            "Room1 INT," +
            "Room2 INT," +
            "Room3 INT," +
            "Room4 INT," +
            "Total_Score INT GENERATED ALWAYS AS (" +
                "IFNULL(Room1, 0) + IFNULL(Room2, 0) + IFNULL(Room3, 0) + IFNULL(Room4, 0)" +
            ") STORED" +
            ")";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, dal.openConnction()))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error creating table {ex.ToString()}");
            }
        }
        

    }
}
