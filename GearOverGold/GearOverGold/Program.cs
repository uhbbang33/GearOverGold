using System.Data;
using System.Numerics;

namespace GearOverGold
{
    class Program
    {
        const int windowWidth = 115;
        const int windowHeight = 40;

        static List<Gear> gearsInStore;
        static Character player;
        static void Main(string[] args)
        {
            InitializeWindow();
            GameIntro();

            gearsInStore = new List<Gear>
            {
                new Gear("무쇠갑옷", 100, 0, 0, 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Gear("낡은 검", 100, 0, 2, 0, 0, "쉽게 볼 수 있는 낡은 검 입니다.")
            };

            player = PlayerIntialize();

            ChooseMenu();
        }
        
        static void InitializeWindow()
        {
            Console.Title = "GearOverGold";
            Console.SetWindowSize(windowWidth, windowHeight);
            //Console.BackgroundColor = ConsoleColor.DarkCyan;  // 배경 색깔
            //Console.ForegroundColor = ConsoleColor.Green;     // 글씨 색깔
            
            Console.CursorVisible = false;

            Console.Clear();
        }

        static void GameIntro()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("\r\n " +
                "_______  _______  _______  ______      _______  __   __  _______  ______      _______  _______  ___      ______  \r\n" +
                "|       ||       ||   _   ||    _ |    |       ||  | |  ||       ||    _ |    |       ||       ||   |    |      | \r\n" +
                "|    ___||    ___||  |_|  ||   | ||    |   _   ||  |_|  ||    ___||   | ||    |    ___||   _   ||   |    |  _    |\r\n" +
                "|   | __ |   |___ |       ||   |_||_   |  | |  ||       ||   |___ |   |_||_   |   | __ |  | |  ||   |    | | |   |\r\n" +
                "|   ||  ||    ___||       ||    __  |  |  |_|  ||       ||    ___||    __  |  |   ||  ||  |_|  ||   |___ | |_|   |\r\n" +
                "|   |_| ||   |___ |   _   ||   |  | |  |       | |     | |   |___ |   |  | |  |   |_| ||       ||       ||       |\r\n" +
                "|_______||_______||__| |__||___|  |_|  |_______|  |___|  |_______||___|  |_|  |_______||_______||_______||______| \r\n");
            Console.WriteLine("\n\t\t\t\t\t      Press Any Key To Start");
            Console.ReadLine();
        }

        static Character PlayerIntialize()
        {
            Console.Clear();

            DrawSquare(windowWidth / 4, windowWidth / 4 * 3, windowHeight / 4, windowHeight / 4 * 3);
            Console.SetCursorPosition(windowWidth / 3, windowHeight / 2);
            Console.Write("닉네임: ");
            string name = Console.ReadLine();

            DrawOccupationSelectBox();
            int occupation = OccupationSelect();

            return new Character(name, occupation - 1);
        }

        static void DrawSquare(int minX, int maxX, int minY, int maxY)
        {
            for (int i = minX; i < maxX; ++i)
            {
                Console.SetCursorPosition(i, minY);
                Console.Write("■");
                Console.SetCursorPosition(i, maxY);
                Console.Write("■");
            }
            for (int i = minY; i < maxY; ++i)
            {
                Console.SetCursorPosition(minX, i);
                Console.Write("■");
                Console.SetCursorPosition(maxX, i);
                Console.Write("■");
            }
        }

        static void DrawArt(string artString, int startXPos, int startYPos)
        {
            Console.SetCursorPosition(startXPos, startYPos);
            int cnt = 0;
            foreach (char c in artString)
            {
                if (c == '\n')
                {
                    Console.SetCursorPosition(startXPos, startYPos + cnt);
                    ++cnt;
                }
                else Console.Write(c);
            }
        }

