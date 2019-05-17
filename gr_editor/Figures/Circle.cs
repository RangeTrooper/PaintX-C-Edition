using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Math;

namespace gr_editor.Figures
{
    class Circle:AbstrFigure
    {
        public Circle(Point a,Point b):base(a,b)
        {

        }

       

        public override void Draw(Graphics g, Pen pen)
        {
            
            //g.DrawEllipse(pen, x, y, w, w);
            if (rightBotVert.X>leftUpVert.X)
            {
                g.DrawEllipse(pen, x, y, h, h);
            }else if(rightBotVert.Y<leftUpVert.Y)
            {
                g.DrawEllipse(pen, x, y, h, h);
            }else if(rightBotVert.X < leftUpVert.X)
            {
                g.DrawEllipse(pen, x, y, h, h);
            }
            
        }
    }
}
