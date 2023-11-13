using ConsoleTables;
using System.Data;
using System.Numerics;
using System.Text;

namespace GearOverGold
{
    class Program
    {
        const int windowWidth = 115;
        const int windowHeight = 40;

        static List<Gear> gearsInStore;
        static Player player;
        static void Main(string[] args)
        {
            InitializeWindow();
            GameIntro();

            player = PlayerIntialize();

            gearsInStore = new List<Gear>
            {
                new Gear("무쇠갑옷", 50, 0, 0, 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Gear("낡은 검", 50, 0, 5, 0, 0, "쉽게 볼 수 있는 낡은 검 입니다."),
                new Gear("은행나무 완드", 100, 0, 5, 0, 0, "쉽게 볼 수 있는 은행나무로 만들었습니다."),
                new Gear("쇠 방패", 100, 0, 2, 3, 0, "무겁지만 공격도 가능합니다."),
                new Gear("편한 옷", 100, 0, 0, 3, 10, "잠옷처럼 편합니다.")
            };

            while (true)
            {
                DrawMenuSelectBox();

                int menuNum = SelectMenu();
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
                    case 3:
                        Dungeon();
                        break;
                    default:
                        continue;
                }
            }
        }
        
        static void InitializeWindow()
        {
            Console.Title = "GearOverGold";
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.BackgroundColor = ConsoleColor.DarkCyan;  // 배경 색깔
            Console.ForegroundColor = ConsoleColor.Yellow;     // 글씨 색깔
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
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

        static Player PlayerIntialize()
        {
            Console.Clear();

            DrawSquare(windowWidth / 4, windowWidth / 4 * 3, windowHeight / 4, windowHeight / 4 * 3);
            Console.SetCursorPosition(windowWidth / 3, windowHeight / 2);
            Console.Write("닉네임: ");
            string name = Console.ReadLine();

            DrawOccupationSelectBox();
            int occupation = SelectOccupation();

            return new Player(name, occupation - 1);
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
            foreach (char c in artString)
            {
                if (c == '\n')
                    Console.SetCursorPosition(startXPos, ++startYPos);
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

        static int SelectOccupation()
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

        static int SelectMenu()
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
                {
                    if (occupationNum == 0)
                        occupationNum = 3;
                    else
                        --occupationNum;
                }
                occupationNum %= 4;
                if (occupationNum == 0) { xPos = 21; yPos = 9; }
                else if (occupationNum == 1) { xPos = 79; yPos = 9; }
                else if (occupationNum == 2) { xPos = 21; yPos = 29; }
                else { xPos = 79; yPos = 29; }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            return occupationNum % 4;
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
            Console.WriteLine("체력:\t" + player.HP + " / " + player.MaxHP);
            Console.SetCursorPosition(windowWidth / 3 + 1, 16);
            Console.WriteLine("Gold:\t" + player.Gold);

            Console.SetCursorPosition(1, windowHeight / 4 * 3 + 2);
            Console.Write("\n 뒤로가기: Enter");

            Console.ReadLine();
        }

        static void Inventory()
        {
            Console.Clear();

            ConsoleTable table = new ConsoleTable("     이 름     ", "           능 력           ", "                      설 명                      ");

            for (int i = 0; i < player.Gears.Count; ++i)
                    table.AddRow(player.Gears[i].Name, player.Gears[i].Info, player.Gears[i].Description);
                table.Write();

            Console.Write("\n 장착: Enter\n 뒤로가기: ESC");

            ConsoleKeyInfo keyInfo;

            int gearSelectNum = 0;
            int xPos = 103;
            int yPos = 3;
            do
            {
                // 그리기
                Console.SetCursorPosition(xPos, yPos);
                if (player.Gears.Count > 0)
                    Console.Write("◀");

                keyInfo = Console.ReadKey();

                // 지우기
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("  ");

                if (keyInfo.Key == ConsoleKey.DownArrow)
                    ++gearSelectNum;
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (gearSelectNum == 0)
                        gearSelectNum = table.Rows.Count - 1;
                    else
                        --gearSelectNum;
                }

                if (table.Rows.Count > 0)
                    gearSelectNum %= table.Rows.Count;

                yPos = 3 + gearSelectNum * 2;
            }
            while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (player.Gears.Count == 0)
                    return;

                player.EquipGear(gearSelectNum);

                Inventory();
            }
        }

