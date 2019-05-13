using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gr_editor.Interfaces;
using static System.Math;

namespace gr_editor
{
    public abstract class AbstrFigure
    {

        public Graphics gc;
        public Point leftUpVert;
        public Point rightBotVert;
        public Pen myPen;
        public float x, y, w, h;
        public bool isSelected;

        public AbstrFigure(Point a,Point b)
        {
           // gc = GC;
           // myPen = pen;
            leftUpVert = a;
            rightBotVert = b;
            SetDimensions(leftUpVert, rightBotVert);

            //сюда можно добавить процедуру отрисовки, то есть вызов метода этого же класса
          //  Draw(gc);
        }
         public AbstrFigure()
        {

        }
        //public virtual void Draw(Graphics G,Pen pen,float x,float y,float w, float h)
        public virtual void Draw(Graphics g,Pen pen)
        {
           
        }
        public virtual void Clear()
        {

        }

        public void SetDimensions(Point a,Point b)
        {
            if (b.X > a.X)
            {
                if (b.Y > a.Y)
                {
                    x = a.X;
                    y = a.Y;
                    w = b.X - a.X;
                    h = b.Y - a.Y;
                }
                else
                {
                    x = a.X;
                    y = b.Y;
                    w = b.X - a.X;
                    h = a.Y - b.Y;
                }
            }
            else
            {
                if (b.Y < a.Y)
                {
                    x = b.X;
                    y = b.Y;
                    w = a.X - b.X;
                    h = a.Y - b.Y;
                }
                else
                {
                    x = b.X;
                    y = a.Y;
                    w = a.X - b.X;
                    h = b.Y - a.Y;
                }
            }
        }

        

        public void Resize(Point rbv)
        {
            rightBotVert = rbv;
            SetDimensions(leftUpVert, rightBotVert);
        }

        public virtual bool IsSelected(Point point)
        {
            return true;
        }

        public virtual void ShowSelection(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(Color.LimeGreen);
            g.FillRectangle(solidBrush, x - 10, y - 10, 10, 10);
            g.FillRectangle(solidBrush, x + w, y - 10, 10, 10);
            g.FillRectangle(solidBrush, x - 10, y + h, 10, 10);
            g.FillRectangle(solidBrush, x + w, y + h, 10, 10);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, x, y, w, h);
        }

        public virtual void Move(Point a, Point b)
        {
            float dx = Abs(b.X - a.X);
            float dy = Abs(b.Y - a.Y);
            if (b.X > a.X)
            {
                if (b.Y > a.Y)
                {
                    x = x + dx;
                    y = y + dy;
                }
                else
                {
                    x = x+dx;
                    y = y-dy;
                }
            }
            else
            {
                if (b.Y < a.Y)
                {
                    x = x-dx;
                    y = y-dy;
                }
                else
                {
                    x = x-dx;
                    y = y+dy;
                }
            }
           // SetDimensions(new Point((int)(x + dx), (int)(y + dy)), new Point((int)(x +w+ dx), (int)(y +h+ dy)));
        }
    }
}
