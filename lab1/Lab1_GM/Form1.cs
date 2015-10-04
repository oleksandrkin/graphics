using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GM
{
    public partial class Form1 : Form
    {
        Square square;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            square.NewLength(Convert.ToInt32(((NumericUpDown)sender).Value), (int)(numericUpDown2.Value));
            DrawOrnament();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            square = new Square((int)numericUpDown1.Value);
            graphics = pictureBox1.CreateGraphics();
            DrawOrnament();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
            numericUpDown3.Visible = true;
            button1.Visible = false;
            checkBox1.Visible = true;
        }

        private void DrawOrnament()
        {
            if(square.ClearPrev)
                graphics.Clear(Color.White);
            int step = (int)numericUpDown3.Value;
            int size = 2 * pictureBox1.Width / square.Image.Width + 20;
            int X = 0;
            int Y = 0;
            
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    graphics.DrawImage(square.Image, X + j * step, Y + i * step);
                }
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            square.Rotate((int)((NumericUpDown)sender).Value);
            DrawOrnament();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            DrawOrnament();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            square.ClearPrev = ((CheckBox)sender).Checked;
        }
    }
}
