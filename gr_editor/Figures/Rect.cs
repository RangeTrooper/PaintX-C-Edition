using gr_editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Rect : AbstrFigure,ISelectable,IMovable
    {

        public Rect(Point a,Point b):base(a,b)
        {  

        }
        public Rect():base()
        {

        }


        public override void Draw(Graphics g,Pen pen)
        {
            g.DrawRectangle(pen,x,y,w,h);
            SolidBrush solidBrush = new SolidBrush( Color.Azure);
            g.FillRectangle(solidBrush, x, y, w, h);
            if (isSelected)
            {
                ShowSelection(g);
            }
        }

        public override void Clear()
        {
            Pen pen = new Pen(Color.White,5);
            gc.DrawRectangle(pen, x, y, w, h);
            pen.Dispose();
        }

        public override  bool IsSelected(Point point)
        {
            if ((point.X > x) && (point.Y > y) && (point.X < x + w) && (point.Y < y + h))
                return true;
            else
                return false;
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
