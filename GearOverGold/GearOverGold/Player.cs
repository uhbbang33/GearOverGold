using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GearOverGold
{
    interface ICharacter
    {
        string Name { get; }
        int HP { get; }
        int AttackPower { get; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
    internal class Player : ICharacter
    {
        public int Level { get; }
        public string Name { get; }
        public string Occupation { get; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Gold { get; set; }
        public bool IsDead { get; set; }

        public List<Gear> Gears { get; set; }

        public Player(string name, int occupation)
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
                    Gear warriorGear = new Gear("초보자용 검", 0, 0, 1, 1, 0, "처음에 지급되는 검입니다");
                    Gears.Add(warriorGear);
                    break;
                case (int)OccupationType.TANKER:
                    Tanker tanker = new Tanker();
                    Occupation = "탱커";
                    AttackPower = tanker.DefaultAttackPower;
                    DefensePower = tanker.DefaultDefensePower;
                    MaxHP = tanker.DefaultHP;
                    Gear tankerGear = new Gear("초보자용 방패", 0, 0, 0, 2, 0, "처음에 지급되는 방패입니다");
                    Gears.Add(tankerGear);
                    break;
                case (int)OccupationType.SORCERER:
                    Sorcerer sorcerer = new Sorcerer();
                    Occupation = "마법사";
                    AttackPower = sorcerer.DefaultAttackPower;
                    DefensePower = sorcerer.DefaultDefensePower;
                    MaxHP = sorcerer.DefaultHP;
                    Gear sorcererGear = new Gear("초보자용 완드", 0, 0, 2, 0, 0, "처음에 지급되는 완드입니다");
                    Gears.Add(sorcererGear);
                    break;
                default:
                    break;
                    //default: throw new ArgumentException();
            }
            HP = MaxHP;
        }

        public void GetGear(Gear gear)
        {
            Gears.Add(gear);
        }

        public void EquipGear(int gearNum)
        {
            if (!Gears[gearNum].IsEquip)
            {
                Gears[gearNum].IsEquip = true;
                Gears[gearNum].Name = Gears[gearNum].Name.Insert(0, "[E]");
                AddAbilityFromGear(Gears[gearNum]);
            }
            else
            {
                Gears[gearNum].IsEquip = false;
                Gears[gearNum].Name = Gears[gearNum].Name.Remove(0, 3);
                ReduceAbilityFromGear(Gears[gearNum]);
            }
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

        public void TakeDamage(int damage)
        {
            if (damage > 0)
                HP -= damage;
            if (HP < 0)
            {
                HP = 0;
                IsDead = true;
            }
        }
    }
}
