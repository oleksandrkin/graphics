using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Redraw();
        }

        private void Redraw()
        {
            drawer = new Drawer(pictureBox1.Width, pictureBox1.Height)
            {
                Function = new Function((float)numericUpDown1.Value),
                RotateAngle = (float)numericUpDown2.Value,
                FigureCount = (int)numericUpDown3.Value
            };
            drawer.DrawImage();
            if(checkBox2.Checked)
                drawer.DrawMirrorImage();
            drawer.Draw(pictureBox1.CreateGraphics());
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               Redraw();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Redraw();
            }
        }
    }
}
