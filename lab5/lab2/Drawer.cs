using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab2
{
    public class Drawer
    {
        private Bitmap image;
        private Graphics g;
        private Pen pen = new Pen(Color.Black);

        private Point startPoint; 
        
        public Drawer(int width, int heigth)
        {
            image = new Bitmap(width, heigth);
            g = Graphics.FromImage(image);
            startPoint = new Point(0, heigth*3/4);
        }

        public Function Function { get; set; }

        private float ind = 0;

        public void DrawImage()
        {
            double step = Math.PI/360;
            float x = Function.X(0);
            float y = Function.Y(0);
            g.Clear(Color.White);
            for (double i = step; i < 12*Math.PI; i += step)
            {
                float nextX = Function.X(i);
                float nextY = Function.Y(i);
                g.DrawLine(pen, x + startPoint.X, y + startPoint.Y, nextX + startPoint.X, nextY + startPoint.Y);
                x = nextX;
                y = nextY;
            }
            double moveStep = Math.PI/20;
            g.FillEllipse(new SolidBrush(Color.Tomato), Function.X(ind*moveStep) + startPoint.X -r/2 , Function.Y(ind++*moveStep) + startPoint.Y - r/2, r, r);
        }

        private float r = 16;

        public void Draw(Graphics gr)
        {
            gr.DrawImage(image, 0, 0);
        }
    }
}
