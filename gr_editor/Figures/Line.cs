using gr_editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

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
            if (isSelected)
            {
                ShowSelection(g);
            }
        }

        public override bool IsSelected(Point point)
        {
            bool result = false;
            float x1 = leftUpVert.X;
            float y1 = leftUpVert.Y ;
            float x2 = rightBotVert.X;
            float y2 = rightBotVert.Y ;
            int i = 1;
            float Y = point.Y-15;
            try
            {
                result= (((point.X <= leftUpVert.X && point.X >= rightBotVert.X) || (point.X >= leftUpVert.X && point.X <= rightBotVert.X)) &&
                   ((point.X <= leftUpVert.Y && point.Y >= rightBotVert.Y) || (point.Y >= leftUpVert.Y && point.Y <= rightBotVert.Y)) &&
                (Math.Abs(((leftUpVert.X - point.X) / (leftUpVert.Y - point.Y)) - ((leftUpVert.X - rightBotVert.X) / (leftUpVert.Y - rightBotVert.Y))) < 2));
                return result;
            }
            catch
            {
                return false;
            }
        }

        public override void ShowSelection(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(Color.LimeGreen);
            g.FillRectangle(solidBrush, leftUpVert.X-10, leftUpVert.Y - 10, 10, 10);
            g.FillRectangle(solidBrush, rightBotVert.X , rightBotVert.Y , 10, 10);
        }

        public override void Move(Point a, Point b)
        {
            int dx = Abs(b.X - a.X);
            int dy = Abs(b.Y - a.Y);
            if (b.X > a.X)
            {
                if (b.Y > a.Y)
                {
                    leftUpVert.X += dx;
                    leftUpVert.Y += dy;
                    rightBotVert.X += dx;
                    rightBotVert.Y += dy;
                }
                else
                {
                    leftUpVert.X += dx; 
                    leftUpVert.Y -= dy;
                    rightBotVert.X += dx;
                    rightBotVert.Y -= dy;
                }
            }
            else
            {
                if (b.Y < a.Y)
                {
                    leftUpVert.X -= dx;
                    leftUpVert.Y -= dy;
                    rightBotVert.X -= dx;
                    rightBotVert.Y -= dy;
                }
                else
                {
                    leftUpVert.X -= dx;
                    leftUpVert.Y += dy;
                    rightBotVert.X -= dx;
                    rightBotVert.Y += dy;
                }
            }
        }
    }
}
