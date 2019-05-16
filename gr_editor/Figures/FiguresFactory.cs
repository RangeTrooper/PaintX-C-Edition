using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gr_editor.Figures;
using System.Drawing;

namespace gr_editor.Figures
{
    abstract class FiguresFactory
    {
        public abstract AbstrFigure FactoryMethod(Point a,Point b);
    }

    class CreateRect: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            return new Rect(a,b);
        }
    }

    class CreateOval: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
           return new Oval(a,b);
        }
    }

    class CreateRhombus: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            return new Rhombus(a,b);
        }
    }

    class CreateLine: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            return new Line(a,b);
        }
    }

    class CreateTriangle : FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            return new Triangle(a,b);
        }
    }
    
    class CreateStar : FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            return new Star(a,b);
        }
    }
}
