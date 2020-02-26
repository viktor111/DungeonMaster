using System;
using System.Data.SqlClient;

namespace DungeonMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(@"Server=WINDEV2001EVAL\SQLEXPRESS;Database=DungeonMaster;Integrated Security=True");

            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                throw new Exception("Failed to connect to database!");
            }


            Console.Write("Your name: ");

            string name = Console.ReadLine();

            Player player = new Player
            {
                Name = name,
                Health = 100,
                Damage = 1,
                Gold = 100
            };

            connection.Open();
            String querry = "INSERT INTO dbo.Player(Name, Health, Damage, Gold) VALUES(@Name, @Health, @Damage, @Gold)";
            SqlCommand command = new SqlCommand(querry, connection);
            command.Parameters.AddWithValue("@Name", player.Name);
            command.Parameters.AddWithValue("@Health", player.Health);
            command.Parameters.AddWithValue("@Damage", player.Damage);
            command.Parameters.AddWithValue("@Gold", player.Gold);
            command.ExecuteNonQuery();
            connection.Close();

            Shop shopClass = new Shop();

            bool gameLoop = true;

            while (gameLoop)
            {
                string input = Console.ReadLine();

                switch (input)
                {

                    case "shop":
                        shopClass.displayShop(shopClass.counter());
                        break;
                    default:
                        input = Console.ReadLine();
                        break;
                }

            }

        }
    }
}
