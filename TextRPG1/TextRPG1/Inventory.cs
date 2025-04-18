using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG1
{
    class Inventory
    {
        public List<Item> Items = new List<Item>();

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템 관리 가능");
            Console.WriteLine("\n[아이템 목록]");
            foreach (var item in Items)
            {
                string statInfo = "";
                //스텟+가 0일때 표시안함
                if (item.Attack > 0) statInfo += $"공격력 +{item.Attack} ";
                if (item.Defense > 0) statInfo += $"방어력 +{item.Defense} ";
                if (item.HP > 0) statInfo += $"체력 +{item.HP} ";

                Console.WriteLine($"- {item.GetDisplayName(),-15} | {statInfo}| {item.IsIm}");
            }

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력: ");
        }

        public void Equip()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리 가능");
                Console.WriteLine("\n[아이템 목록]");

                for (int i = 0; i < Items.Count; i++)
                {
                    var item = Items[i];
                    string statInfo = "";
                    //스텟+가 0일때 표시안함
                    if (item.Attack > 0) statInfo += $"공격력 +{item.Attack} ";
                    if (item.Defense > 0) statInfo += $"방어력 +{item.Defense} ";
                    if (item.HP > 0) statInfo += $"체력 +{item.HP} ";       
                    Console.WriteLine($"- {i + 1}. {item.GetDisplayName()} | {statInfo}| {item.IsIm}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하시는 행동을 입력: ");
                string input = Console.ReadLine();

                if (input == "0") break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= Items.Count)
                {
                    Items[index - 1].IsEquipped = !Items[index - 1].IsEquipped;
                    Console.WriteLine(Items[index - 1].IsEquipped ? "장착 성공" : "장착 해제");
                }
                else
                {
                    Console.WriteLine("잘못된 입력");
                }

                Console.WriteLine("아무키를 입력하시오.");
                
            }
        }

        public int AttackBonus()
        {
            return Items.Where(i => i.IsEquipped).Sum(i => i.Attack);
        }

        public int DefenseBonus()
        {
            return Items.Where(i => i.IsEquipped).Sum(i => i.Defense);
        }
        public int HPBonus()
        {
            return Items.Where(i => i.IsEquipped).Sum(i => i.HP);
        }
    }

}
