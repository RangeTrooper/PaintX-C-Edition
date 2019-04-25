using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Oval : AbstrFigure
    {
        public Oval(Point a, Point b) : base(a, b)
        {

        }

        public Oval() : base()
        {

        }
        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, x, y, w, h);
        }
    }
}
