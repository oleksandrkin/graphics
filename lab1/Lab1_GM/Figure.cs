using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab1_GM
{
    abstract class Figure
    {
        protected Figure(int length)
        {
            image = new Bitmap(length, length);
            graphics = Graphics.FromImage(image);
            ClearPrev = true;
        }

        protected Graphics graphics;
        //Matrix matrix = new Matrix();

        private Bitmap image;
        public void Length(int length)
        {
            image = new Bitmap(length, length);
            graphics = Graphics.FromImage(image);
        }
        public Bitmap Image
        {
            get { return image; }
        }

        public PointF Center { get; set; }

        /// <summary>
        /// Draw figure on picture box.
        /// </summary>
        public abstract void Draw();

        protected Pen pen = new Pen(Color.Black);

        public bool ClearPrev
        {
            get;
            set;
        }

        public void Clear()
        {
            if (ClearPrev)
            {
                pen.Color = Color.White;
                Draw();
                pen.Color = Color.Black;
            }
        }

        /// <summary>
        /// Rotate figure.
        /// </summary>
        public void Rotate(float angle)
        {
            Clear();
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, Center);
            graphics.Transform = matrix;
            Draw();
        }
    }
}
