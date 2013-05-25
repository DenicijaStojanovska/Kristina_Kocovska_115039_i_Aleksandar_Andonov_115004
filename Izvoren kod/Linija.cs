using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Runner
{
    public class Linija
    {
        public bool povikano = false;
        public bool namaluvaj = false;
        public bool zgolemuvaj = false;
        public int x { get; set; }
        public int y { get; set; }
        public int dolzina { get; set; }
        public Brush boja { get; set; }
        public Linija() { }
        public Linija(int xx, int yy, int d,Brush b)
        {
            x = xx;
            y = yy;
            dolzina = d;
            boja = b;
        }
        public void Draw(Graphics g)
        {
            Pen p=new Pen(boja);
            p.Width=5;
            g.DrawLine(p, x, y, x + dolzina, y);
        }
        public void Move()
        {
            x -= 10;
        }
        public void Dolzina()
        {
            if (povikano == false)
            {
                Random r = new Random();
                int broj = r.Next(0, 2);
                povikano = true;
                if (broj == 0)
                {
                    namaluvaj = true;
                }
                else
                {
                    zgolemuvaj = true;
                }
            }
            else
            {
                if (namaluvaj == true)
                {
                    dolzina -= 3;
                    if (dolzina < 60)
                    {
                        namaluvaj = false;
                    }
                }
                if (namaluvaj == false)
                {
                    dolzina += 3;
                    if (dolzina > 130)
                    {
                        namaluvaj = true;
                    }
                }
            }

        }
    }
}
