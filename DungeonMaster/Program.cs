using System;

namespace DungeonMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Your name: ");
            string name = Console.ReadLine();

            Player player = new Player(name, 100, 1, 0);
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
