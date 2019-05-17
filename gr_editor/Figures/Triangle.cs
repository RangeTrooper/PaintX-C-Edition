using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using gr_editor.Interfaces;

namespace gr_editor.Figures
{
    class Triangle:AbstrFigure,ISelectable,IMovable
    {
        public Triangle(Point a,Point b):base(a,b)
        {

        }


        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, x, y + h, x + w, y + h);
            g.DrawLine(pen, x, y + h, x + w / 2, y);
            g.DrawLine(pen, x + w/2, y,x+w,y+h);
            if (isSelected)
            {
                ShowSelection(g);
            }

        }

        public override bool IsSelected(Point point)
        {
            float prod1, prod2, prod3;
            prod1 = ((x - point.X) * (y - (y + h)) - (x + w / 2 - x) * (y + h - point.Y));
            prod2 = ((x + w / 2 - point.X) * (y + h - y) - (x + w - (x + w / 2)) * (y - point.Y));
            prod3 = ((x + w - point.X) * (y + h - (y + h)) - (x - (x + w) * (y + h - point.Y)));
            if (((prod1 > 0) && (prod2 > 0) && (prod3 > 0)) || ((prod1 < 0) && (prod2 < 0) && (prod3 < 0)))
            {
                return true;
            } else
                return false;
        }

        public override void ShowSelection(Graphics g)
        {
            base.ShowSelection(g);
        }
    }
}
