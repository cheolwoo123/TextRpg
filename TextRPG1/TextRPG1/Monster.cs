using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG1
{
    internal class Monster
    {        
            public string Name { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int HP { get; set; }

            public Monster(string name, int attack, int defense, int hp)
            {
                Name = name;
                Attack = attack;
                Defense = defense;
                HP = hp;
            }
        }
    }
