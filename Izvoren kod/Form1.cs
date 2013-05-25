using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Runner
{
    public partial class Form1 : Form
    {
        public List<Player> players;
        public Form1()
        {
            InitializeComponent();
            cmbLevel.Items.Add("Level1");
            cmbLevel.Items.Add("Level2");
            cmbLevel.Items.Add("Level3");
            players = new List<Player>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Nickname == tbIme.Text)
                {
                    flag = true;
                    tbPoeni.Text = Convert.ToString(players[i].Poeni);
                }
            }
            if (flag == false)
            {
                tbPoeni.Text = "0";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < players.Count-1; i++)
            {
                for (int j = i + 1; j < players.Count; j++)
                {
                    if (players[i].Poeni > players[j].Poeni)
                    {
                        Player tmp = players[i];
                        players[i] = players[j];
                        players[j] = tmp;
                    }
                }
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (tbIme.Text == "")
            {
                MessageBox.Show("Vnesete Ime!");
                return;
            }
            if (cmbLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Izberete level!");
                return;
            }
            foreach (Player p in players)
            {
                if (p.Nickname == tbIme.Text)
                {
                    flag = true;
                    p.Poeni = 0;
                }
            }
            if (flag == false)
            {
                Player p = new Player(tbIme.Text, 0);
                players.Add(p);
            }
            
            //this.Hide();
            if (cmbLevel.SelectedIndex == 0)
            {
                Program.Poeni = 0;
                Igra igra = new Igra();
                if (igra.ShowDialog() == DialogResult.Cancel)
                {
                    
                    
                }
            }
            
            if (cmbLevel.SelectedIndex == 1)
            {
                Program.Poeni = 0;
                Igraa1 igra1 = new Igraa1();
                if (igra1.ShowDialog() == DialogResult.Cancel)
                {
                    
                }
            }
            
            if (cmbLevel.SelectedIndex == 2)
            {
                Program.Poeni = 0;
                Igra2 igra2 = new Igra2();
                if (igra2.ShowDialog() == DialogResult.Cancel)
                {
                    
                }
            }
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Nickname == tbIme.Text)
                {
                    players[i].Poeni = Program.Poeni;
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