        static void DrawOccupationSelectBox()
        {
            Console.Clear();

            string warriorWeapon = "          /\\\r\n         /  \\\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        | /\\ |\r\n:\\______|/  \\|______/:\r\n \\__________________/\r\n        | /\\ |\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        | \\/ |\r\n        \\____/\r\n        (____)";
            DrawArt(warriorWeapon, 7, 3);

            string tankerWeapon = "   |\\                     /)\n /\\_\\\\__               (_//\n|   `>\\-`     _._       //`)\n \\ /` \\\\  _.-`:::`-._  //\n  `    \\|`    :::    `|/\n        |     :::     |\n        |.....:::.....|\n        |:::::::::::::|\n        |     :::     |\n        \\     :::     /\n         \\    :::    /\n          `-. ::: .-'\n           //`:::`\\\\\n          //   '   \\\\\n         |/         \\\\";
            DrawArt(tankerWeapon, windowWidth / 3 + 4, 8);

            string magitionWeapon = "            ______              \r\n       .d$$$******$$$$c.        \r\n    .d$P\"            \"$$c      \r\n   $$$$$.           .$$$*$.    \r\n .$$ 4$L*$$.     .$$Pd$  '$b   \r\n $F   *$. \"$$e.e$$\" 4$F   ^$b  \r\nd$     $$   z$$$e   $$     '$. \r\n$P     `$L$$P` `\"$$d$\"      $$ \r\n$$     e$$F       4$$b.     $$ \r\n$b  .$$\" $$      .$$ \"4$b.  $$ \r\n$$e$P\"    $b     d$`    \"$$c$F \r\n'$P$$$$$$$$$$$$$$$$$$$$$$$$$$  \r\n \"$c.      4$.  $$       .$$   \r\n  ^$$.      $$ d$\"      d$P    \r\n    \"$$c.   `$b$F    .d$P\"     \r\n      `4$$$c.$$$..e$$P\"        \r\n          `^^^^^^^`";
            DrawArt(magitionWeapon, windowWidth / 3 * 2 + 4, 8);

            DrawSquare(0, windowWidth / 3 - 2, 0, windowHeight / 4 * 3);
            DrawSquare(windowWidth / 3, windowWidth / 3 * 2 - 2, 0, windowHeight / 4 * 3);
            DrawSquare(windowWidth / 3 * 2, windowWidth - 3, 0, windowHeight / 4 * 3);

            Console.Write("\n\n\n");
            Console.SetCursorPosition(4, windowHeight / 4 * 3 + 3);
            Console.WriteLine("전사 : 공격력 방어력 HP 밸런스");
            Console.SetCursorPosition(windowWidth / 3, windowHeight / 4 * 3 + 3);
            Console.WriteLine("탱커 : 공격력 낮음, 방어력 HP 높음");
            Console.SetCursorPosition(windowWidth / 3 * 2, windowHeight / 4 * 3 + 3);
            Console.WriteLine("마법사 : 공격력 높음, 방어력 HP 낮음");
        }

