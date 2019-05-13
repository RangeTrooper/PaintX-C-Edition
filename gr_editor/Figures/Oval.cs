using gr_editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Oval : AbstrFigure,ISelectable,IMovable
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
            if (isSelected)
            {
                ShowSelection(g);
            }
        }

        public override bool IsSelected(Point point)
        {
            int semiMinorAxis = (int)(h/2);
            int semiMajorAxis= (int)(w/ 2);
            if (semiMinorAxis>semiMajorAxis)
            {
                var temp = semiMajorAxis;
                semiMajorAxis = semiMinorAxis;
                semiMinorAxis = semiMajorAxis;
            }
            Point center = new Point((int)(x + w / 2), (int)(y + h / 2));
            Point normalized = new Point(point.X - center.X,
                                         point.Y - center.Y);

            return ((double)(normalized.X * normalized.X)
                     / (semiMajorAxis * semiMajorAxis)) + ((double)(normalized.Y * normalized.Y) / (semiMinorAxis * semiMinorAxis))
                <= 1.0;
        }

        public override void ShowSelection(Graphics g)
        {
            base.ShowSelection(g);
        }

        public override void Move(Point a, Point b)
        {
            base.Move(a, b);
        }

    }
}
