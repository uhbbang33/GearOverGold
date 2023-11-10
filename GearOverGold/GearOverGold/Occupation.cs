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
    
    // class나 struct로 구현하는 것이 좋을까?
    struct Warrior : OccupationInitializer
    {
        public int DefaultAttackPower
        {
            get { return 100; }
        }
        public int DefaultDefensePower
        {
            get { return 100; }
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
            get { return 50; }
        }
        public int DefaultDefensePower
        {
            get { return 125; }
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
            get { return 150; }
        }
        public int DefaultDefensePower
        {
            get { return 75; }
        }
        public int DefaultHP
        {
            get { return 75; }
        }
    }

    public enum OccupationType
    {
        WARRIOR,    // 공방 밸런스
        TANKER,     // HP, 방 특화
        SORCERER,   // 공 특화  방, HP 떨어짐
    }
}
