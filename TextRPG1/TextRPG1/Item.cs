using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG1
{
    class Item
    {
        public int HP { get; set; } //체력 설정
        public string ItemName { get; set; } //아이템이름설정
        public string IsIm { get; set; } //아이템 설명
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool IsEquipped { get; set; }

        

        public Item(string itemname, int attack, int defense, int hp, string isim)
        {
            ItemName = itemname;
            Attack = attack;
            Defense = defense;
            HP = hp;
            IsIm = isim;
            IsEquipped = false;
            
        }

        public string GetDisplayName()// 장착시 e표시
        {
            return $"{(IsEquipped ? "[E]" : "")}{ItemName}";
        }
    }

}
