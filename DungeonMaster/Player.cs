using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster
{
    class Player
    {
        public string name;
        public int health;
        public int damage;
        public int gold;

        public Player(string name, int health, int damage, int gold)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.gold = gold;
        }

    }
}
