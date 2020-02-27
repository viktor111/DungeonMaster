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
            string currentName = player.Name;
            int currentGold = player.Gold;
            int currentHealth = player.Health;
            int currentDamage = player.Damage;

            connection.Open();
            String querry = $"UPDATE dbo.Player SET Health={currentHealth}, Damage={currentDamage}, Gold={currentGold} WHERE Name={currentName}";
            SqlCommand command = new SqlCommand(querry, connection);    
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void addNewPlayer(SqlConnection connection, Player player)
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

        public void checkData(SqlConnection connection, string name)
        {
            try
            {
                connection.Open();
                string querry = $"SELECT * FROM dbo.Player WHERE Name='{name}'";
                SqlCommand command = new SqlCommand(querry, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write($"Name -{reader.GetString(0)}");
                    Console.WriteLine($" Health -{reader.GetInt32(1)} Damage -{reader.GetInt32(2)} Gold -{reader.GetInt32(3)}");
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Error occured while getting your data.");
            }
        }

        public Player getExisitngPLayer(SqlConnection connection, Player player, string name)
        {

            try
            {
                connection.Open();
                string querry = $"SELECT * FROM dbo.Player WHERE Name='{name}'";
                SqlCommand command = new SqlCommand(querry, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write($"Name -{reader.GetString(0)}");
                    Console.WriteLine($" Health -{reader.GetInt32(1)} Damage -{reader.GetInt32(2)} Gold -{reader.GetInt32(3)}");

                    player.Name = reader.GetString(0);
                    player.Health = reader.GetInt32(1);
                    player.Damage = reader.GetInt32(2);
                    player.Gold = reader.GetInt32(3);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Error occured while getting your data.");
            }
           
            return player;
        }
       
    }
}
