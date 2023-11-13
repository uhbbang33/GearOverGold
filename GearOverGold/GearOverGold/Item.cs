using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearOverGold
{
    interface Item
    {
        string Name { get; }
        void Use(Player player);
    }

    class HealthPotion : Item
    {
        public string Name { get; set; }
        public void Use(Player player)
        {
            player.HP += 50;
        }
    }

    class StrengthPotion
    {
        public string Name { get; set; }
        public void Use(Player player)
        {
            player.AttackPower += 10;
        }
    }
}
