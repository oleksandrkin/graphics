using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1_GM
{
    class Square : Figure
    {
        public Square(int sideLength)
            : base((int)Math.Round(sideLength * Math.Sqrt(2)))
        {
            Center = new PointF(Image.Width / 2, Image.Height / 2);
            SideLength = sideLength;
            Draw();
        }

        public void NewLength(int length, int angle)
        {
            SideLength = length;
            base.Length((int)Math.Round(SideLength * Math.Sqrt(2)));
            Center = new PointF(Image.Width / 2, Image.Height / 2);
            Rotate(angle);
            Draw();
        }

        public float SideLength { get; set; }

        public override void Draw()
        {
            graphics.DrawRectangle(pen, Center.X - SideLength / 2, Center.Y - SideLength / 2, SideLength, SideLength);
            graphics.DrawEllipse(pen, Center.X - SideLength / 2, Center.Y - SideLength / 2, SideLength, SideLength);
        }
    }
}
