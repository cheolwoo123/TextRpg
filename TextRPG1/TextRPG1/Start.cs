using System;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace TextRPG1
{
    class Start
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                // 게임 시작          
                Console.WriteLine("불친절한 스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();     
                Console.Write("직업부터 선택해 (전사, 궁수, 마법사, 창술사): ");
                string job = Console.ReadLine();
               


                if (job == "전사" || job == "궁수" || job == "마법사" || job == "창술사")
                {
                    Player player = new Player(job);

                    while (true)
                { 
               
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                        Console.WriteLine("4. 전투");
                        Console.WriteLine();
                    Console.Write("원하는 행동을 입력: ");

                  
                     string input = Console.ReadLine();
                     int choice;

                    if (int.TryParse(input, out choice))
                {
                            switch (choice)
                            {
                                case 1:

                                    player.ShowPlayerStatus();
                                    break;
                                case 2:

                                    while (true)
                                    {
                                        player.Inventory.ShowInventory();
                                        string wkdckr = Console.ReadLine();

                                        if (wkdckr == "1")
                                        {
                                            player.Inventory.Equip();
                                        }
                                        else if (wkdckr == "0")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("잘못된 입력");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                    break;
                                case 3:
                                    Shop shop = new Shop();
                                    shop.MainShop(player);
                                    break;

                                case 4:
                                    
                                    Game game = new Game(player);
                                    game.StartBattle();
                                    break ;

                                default:
                                    Console.WriteLine("잘못된 입력 숫자를 모르십니까?");
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("올바른 직업이 아닌데");
                    Console.WriteLine("한글을 못 읽으십니까?");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
