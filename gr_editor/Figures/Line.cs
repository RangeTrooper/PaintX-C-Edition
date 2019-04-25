using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Line:AbstrFigure
    {
        public Line(Point a,Point b):base(a,b)
        {

        }

        public Line():base()
        {

        }

        public override void Draw(Graphics g, Pen pen)
        {

            g.DrawLine(pen, leftUpVert, rightBotVert);
        }

    }
}