        static int OccupationSelect()
        {
            ConsoleKeyInfo keyInfo;

            int occupationNum = 0;
            int xPos = 4;
            do
            {
                // 그리기
                Console.SetCursorPosition(xPos - 2, windowHeight / 4 * 3 + 3);
                Console.Write("▶");

                keyInfo = Console.ReadKey();

                // 지우기
                Console.SetCursorPosition(xPos - 2, windowHeight / 4 * 3 + 3);
                Console.Write("  ");

                if (keyInfo.Key == ConsoleKey.RightArrow)
                    ++occupationNum;
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    --occupationNum;

                if      (occupationNum % 3 == 0) xPos = 4;
                else if (occupationNum % 3 == 1) xPos = windowWidth / 3;
                else xPos = windowWidth / 3 * 2;
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            return occupationNum % 3 + 1;
        }

        static void DrawMenuSelectBox()
        {
            Console.Clear();
            DrawSquare(0, windowWidth / 2 - 3, 0, windowHeight / 2 - 2); //1
            DrawSquare(windowWidth / 2, windowWidth - 4, 0, windowHeight / 2 - 2); //2
            DrawSquare(0, windowWidth / 2 - 3, windowHeight / 2, windowHeight - 2); // 3
            DrawSquare(windowWidth / 2, windowWidth - 4, windowHeight / 2, windowHeight - 2); //4

            Console.SetCursorPosition(23, 9);
            Console.Write("상태보기");
            Console.SetCursorPosition(81, 9);
            Console.Write("인벤토리");
            Console.SetCursorPosition(23, 29);
            Console.Write("상점가기");
            Console.SetCursorPosition(81, 29);
            Console.Write("던전가기");
        }

        static int MenuSelect()
        {
            ConsoleKeyInfo keyInfo;

            int occupationNum = 0;
            int xPos = 21;
            int yPos = 9;
            do
            {
                // 그리기
                Console.SetCursorPosition(xPos - 2, yPos);
                Console.Write("▶");

                keyInfo = Console.ReadKey();

                // 지우기
                Console.SetCursorPosition(xPos - 2, yPos);
                Console.Write("  ");

                if (keyInfo.Key == ConsoleKey.RightArrow)
                    ++occupationNum;
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    --occupationNum;

                if (occupationNum % 4 == 0) { xPos = 21; yPos = 9; }
                else if (occupationNum % 4 == 1) { xPos = 79; yPos = 9; }
                else if (occupationNum % 4 == 2) { xPos = 21; yPos = 29; }
                else { xPos = 79; yPos = 29; }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            return occupationNum % 4;
        }

        static void ChooseMenu()
        {
            DrawMenuSelectBox();

            int menuNum = MenuSelect();
            switch (menuNum)
            {
                case 0:
                    CheckStatus();
                    break;
                case 1:
                    Inventory();
                    break;
                case 2:
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
            DrawSquare(0, windowWidth / 3 - 2, 0, windowHeight / 4 * 3);

            string occupationArt;
            int xPos, yPos;
            if (player.Occupation == "전사")
            {
                occupationArt = "          /\\\r\n         /  \\\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        |    |\r\n        | /\\ |\r\n:\\______|/  \\|______/:\r\n \\__________________/\r\n        | /\\ |\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        ||  ||\r\n        | \\/ |\r\n        \\____/\r\n        (____)";
                xPos = 7;
                yPos = 3;
            }
            else if (player.Occupation == "탱커")
            {
                occupationArt = "   |\\                     /)\n /\\_\\\\__               (_//\n|   `>\\-`     _._       //`)\n \\ /` \\\\  _.-`:::`-._  //\n  `    \\|`    :::    `|/\n        |     :::     |\n        |.....:::.....|\n        |:::::::::::::|\n        |     :::     |\n        \\     :::     /\n         \\    :::    /\n          `-. ::: .-'\n           //`:::`\\\\\n          //   '   \\\\\n         |/         \\\\";
                xPos = 4;
                yPos = 8;
            }
            else
            {
                occupationArt = "            ______              \r\n       .d$$$******$$$$c.        \r\n    .d$P\"            \"$$c      \r\n   $$$$$.           .$$$*$.    \r\n .$$ 4$L*$$.     .$$Pd$  '$b   \r\n $F   *$. \"$$e.e$$\" 4$F   ^$b  \r\nd$     $$   z$$$e   $$     '$. \r\n$P     `$L$$P` `\"$$d$\"      $$ \r\n$$     e$$F       4$$b.     $$ \r\n$b  .$$\" $$      .$$ \"4$b.  $$ \r\n$$e$P\"    $b     d$`    \"$$c$F \r\n'$P$$$$$$$$$$$$$$$$$$$$$$$$$$  \r\n \"$c.      4$.  $$       .$$   \r\n  ^$$.      $$ d$\"      d$P    \r\n    \"$$c.   `$b$F    .d$P\"     \r\n      `4$$$c.$$$..e$$P\"        \r\n          `^^^^^^^`";
                xPos = 4;
                yPos = 8;
            }
            DrawArt(occupationArt, xPos, yPos);

            Console.SetCursorPosition(windowWidth / 3 + 1, 4);
            Console.WriteLine("닉네임:\t" + player.Name);
            Console.SetCursorPosition(windowWidth / 3 + 1, 6);
            Console.WriteLine("직업:\t" + player.Occupation);
            Console.SetCursorPosition(windowWidth / 3 + 1, 8);
            Console.WriteLine("레벨:\t" + player.Level);
            Console.SetCursorPosition(windowWidth / 3 + 1, 10);
            Console.WriteLine("공격력:\t" + player.AttackPower);
            Console.SetCursorPosition(windowWidth / 3 + 1, 12);
            Console.WriteLine("방어력:\t" + player.DefensePower);
            Console.SetCursorPosition(windowWidth / 3 + 1, 14);
            Console.WriteLine("체력:\t" + player.HP);
            Console.SetCursorPosition(windowWidth / 3 + 1, 16);
            Console.WriteLine("Gold:\t" + player.Gold);

            Console.ReadLine();
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