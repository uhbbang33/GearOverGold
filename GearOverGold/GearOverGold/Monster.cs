using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearOverGold
{
    internal class Monster : ICharacter
    {
        public string Name { get; protected set; }
        public int HP { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead { get; private set; }
        public int GoldReward { get; set; }
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
                IsDead = true;
            }
        }
    }

    class Goblin : Monster
    {
        public Goblin(int playerLevel)
        {
            Name = "Goblin";
            AttackPower = playerLevel * 10;
            HP = playerLevel * 50;
            GoldReward = playerLevel * 50;
        }
    }

    class Dragon : Monster
    {
        public Dragon(int playerLevel)
        {
            Name = "Dragon";
            AttackPower = playerLevel * 20;
            HP = playerLevel * 60;
            GoldReward = playerLevel * 75;
        }
    }
}
