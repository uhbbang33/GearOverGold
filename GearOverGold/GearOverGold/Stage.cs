using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GearOverGold
{
    internal class Stage
    {
        //int level;
        private int monsterNum;
        public List<Monster> MonstersInStage { get; private set; }

        public Stage(int playerLevel)
        {
            monsterNum = playerLevel * 2;
            MonstersInStage = new List<Monster>();

            for (int i = 0; i < monsterNum; ++i)
            {
                Random random = new Random();
                if (random.Next(0, 2) == 0)
                {
                    Goblin goblin = new Goblin(playerLevel);
                    MonstersInStage.Add(goblin);
                }
                else
                {
                    Dragon dragon = new Dragon(playerLevel);
                    MonstersInStage.Add(dragon);
                }
            }
        }
    }
}
