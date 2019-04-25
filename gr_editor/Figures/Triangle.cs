using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gr_editor.Figures
{
    class Triangle:AbstrFigure
    {
        public Triangle(Point a,Point b):base(a,b)
        {

        }

        public Triangle():base()
        {

        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, x, y + h, x + w, y + h);
            g.DrawLine(pen, x, y + h, x + w / 2, y);
            g.DrawLine(pen, x + w/2, y,x+w,y+h);

        }
    }
}
