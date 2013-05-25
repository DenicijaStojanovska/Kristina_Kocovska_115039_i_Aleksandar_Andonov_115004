using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Runner
{
    
    public class Covece
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool dole = true;
        public bool gore = false;
        public int visina { get; set; }
        public int gore1 { get; set; }
        public Covece() { }
        public Covece(int xx, int yy,int v,int g)
        {
            visina = v;
            x = xx;
            y = yy;
            gore1 = g;
        }
        public void Draw(Graphics g)
        {
            LinearGradientBrush b = new LinearGradientBrush(new Point(x, y), new Point(x+50, y+50), Color.Blue, Color.Black);
            
            
            g.FillEllipse(b, x, y, 50, 50);
        }
        public void Paga()
        {
            if (y != 380)
            {
                y += 10;
            }
        }
        public void Skoka()
        {
            if (y == gore1)
            {
                gore = true;
                dole = false;
            }
            if (y == visina)
            {
                dole = true;
                gore = false;
            }
            if (dole == true)
            {
                y -= 10;

            }
            if (gore == true)
            {
                y += 10;
            }
            
        }
    }
}