        static void Store()
        {
            Console.Clear();

            ConsoleTable table = new ConsoleTable("     이 름     ", " 가 격 ", "         능 력         ", "                   설 명                   ");
            
            for (int i = 0; i < gearsInStore.Count; ++i)
                table.AddRow(gearsInStore[i].Name, gearsInStore[i].Price, gearsInStore[i].Info, gearsInStore[i].Description);

            table.Write();
            Console.Write("\n 구매: Enter\n 뒤로가기: ESC");

            ConsoleKeyInfo keyInfo;

            int gearSelectNum = 0;
            int xPos = 103;
            int yPos = 3;
            do
            {
                // 그리기
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("◀");

                keyInfo = Console.ReadKey();

                // 지우기
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("  ");

                if (keyInfo.Key == ConsoleKey.DownArrow)
                    ++gearSelectNum;
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (gearSelectNum == 0)
                        gearSelectNum = table.Rows.Count - 1;
                    else
                        --gearSelectNum;
                }

                if (table.Rows.Count > 0)
                    gearSelectNum %= table.Rows.Count;

                yPos = 3 + gearSelectNum * 2;
            }
            while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            else
            {
                if (player.Gold >= gearsInStore[gearSelectNum].Price)
                {
                    player.Gold -= gearsInStore[gearSelectNum].Price;
                    player.GetGear(gearsInStore[gearSelectNum]);
                    gearsInStore.RemoveAt(gearSelectNum);
                }
                else
                {
                    Console.WriteLine("Gold 부족");
                    Thread.Sleep(1000);
                }
                Store();
            }
        }

