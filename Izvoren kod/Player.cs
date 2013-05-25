using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    public class Player
    {
        public String Nickname { get; set; }
        public int Poeni { get; set; }
        public Player() 
        {
            Poeni = 0;
        }
        public Player(String n, int p)
        {
            Nickname = n;
            Poeni = p;
        }
    }
}
