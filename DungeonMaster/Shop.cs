using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster
{
    class Shop
    {
        public Dictionary<int, Dictionary<int, int>> counter()
        {
            Dictionary<int ,Dictionary<int, int>> prices = new Dictionary<int, Dictionary<int, int>> 
            {
                {
                    0,
                    new Dictionary<int, int>
                    {
                        {5,1}
                    }
                },

                {
                    1,
                    new Dictionary<int, int>
                    {
                        {20 ,5}
                    }
                },

                {
                    2, new Dictionary<int, int>
                    {
                        {50 , 10}
                    }
                },

                {
                    3,
                    new Dictionary<int, int>
                    {
                        {500 , 10}
                    }
                }
            };

            return prices;
        }

        public void displayShop(Dictionary<int ,Dictionary<int,int>> shop) 
        {
            
            foreach (var item in shop)
            {
                var option = item.Key;
                var prices = item.Value;

                Console.WriteLine($"Option - {option}");

                foreach (var price in prices)
                {
                    Console.WriteLine($"Price - {price.Key} , + {price.Value} Damage");
                    Console.WriteLine("---------------------------------------------");
                }
                
            }

        }

        public void upgradeDamage(Player player)
        {
            
        }

    }
}
