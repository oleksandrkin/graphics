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
            startPoint = new Point(0, heigth/2);
        }

        public Function Function { get; set; }

        public float RotateAngle { get; set; }

        public int FigureCount { get; set; }

        public void DrawImage()
        {
            double step = Math.PI/360;
            float x = Function.X(0);
            float y = Function.Y(0);
            for (double i = step; i < 4*Math.PI; i += step)
            {
                float nextX = Function.X(i);
                float nextY = Function.Y(i);
                g.DrawLine(pen, x + startPoint.X, y + startPoint.Y, nextX + startPoint.X, nextY + startPoint.Y);
                x = nextX;
                y = nextY;
            }
        }

        public void DrawMirrorImage()
        {
            double step = Math.PI / 360;
            float x = Function.X(0);
            float y = -Function.Y(0);
            for (double i = step; i < 4 * Math.PI; i += step)
            {
                float nextX = Function.X(i);
                float nextY = -Function.Y(i);
                g.DrawLine(pen, x + startPoint.X, y + startPoint.Y, nextX + startPoint.X, nextY + startPoint.Y);
                x = nextX;
                y = nextY;
            }
        }
            
        public void Draw(Graphics gr)
        {
            gr.Clear(Color.White);
            Matrix matrix = new Matrix();
            for (int i = 0; i < FigureCount; i++)
            {
                gr.DrawImage(image, 0, 0);
                matrix.RotateAt(RotateAngle, new PointF(startPoint.X + image.Width/2, startPoint.Y));
                gr.Transform = matrix;
            }
        }
    }
}
