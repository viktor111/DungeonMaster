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

            Console.WriteLine("Use existing player: ");
            string useExistingPlayer = Console.ReadLine();

            bool isUsingPlayer = false;

            if (useExistingPlayer == "yes")
            {
                isUsingPlayer = true;
            }


            Player player = new Player();

            if (!isUsingPlayer)
            {

                Console.Write("Your name: ");

                string name = Console.ReadLine();

                player = new Player
                {
                    Name = name,
                    Health = 100,
                    Damage = 1,
                    Gold = 100
                };

                player.save(connection, player);
                Console.WriteLine("New player created!");
            }
            else
            {
                Console.Write("Player name: ");
                string name = Console.ReadLine();

                // ToDo use player that exists from databse.
            }

            Shop shopClass = new Shop();

            bool gameLoop = true;

            while (gameLoop)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "save":
                        try
                        {
                            player.save(connection, player);
                            Console.WriteLine("Player saved!");
                        }
                        catch
                        {
                            Console.WriteLine("User not saved due to error!");
                        }
                        break;
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
