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

            Player player = new Player();

            Console.WriteLine("Create new player: ");
            Console.Write("yes/no: ");
            string createOrNot = Console.ReadLine();
            bool isCreate = false;

            if (createOrNot == "yes")
            {
                isCreate = true;
            }
            else if (createOrNot == "no")
            {
                isCreate = false;
            }


            if (isCreate)
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

                player.addNewPlayer(connection, player);
                Console.WriteLine("New player created!");
            }

            if (!isCreate)
            {
                Console.Write("Name of exisitng player: ");
                string name = Console.ReadLine();
                var existingPLayer = player.getExisitngPLayer(connection, player, name);
                player = existingPLayer;
            }

            Shop shopClass = new Shop();

            bool gameLoop = true;

            while (gameLoop)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "stats":
                        player.checkData(connection, player.Name);
                        break;
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
                        Console.WriteLine(player.Name);
                        Console.WriteLine(player.Health);
                        break;
                    default:
                        input = Console.ReadLine();
                        break;
                }

            }

        }
    }
}
