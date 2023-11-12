using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearOverGold
{
    internal class Gear
    {
        public string Name { get; set; }
        public int Price { get; }
        public int RequiredLevel { get; }
        public int IncreaseAttackPower { get; }
        public int IncreaseDefensePower { get; }
        public int IncreaseMaxHp { get; }
        public string Description { get; }
        public string Info { get; }

        public bool IsEquip { get; set; } = false;

        public Gear(string name, int price, int requiredLevel, int increaseAttackPower, int increaseDefensePower, int increaseMaxHp, string description)
        {
            Name = name;
            Price = price;
            RequiredLevel = requiredLevel;
            IncreaseAttackPower = increaseAttackPower;
            IncreaseDefensePower = increaseDefensePower;
            IncreaseMaxHp = increaseMaxHp;
            Description = description;

            Info = IncreaseAbility();
        }

        string IncreaseAbility()
        {
            string gearAbility = "";//"- " + Name + "  " + Price;
            if (IncreaseAttackPower != 0)   gearAbility += (" 공격력 +" + IncreaseAttackPower);
            if (IncreaseDefensePower != 0)  gearAbility += (" 방어력 +" + IncreaseDefensePower);
            if (IncreaseMaxHp != 0)         gearAbility += (" 최대 HP +" + IncreaseMaxHp);
            //gearAbility += Description;

            return gearAbility;
        }
    }
}
