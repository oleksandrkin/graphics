using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Drawer drawer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            drawer = new Drawer(pictureBox1.Width, pictureBox1.Height)
            {
                Function = new Function((float)numericUpDown1.Value),
            };
        }

        private void Redraw()
        {
            drawer.DrawImage();
            t++;
            
            drawer.Draw(pictureBox1.CreateGraphics());
        }

        private int t = 0;
        private void timer1_Tick(object sender, EventArgs e)
        { 
            Redraw();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            drawer = new Drawer(pictureBox1.Width, pictureBox1.Height)
            {
                Function = new Function((float)numericUpDown1.Value),
            };
        }

    }
}
