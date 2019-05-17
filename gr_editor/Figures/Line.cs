using gr_editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Line:AbstrFigure,IMovable,ISelectable
    {
        public Line(Point a,Point b):base(a,b)
        {

        }

        

        public override void Draw(Graphics g, Pen pen)
        {

            g.DrawLine(pen, leftUpVert, rightBotVert);
        }

        public override bool IsSelected(Point point)
        {
            bool found = false;
            float x1 = leftUpVert.X - 10;
            float y1 = leftUpVert.Y ;
            float x2 = rightBotVert.X - 10;
            float y2 = rightBotVert.Y ;
            int i = 1;
            while ((i<=20)&&(!found))
            {
                //if ((point.X - x1) * (y2- y1) == (x2 - x1) * (point.Y - y1))
                if ((int)((point.X-x1)/(x2-x1))==(int)((point.Y-y1)/(y2-y1)))
                    return true;
                x1++;
                x2++;
               // y1++;
               // y2++;
                i++;
            }
            return false;
        }

        public override void ShowSelection(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(Color.LimeGreen);
            g.FillRectangle(solidBrush, leftUpVert.X-10, leftUpVert.Y - 10, 10, 10);
            g.FillRectangle(solidBrush, rightBotVert.X , rightBotVert.Y , 10, 10);
        }
    }
}
