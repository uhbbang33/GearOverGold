using System.Data;
using System.Numerics;

namespace GearOverGold
{
    class Program
    {
        static List<Gear> gearsInStore;
        static Character player;
        static void Main(string[] args)
        {
            GameIntro();

            gearsInStore = new List<Gear>
            {
                new Gear("무쇠갑옷", 100, 0, 0, 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Gear("낡은 검", 100, 0, 2, 0, 0, "쉽게 볼 수 있는 낡은 검 입니다.")
            };

            player = PlayerIntialize();
            ChooseMenu();
        }

        static void GameIntro()
        {
            Console.WriteLine("\t 돈보다 장비");
            Console.WriteLine("시작하려면 아무 키나 누르세요");
            Console.ReadLine();
        }

        static Character PlayerIntialize()
        {
            Console.Clear();
            Console.Write("닉네임: ");
            string name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("직업을 고르세요 \n");
            Console.WriteLine("1.전사 : 공격력 방어력 HP 밸런스");
            Console.WriteLine("2.탱커 : 공격력 낮음, 방어력 HP 높음");
            Console.WriteLine("3.마법사 : 공격력 높음, 방어력 HP 낮음");
            int occupation = int.Parse(Console.ReadLine());

            return new Character(name, occupation - 1);
        }

        static void ChooseMenu()
        {
            Console.Clear();

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점가기");

            int menuNum = int.Parse(Console.ReadLine());
            switch (menuNum)
            {
                case 1:
                    CheckStatus();
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    Store();
                    break;
                default:
                    ChooseMenu();
                    break;
            }
        }

        static void CheckStatus()
        {
            Console.Clear();
            Console.WriteLine("닉네임:\t" + player.Name);
            Console.WriteLine("직업:\t" + player.Occupation);
            Console.WriteLine("레벨:\t" + player.Level);
            Console.WriteLine("공격력:\t" + player.AttackPower);
            Console.WriteLine("방어력:\t" + player.DefensePower);
            Console.WriteLine("체력:\t" + player.HP);
            Console.WriteLine("Gold:\t" + player.Gold);
            Console.WriteLine("\n0. 나가기");
            Console.Write(">> ");
            if ('0' == Console.ReadLine()[0])
                ChooseMenu();
        }

        static void Inventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < player.Gears.Count; ++i)
                Console.WriteLine(player.Gears[i].Name + "\t"
                    + player.Gears[i].Info + "\n");

            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("1. 장비 장착 및 해제");
            Console.Write(">> ");
            int num = Console.ReadLine()[0];

            if (num == '0') ChooseMenu();
            else if (num == '1') {
                GearEquip();
            }
        }

        static void GearEquip()
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < player.Gears.Count; ++i)
                Console.WriteLine(player.Gears[i].Name + "\t"
                    + player.Gears[i].Info + "\n");

            Console.WriteLine("취소: 0");
            Console.WriteLine("장착하거나 해제할 장비의 번호를 입력해주세요: ");
            
            int equipNum = int.Parse(Console.ReadLine())-1;
            
            if (equipNum == 0)
                Inventory();
            else
            {
                Gear selectedGear = player.Gears[equipNum];

                if (selectedGear.IsEquip)
                {
                    player.ReduceAbilityFromGear(selectedGear);
                    
                    //안 뜸
                    Console.WriteLine(selectedGear.Name + "의 장착해제가 완료되었습니다!");
                }
                else
                {
                    player.AddAbilityFromGear(selectedGear);
                    Console.WriteLine(selectedGear.Name + "의 장착이 완료되었습니다!");
                }
            }
        }

        static void Store()
        {
            Console.Clear();

            for (int i = 0; i < gearsInStore.Count; ++i)
                Console.WriteLine((i + 1) + gearsInStore[i].Info);

            Console.Write("\n구매할 장비의 번호를 입력해주세요: ");
            int buyNum = int.Parse(Console.ReadLine()) - 1;

            player.GetGear(gearsInStore[buyNum]);
            gearsInStore.RemoveAt(buyNum);

            Console.WriteLine("\n0. 나가기");
            Console.Write(">> ");
            if ('0' == Console.ReadLine()[0])
                ChooseMenu();
        }
    }
}