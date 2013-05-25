using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Runner.Properties;

namespace Runner
{
    public partial class Igra : Form
    {
        
        public int izbrisani;
        public bool paga = false;
        public int Poeni;
        public Bitmap doubleBuffer;
        public Graphics graphics;
        public Covece covece;
        public Timer t1;
        public Timer t2;
        public Timer t3;
        public List<Linija> linii;
        public int kordinataX;
        public Timer t4;
        public Timer t5;
        public Igra()
        {

            InitializeComponent();
     
            izbrisani = 0;
            t5 = new Timer();
            t5.Interval = 1000 / 24;
            t5.Tick += new EventHandler(t5_Tick);
            t4 = new Timer();
            t4.Interval = 1000;
            t4.Tick += new EventHandler(t4_Tick);
            t2 = new Timer();
            t3 = new Timer();
            t3.Interval = 1000 / 24;
            t2.Interval = 1000 / 24;
            t1 = new Timer();
            t1.Interval = 1000 / 24;
            t1.Tick += new EventHandler(t1_Tick);
            t2.Tick += new EventHandler(t2_Tick);
            t3.Tick += new EventHandler(t3_Tick);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            NewGame();

        }

        void t5_Tick(object sender, EventArgs e)
        {
            paga = true;
            if (covece.y != 100)
            {

                covece.y += 10;
            }
            else
            {
                if (covece.x+30 < linii[0].x)
                {

                    
                        t3.Start();
                        t5.Stop();

                }
            }

        }
        public void NewGame()
        {
            
            izbrisani = 0;
            Poeni = 0;
            label2.Text = Convert.ToString(Poeni);
            paga = false;
            t4.Start();
            t5.Stop();
            linii = new List<Linija>();
            Linija l = new Linija();
            l = new Linija(Width, Height / 2, 200, new LinearGradientBrush(new Point(l.x, l.y), new Point(l.x + l.dolzina, l.y + 5), Color.Red, Color.Gray));
            linii.Add(l);
            t1.Start();
            doubleBuffer = new Bitmap(Width,Height);
            covece = new Covece(30, 0, 100, 20);
            kordinataX = covece.x + 15;
            progressBar1.Value = 20;
            
        }
        void t4_Tick(object sender, EventArgs e)
        {
            if (Program.f == 0)
            {
                Random r = new Random();
                for (int i = 0; i < linii.Count; i++)
                {
                    SolidBrush bb1 = new SolidBrush(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                    Color c1 = bb1.Color;

                    LinearGradientBrush br = new LinearGradientBrush(new Point(linii[i].x, linii[i].y), new Point(linii[i].x + linii[i].dolzina, linii[i].y + 3), c1, Color.Gray);
                    linii[i].boja = br;
                }
                if (progressBar1.Value == 16)
                {
                    label3.Text = "";
                }
                if (progressBar1.Value == 16 && covece.y==0)
                {
                    t5.Start();
                }
                if (progressBar1.Value == 0)
                {
                    t1.Stop();
                    t2.Stop();
                    t3.Stop();
                    t4.Stop();
                    DialogResult rez = new DialogResult();
                    rez = MessageBox.Show("Sledno nivo??.", "Sledno nivo?", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (rez == DialogResult.Yes)
                    {
                        Program.Poeni = Program.Poeni + Poeni;
                        this.Visible = false;
                        Igraa1 nivo2 = new Igraa1();
                        nivo2.ShowDialog();
                    }
                    if (rez == DialogResult.No)
                    {
                        MessageBox.Show("Osvoivte: " + Poeni + " poeni!");
                      
                        this.Close();
                        
                    }

                }
                if (progressBar1.Value != 0)
                {
                    if (!this.IsAccessible)
                        progressBar1.Value--;
                }
            }
        }

        void t3_Tick(object sender, EventArgs e)
        {
            covece.Paga();
            paga = true;
            if (covece.y == 380)
            {
                
                t1.Stop();
                t2.Stop();
                t3.Stop();
                t4.Stop();
                DialogResult rez = new DialogResult();
                rez = MessageBox.Show("Igraj pak?", "Nova igra?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rez == DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    MessageBox.Show("Osvoivte: " + Poeni + " poeni!");
                 
                    this.Close();
                }
            }
        }

        void t2_Tick(object sender, EventArgs e)
        {
            covece.Skoka();
            if (covece.y == 100)
            {

                t2.Stop();

                if (covece.x+5 > linii[0].x + linii[0].dolzina && covece.x + 25 < linii[1].x)
                {
                    t3.Start();
                }
                if (linii[0].dolzina <= 600)
                {
                    Poeni += 3;
                    label2.Text = Convert.ToString(Poeni);
                }
            }
        }

        void t1_Tick(object sender, EventArgs e)
        {
            
            graphics = CreateGraphics();
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.SkyBlue);
            if (covece.y == 100)
            {
                t5.Stop();
                if (izbrisani == 0)
                {
                    
                    if (covece.x < linii[0].x)
                    {
                        t3.Start();
                        paga = true;
                    }
                }
                paga = false;
            }
            for (int i = 0; i < linii.Count; i++)
            {
                linii[i].Draw(g);
                linii[i].Move();
                if (linii[i].x + linii[i].dolzina < 0)
                {
                    linii.RemoveAt(i);
                    izbrisani++;
                }
            }
            covece.Draw(g);
            Random r = new Random();
            if (linii[linii.Count - 1].x + linii[linii.Count - 1].dolzina + r.Next(30, 80) < Width)
            {
                Linija l = new Linija();
                l = new Linija(Width, Height / 2, r.Next(100, 150), new LinearGradientBrush(new Point(l.x, l.y), new Point(l.x + l.dolzina, l.y + 5), Color.Red, Color.Gray));
                linii.Add(l);
            }

            if (covece.x +5 > linii[0].x + linii[0].dolzina && covece.x + 25 < linii[1].x)
            {
                if (covece.y == 100)
                {
                    t3.Start();
                }

            }
            
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
            
        }

        private void Igra_KeyUp(object sender, KeyEventArgs e)
        {

            if (paga == false)
            {
                if (Keys.Space == e.KeyCode)
                {
                    paga = true;
                    if (covece.y == 0 && covece.x == 30)
                    {
                        t5.Start();
                    }
                    else
                    {
                        
                        t5.Stop();
                        t2.Start();
                    }
                }

            }
        }

        private void Igra_FormClosed(object sender, FormClosedEventArgs e)
        {
         
         
            t1.Stop();
            t2.Stop();
            t3.Stop();
            t4.Stop();
            t5.Stop();
        }


        private void Igra_Load(object sender, EventArgs e)
        {
            Program.f = 0;
        }
    }
}
