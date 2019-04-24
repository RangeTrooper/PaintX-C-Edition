using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    class Rect : AbstrFigure
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
        }

        public override void Clear()
        {
            Pen pen = new Pen(Color.White,5);
            gc.DrawRectangle(pen, x, y, w, h);
            pen.Dispose();
        }
    }
}
