using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace TextRPG1
    {
        internal class Player
        {

        public Inventory Inventory { get; set; } = new Inventory();
        public List<string> PurchasedItems { get; set; } = new List<string>();

        public int Level { get; set; } //레벨
            public string Job { get; set; } //직업
            public int Attack { get; set; } //공격력
            public int Defense { get; set; } //방어력
            public int Hp { get; set; } //체력
            public int Gold { get; set; } //소지골드

            //직업 기본 정보 설정
            public Player(string job)
            {
                
                // 직업 기본 속성 설정
                switch (job)
                {
                    case "전사":
                        Job = "전사";
                        Level = 1;
                        Attack = 10;
                        Defense = 10;
                        Hp = 150;
                        Gold = 1000;
                        break;

                    case "마법사":
                        Job = "마법사";
                        Level = 1;
                        Attack = 20;
                        Defense = 5;
                        Hp = 80;
                        Gold = 1000;
                        break;

                    case "궁수":
                        Job = "궁수";
                        Level = 1;
                        Attack = 18;
                        Defense = 7;
                        Hp = 90;
                        Gold = 1000;
                        break;

                    case "창술사":
                        Job = "창술사";
                        Level = 1;
                        Attack = 15;
                        Defense = 8;
                        Hp = 100;
                        Gold = 1500;
                        break;

                    default:
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("잘못된 직업명");
                        break;
            }
           
        }

            // 플레이어 스텟 
            public  void ShowPlayerStatus()
            {
            //장비 착용햇을때
            int TAttack = Attack + Inventory.AttackBonus();    
            int TDefense = Defense + Inventory.DefenseBonus();
            int TotalHp = Hp + Inventory.HPBonus();

            Console.WriteLine($"직업: {Job}");
                Console.WriteLine($"레벨: {Level}");
            Console.WriteLine($"공격력: {TAttack} (기본 {Attack} + 장비효과 {Inventory.AttackBonus()})");
            Console.WriteLine($"방어력: {TDefense} (기본 {Defense} + 장비효과 {Inventory.DefenseBonus()})");
            Console.WriteLine($"체력:   {TotalHp} (기본 {Hp}+ 장비효과 { Inventory.HPBonus()})");
                Console.WriteLine($"Gold: {Gold}");
            }
        }

        
    }


