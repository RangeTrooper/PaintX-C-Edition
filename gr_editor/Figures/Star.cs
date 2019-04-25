using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gr_editor.Figures
{
    class Star:AbstrFigure
    {
        public Star(Point a,Point b):base(a,b)
        {

        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, x, y + h / 2, x + w / 3, y + h/ 3);
            g.DrawLine(pen, x + w / 3, y + h/ 3, x + w / 2, y);
            g.DrawLine(pen, x + w / 2, y, x + 2 * w / 3, y + h / 3);
            g.DrawLine(pen, x +2* w / 3, y + h / 3, x + w, y + h / 2);
            g.DrawLine(pen, x + w, y + h / 2, x + 2 * w / 3, y + 2 * h / 3);
            g.DrawLine(pen, x + 2 * w / 3, y + 2 * h / 3, x + w / 2, y + h);
            g.DrawLine(pen, x + w / 2, y + h, x +  w / 3, y + 2 * h / 3);
            g.DrawLine(pen, x +  w / 3, y + 2 * h / 3, x, y + h / 2);

        }
    }
}
