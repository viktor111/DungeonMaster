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
            }
            catch
            {
                throw new Exception("Failed to connect to database!");
            }

            using (connection)
            {
                Console.Write("Your name: ");

                string name = Console.ReadLine();

                Player player = new Player
                {
                    Name = name,
                    Health = 100,
                    Damage = 1,
                    Gold = 100
                };
                Shop shopClass = new Shop();

                bool gameLoop = true;

                while (gameLoop)
                {
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "shop":
                            shopClass.displayShop(shopClass.counter());
                            break;
                        default:
                            command = Console.ReadLine();
                            break;
                    }

                }
            }
        }
    }
}
