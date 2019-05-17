using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using gr_editor.Interfaces;

namespace gr_editor.Figures
{
    class Star:AbstrFigure,IMovable,ISelectable
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

        public override bool IsSelected(Point point)
        {
            float prod1, prod2, prod3;
            prod1 = ((x - point.X) * (y + h / 3 - (y + h / 2)) - (x + w / 3 - x) * (y + h / 2 - point.Y));
            prod2 = ((x + w / 2 - point.X) * (y + h - y) - (x + w - (x + w / 2)) * (y - point.Y));
            prod3 = ((x + w - point.X) * (y + h - (y + h)) - (x - (x + w) * (y + h - point.Y)));
            if (((prod1 > 0) && (prod2 > 0) && (prod3 > 0)) || ((prod1 < 0) && (prod2 < 0) && (prod3 < 0)))
            {
                return false;
            }else
            {

            }
            return true;
        }
    }
}
