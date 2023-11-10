using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearOverGold
{
    internal class Character
    {
        public int Level { get; }
        public string Name { get; }
        public string Occupation { get; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Gold { get; set; }
        public List<Gear> Gears { get; set; }

        public Character(string name, int occupation)
        {
            Name = name;
            Level = 1;
            Gold = 100;
            Gears = new List<Gear>();

            switch (occupation)
            {
                case (int)OccupationType.WARRIOR:
                    Warrior warrior = new Warrior();
                    Occupation = "전사";
                    AttackPower = warrior.DefaultAttackPower;
                    DefensePower = warrior.DefaultDefensePower;
                    MaxHP = warrior.DefaultHP;
                    break;
                case (int)OccupationType.TANKER:
                    Tanker tanker = new Tanker();
                    Occupation = "탱커";
                    AttackPower = tanker.DefaultAttackPower;
                    DefensePower = tanker.DefaultDefensePower;
                    MaxHP = tanker.DefaultHP;
                    break;
                case (int)OccupationType.SORCERER:
                    Sorcerer sorcerer = new Sorcerer();
                    Occupation = "마법사";
                    AttackPower = sorcerer.DefaultAttackPower;
                    DefensePower = sorcerer.DefaultDefensePower;
                    MaxHP = sorcerer.DefaultHP;
                    break;
                default:
                    break;
                    //default: throw new ArgumentException();
            }
            HP = MaxHP;
        }

        public void GetGear(Gear gear)
        {
            if (Gold >= gear.Price)
            {
                if (Level >= gear.RequiredLevel)
                {
                    Gold -= gear.Price;
                    Gears.Add(gear);
                }
                else
                    Console.WriteLine("Level이 부족합니다.");
            }
            else
                Console.WriteLine("Gold가 부족합니다.");
            
        }

        public void AddAbilityFromGear(Gear gear)
        {
            AttackPower += gear.IncreaseAttackPower;
            DefensePower += gear.IncreaseDefensePower;
            MaxHP += gear.IncreaseMaxHp;
        }

        public void ReduceAbilityFromGear(Gear gear)
        {
            AttackPower -= gear.IncreaseAttackPower;
            DefensePower -= gear.IncreaseDefensePower;
            MaxHP -= gear.IncreaseMaxHp;
        }
    }
}
