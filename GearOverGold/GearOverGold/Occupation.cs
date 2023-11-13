using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearOverGold
{
    interface OccupationInitializer
    {
        int DefaultAttackPower { get; }
        int DefaultDefensePower { get; }
        int DefaultHP { get; }
    }
    
    struct Warrior : OccupationInitializer
    {
        public int DefaultAttackPower
        {
            get { return 20; }
        }
        public int DefaultDefensePower
        {
            get { return 20; }
        }
        public int DefaultHP
        {
            get { return 100; }
        }
    }

    struct Tanker : OccupationInitializer
    {
        public int DefaultAttackPower
        {
            get { return 15; }
        }
        public int DefaultDefensePower
        {
            get { return 25; }
        }
        public int DefaultHP
        {
            get { return 125; }
        }
    }

    struct Sorcerer : OccupationInitializer
    {
        public int DefaultAttackPower
        {
            get { return 35; }
        }
        public int DefaultDefensePower
        {
            get { return 15; }
        }
        public int DefaultHP
        {
            get { return 80; }
        }
    }

    public enum OccupationType
    {
        WARRIOR,    // 공방 밸런스
        TANKER,     // HP, 방 특화
        SORCERER,   // 공 특화  방, HP 떨어짐
    }
}
