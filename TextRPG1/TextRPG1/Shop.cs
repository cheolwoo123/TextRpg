using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextRPG1
{
    internal class Shop
    {

        //상점에서 팔 아이템들을 담는 리스트
        public List<Item> ShopItem { get; set; }
    
        public Shop() 
        {

            ShopItem = new List<Item>
            {
            new Item("강?철?검", 7,0,0,"강철인지는 아무도 모르는 무기") ,
            new Item("그나마 쓸만한 가죽갑옷", 0, 3,15 , "그냥저냥 쓸만하다") ,
            new Item("떡갈나무로 만든 가성비 지팡이 ", 10, 0,1, "옆집에서 훔쳐온 지팡이 꽤 쓸만하다") ,
            new Item("쓸데없이 매우매우매우매우 긴창", 8, 5,5, "사거리하나는 일품이다") ,
            new Item("뾰족한 장난감 나무활", 9, 2,3 ,"이거로 맞는다고 죽을까?")
            };

        }

        //플레이어가 상점에 진입 반복문 안에서 아이템을 출력하고 구매
        public void MainShop (Player player)
        {
            while (true)
            {
                Console.WriteLine("상점");

                Console.WriteLine("\n");
                //현재 플레이어가 가진 골드
                Console.WriteLine($"보유골드 : {player.Gold} Gold");

                Console.WriteLine("판매목록");

                for (int i = 0; i < ShopItem.Count; i++)
                {
                    var item = ShopItem[i];


                    Console.WriteLine($"{i + 1}. {item.ItemName} | " +
                   $"{(item.Attack > 0 ? $"공격력 +{item.Attack} " : "")}" +
                   $"{(item.Defense > 0 ? $"방어력 +{item.Defense} " : "")}" +
                   $"{(item.HP > 0 ? $"체력 +{item.HP} " : "")}" +
                   $"| 가격: {(item.Attack + item.Defense) * 100} Gold" +
                   $" | 설명: {item.IsIm}");
                  

                }
                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하는 번호를 입력 ");
                string input = Console.ReadLine();


                if (input == "0") break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= ShopItem.Count)
                {


                   // int cout = player.Inventory.Items.ItemName.Find(x => x == ShopItem[index - 1]);

                    Item selecItem = ShopItem[index - 1];


                  

                    int price = (selecItem.Attack + selecItem.Defense) * 100;

                    if (player.Gold >= price)
                    {
                        player.Gold -= price;
                        player.Inventory.Items.Add(selecItem);
                        Console.WriteLine($"{selecItem.ItemName} 구매성공");
                       
                  
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족 돈벌어와라");
                        Console.WriteLine("아무키 입력하면 상점으로 돌아간다");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력 있는거만 사야지");
                    Console.WriteLine("아무키 입력하면 상점으로 돌아간다");
                    Console.ReadKey();
                }

            

                

            }
        }
    }



}

        
