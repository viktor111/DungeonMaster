using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace DungeonMaster
{
    class Player
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public int Gold { get; set; }
        
        public void save(SqlConnection connection, Player player)
        {
            connection.Open();
            String querry = "INSERT INTO dbo.Player(Name, Health, Damage, Gold) VALUES(@Name, @Health, @Damage, @Gold)";
            SqlCommand command = new SqlCommand(querry, connection);
            command.Parameters.AddWithValue("@Name", player.Name);
            command.Parameters.AddWithValue("@Health", player.Health);
            command.Parameters.AddWithValue("@Damage", player.Damage);
            command.Parameters.AddWithValue("@Gold", player.Gold);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void checkIfPlayerExist()
        {
            //ToDo Check if player exists 
        }
    }
}