        static void Dungeon()
        {
            Stage stage = new Stage(player.Level);
            List<Monster> monsters = stage.MonstersInStage;

            for (int i = 0; i < monsters.Count; ++i)
            {
                Console.Clear();
                DrawSquare(25, 85, 1, 25);

                if (monsters[i].Name == "Goblin")
                {
                    string goblinArt = "\\.\r\n \\\\      .\r\n  \\\\ _,.+;)_\r\n  .\\\\;~%:88%%.\r\n (( a   `)9,8;%.\r\n /`   _) ' `9%%%?\r\n(' .-' j    '8%%'\r\n `\"+   |    .88%)+._____..,,_   ,+%$%.\r\n       :.   d%9`             `-%*'\"'~%$.\r\n    ___(   (%C                 `.   68%%9\r\n  .\"        \\7                  ;  C8%%)`\r\n  : .\"-.__,'.____________..,`   L.  \\86' ,\r\n  : L    : :            `  .'\\.   '.  %$9%)\r\n  ;  -.  : |             \\  \\  \"-._ `. `~\"\r\n   `. !  : |              )  >     \". ?\r\n     `'  : |            .' .'       : |\r\n         ; !          .' .'         : |\r\n        ,' ;         ' .'           ; (\r\n       .  (         j  (            `  \\\r\n       \"\"\"'          \"\"'             `\"\" ";
                    DrawArt(goblinArt, 34, 4);
                }
                else if (monsters[i].Name == "Dragon")
                {
                    string dragonArt = "                      ^\\    ^                  \r\n                      / \\\\  / \\                 \r\n                     /.  \\\\/   \\      |\\___/|   \r\n  *----*           / / |  \\\\    \\  __/  O  O\\   \r\n  |   /          /  /  |   \\\\    \\_\\/  \\     \\     \r\n / /\\/         /   /   |    \\\\   _\\/    '@___@ \r\n/  /         /    /    |     \\\\ _\\/       |U\r\n|  |       /     /     |      \\\\\\/        |\r\n\\  |     /_     /      |       \\\\  )   \\ _|_\r\n\\   \\       ~-./_ _    |    .- ; (  \\_ _ _,\\'\r\n~    ~.           .-~-.|.-*      _        {-,\r\n \\      ~-. _ .-~                 \\      /\\'\r\n  \\                   }            {   .*\r\n   ~.                 '-/        /.-~----.\r\n     ~- _             /        >..----.\\\\\\\r\n         ~ - - - - ^}_ _ _ _ _ _ _.-\\\\\\";
                    DrawArt(dragonArt, 32, 4);
                }

                while (player.HP != 0 && monsters[i].HP != 0)
                {
                    Console.SetCursorPosition(76, 22);
                    Console.Write("HP: " + monsters[i].HP);

                    Console.SetCursorPosition(25, 27);
                    Console.Write("공격하기");
                    Console.SetCursorPosition(52, 27);
                    Console.Write("방어하기");
                    Console.SetCursorPosition(78, 27);
                    Console.Write("도망치기");

                    Console.SetCursorPosition(48, 30);
                    Console.Write("Player HP: " + player.HP);

                    int selectNum = SelectBattle();

                    if (selectNum == 0)
                    {
                        monsters[i].TakeDamage(player.AttackPower);

                        Console.SetCursorPosition(76, 22);
                        Console.Write("         ");
                        Console.SetCursorPosition(76, 22);
                        Console.Write("HP: " + monsters[i].HP);
                        Thread.Sleep(1000);

                        if (monsters[i].HP > 0)
                        {
                            player.TakeDamage(monsters[i].AttackPower);
                            
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(48, 30);
                            Console.Write("                ");
                        }
                    }
                    else if (selectNum == 1)
                    {
                        player.TakeDamage(monsters[i].AttackPower - player.DefensePower);
                        Thread.Sleep(1000);
                    }
                    else return;
                }
                if (player.HP == 0)
                {
                    Console.SetCursorPosition(46, 35);
                    Console.Write("몬스터에게 패 했습니다.");
                    Thread.Sleep(1000);
                    return;
                }
                else
                {
                    Console.SetCursorPosition(46, 35);
                    Console.Write("몬스터를 이겼습니다!");
                    Console.SetCursorPosition(48, 37);
                    Console.Write(monsters[i].GoldReward + " Gold 획득");
                    player.Gold += monsters[i].GoldReward;

                    Thread.Sleep(1500);

                    SelectReward();
                }
            }
        }

        static int SelectBattle()
        {
            ConsoleKeyInfo keyInfo;

            int selectNum = 0;
            int xPos = 22;
            int yPos = 27;
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
                    ++selectNum;
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (selectNum == 0)
                        selectNum = 2;
                    else 
                        --selectNum;
                }

                if (selectNum > 2)
                    selectNum %= 3;

                if (selectNum == 0) xPos = 23;
                else if (selectNum == 1) xPos = 50;
                else xPos = 76;
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            return selectNum;
        }

        static void SelectReward()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 15);
            Console.Write("보상을 선택해주세요.");
            Console.SetCursorPosition(35, 20);
            Console.Write("HP 50 회복");
            Console.SetCursorPosition(60, 20);
            Console.Write("공격력 10 상승");

            ConsoleKeyInfo keyInfo;

            int selectNum = 0;
            int xPos = 33;
            int yPos = 20;
            do
            {
                // 그리기
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("▶");

                keyInfo = Console.ReadKey();

                // 지우기
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("  ");

                if (keyInfo.Key == ConsoleKey.RightArrow)
                    ++selectNum;
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (selectNum == 0)
                        selectNum = 1;
                    else
                        --selectNum;
                }

                if (selectNum > 1)
                    selectNum %= 2;

                if (selectNum == 0) xPos = 33;
                else xPos = 58;
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            if(selectNum == 0)
            {
                HealthPotion potion = new HealthPotion();
                potion.Use(player);
                if (player.HP > player.MaxHP)
                    player.HP = player.MaxHP;
            }
            else
            {
                StrengthPotion potion = new StrengthPotion();
                potion.Use(player);
            }
                
        }
    }
}