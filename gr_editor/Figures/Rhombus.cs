using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Rhombus:AbstrFigure
    {
        public Rhombus(Point a,Point b):base(a,b)
        {

        }

        public Rhombus():base()
        {

        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, x, y + h / 2, x + w / 2, y);
            g.DrawLine(pen, x + w / 2, y,x+w, y + h / 2);
            g.DrawLine(pen, x + w , y+h/2, x + w / 2,y+h);
            g.DrawLine(pen, x + w / 2, y + h, x, y + h / 2);
        }
    }
}
