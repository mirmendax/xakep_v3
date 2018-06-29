using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace libgame
{
    public class RePoint
    {
        static int Width = 0;
        static int Height = 0;

        public RePoint(int x, int y)
        {
            Width = x;
            Height = y;
        }

        public RePoint() { }

        public Point Point(float x, float y)
        {
            return new Point((int)(Width * x), (int)(Height * y));
        }
    }
}
