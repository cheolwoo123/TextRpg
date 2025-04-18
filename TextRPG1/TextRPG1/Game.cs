using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG1
{

    class Game
    {

        private Player player;

        public Game(Player player)
        {
            this.player = player;
        }

        public void StartBattle()
        {
            Monster monster = new Monster("슬라임", 3, 3, 50);
            Console.Clear();
            Console.WriteLine($"{monster.Name}이 등장");

            while (player.Hp > 0 && monster.HP > 0)
            {
                Console.WriteLine($"\n플레이어 HP: {player.Hp + player.Inventory.HPBonus()}");
                Console.WriteLine($"{monster.Name} HP: {monster.HP}");

                Console.WriteLine("1. 공격");
                Console.WriteLine("0. 도망");
                Console.Write("행동을 선택: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    int damageToMonster = Math.Max(0, (player.Attack + player.Inventory.AttackBonus()) - monster.Defense);
                    monster.HP -= damageToMonster;
                    Console.WriteLine($"몬스터가 {damageToMonster}의 피해를 받음");

                    if (monster.HP <= 0)
                    {
                        Console.WriteLine("승리");
                        break;
                    }

                    int damageToPlayer = Math.Max(0, monster.Attack - (player.Defense + player.Inventory.DefenseBonus()));
                    player.Hp -= damageToPlayer;
                    Console.WriteLine($"플레이어가 {damageToPlayer}의 피해를 받음");

                    if (player.Hp <= 0)
                    {
                        Console.WriteLine("사망");
                        break;
                    }
                }
                else if (input == "0")
                {
                    Console.WriteLine("도망");
                    break;
                }
            }

            Console.WriteLine("아무키나 입력.");
            Console.ReadKey();
        }
    }
}
        
