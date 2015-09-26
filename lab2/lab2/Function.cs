using System;

namespace lab2
{
    public class Function
    {
        public Function(float r)
        {
            R = r;
        }

        public float R { get; set; }

        public float X(double t)
        {
            return R * (float)(t - Math.Sin(t)); // 7v
            //return R * (float)(t * Math.Cos(t)); // 6v
            //return R * (float)Math.Cos(3*t); // 1v
        }
        
        public float Y(double t)
        {
            return -R * (float)(1 - Math.Cos(t)); // 7v
            //return R * (float)(t * Math.Sin(t)); // 6v
            //return R * (float)Math.Sin(7*t); // 1v
        }
    }
}
