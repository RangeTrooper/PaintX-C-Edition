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
            SolidBrush solidBrush = new SolidBrush(Color.Azure);
            Point point1 = new Point((int)x, ((int)(y + h / 2)));
            Point point2 = new Point((int)(x + w / 3), ((int)(y + h / 3)));
            Point point3 = new Point((int)(x + w / 2), ((int)(y )));
            Point point4 = new Point((int)(x + 2 * w / 3), ((int)(y + h / 3)));
            Point point5 = new Point((int)(x + w), ((int)(y + h / 2)));
            Point point6 = new Point((int)(x + 2 * w / 3), ((int)(y + 2 * h / 3)));
            Point point7 = new Point((int)(x + w / 2), ((int)(y + h)));
            Point point8 = new Point((int)(x + w / 3), ((int)(y + 2 * h / 3)));
            Point[] triPoints = { point1, point2, point3, point4,point5,point6,point7,point8 };
            g.FillPolygon(solidBrush, triPoints);
            if (isSelected)
            {
                ShowSelection(g);
            }
        }

        public override bool IsSelected(Point point)
        {
            float prod1, prod2, prod3;
            prod1 = ((x - point.X) * (y + h / 3 - (y + h / 2)) - (x + w / 3 - x) * (y + h / 2 - point.Y));
            prod2 = ((x + w / 3 - point.X) * (y + 2 * h / 3 - (y + h / 3)) - (x + w/3 - (x + w / 3)) * (y + h / 3 - point.Y));
            prod3 = ((x + w / 3 - point.X) * (y + h / 2 - (y + 2 * h / 3)) - (x - (x + w / 3)) * (y + 2 * h / 3 - point.Y));
            
            if (((prod1 > 0) && (prod2 > 0) && (prod3 > 0)) || ((prod1 < 0) && (prod2 < 0) && (prod3 < 0)))
            {
               
                    return true;
            }else
            {
                prod1 = ((x + w / 3 - point.X) * (y - (y + h / 3)) - (x + w / 2 - (x + w / 3)) * (y + h / 3 - point.Y));
                prod2 = ((x + w / 2 - point.X) * (y + h / 3 - y) - (x + 2 * w / 3 - (x + w / 2)) * (y - point.Y));
                prod3 = ((x + 2 * w / 3 - point.X) * (y + h / 3 - (y + h / 3)) - (x + w / 3 - (x + 2 * w / 3)) * (y + h / 3 - point.Y));

                if (((prod1 > 0) && (prod2 > 0) && (prod3 > 0)) || ((prod1 < 0) && (prod2 < 0) && (prod3 < 0)))
                    return true;
                else
                {
                    prod1 = ((x +2* w / 3 - point.X) * (y+h/2 - (y + h / 3)) - (x + w  - (x + 2 * w / 3)) * (y + h / 3 - point.Y));
                    prod2 = ((x + w  - point.X) * (y + 2*h / 3 - (y+h/2)) - (x + 2 * w / 3 - (x + w)) * (y+h/2 - point.Y));
                    prod3 = ((x + 2 * w / 3 - point.X) * (y + h / 3 - (y + 2*h / 3)) - (x + 2 * w / 3 - (x + 2 * w / 3)) * (y + 2*h / 3 - point.Y));

                    if (((prod1 > 0) && (prod2 > 0) && (prod3 > 0)) || ((prod1 < 0) && (prod2 < 0) && (prod3 < 0)))
                        return true;
                    else
                    {
                        prod1 = ((x + 2 * w / 3 - point.X) * (y + h  - (y + 2*h / 3)) - (x + w/2 - (x + 2 * w / 3)) * (y + 2*h / 3 - point.Y));
                        prod2 = ((x + w/2 - point.X) * (y + 2 * h / 3 - (y + h )) - (x +  w / 3 - (x + w/2)) * (y + h  - point.Y));
                        prod3 = ((x +  w / 3 - point.X) * (y + 2*h / 3 - (y + 2 * h / 3)) - (x + 2 * w / 3 - (x +  w / 3)) * (y + 2 * h / 3 - point.Y));

                        if (((prod1 > 0) && (prod2 > 0) && (prod3 > 0)) || ((prod1 < 0) && (prod2 < 0) && (prod3 < 0)))
                            return true;
                        else
                        {
                            if ((point.X > x+w/3) && (point.Y > y+h/3) && (point.X < x+2*w/3) && (point.Y < y+2*h/3))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public override void ShowSelection(Graphics g)
        {
            base.ShowSelection(g);
        }
    }
}
