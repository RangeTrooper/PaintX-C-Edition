using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gr_editor.Figures;
using System.Drawing;
using System.Reflection;
//using Rect;

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
            Assembly asm = Assembly.Load("Rect");
            Type t = asm.GetType("Rect.Rect");
            foreach (Type type in asm.GetTypes())
            {
                Console.WriteLine(type.FullName.ToString());
            }
            //AbstrFigure fig = Activator.CreateInstance(t, new Object[] { a, b }) as AbstrFigure;
            return Activator.CreateInstance(t,new Object[] { a, b }) as AbstrFigure;
            //return (AbstrFigure)asm.CreateInstance("Rect");
        }
    }

    class CreateOval: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            Assembly asm = Assembly.Load("Oval");
            Type t = asm.GetType("Oval.Oval");

            return Activator.CreateInstance(t, new Object[] { a, b }) as AbstrFigure;
        }
    }

    class CreateRhombus: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            Assembly asm = Assembly.Load("Rhombus");
            Type t = asm.GetType("Rhombus.Rhombus");

            return Activator.CreateInstance(t, new Object[] { a, b }) as AbstrFigure;
        }
    }

    class CreateLine: FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            Assembly asm = Assembly.Load("Line");
            Type t = asm.GetType("Line.Line");

            return Activator.CreateInstance(t, new Object[] { a, b }) as AbstrFigure;
        }
    }

    class CreateTriangle : FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            Assembly asm = Assembly.Load("Triangle");
            Type t = asm.GetType("Triangle.Triangle");

            return Activator.CreateInstance(t, new Object[] { a, b }) as AbstrFigure;
        }
    }
    
    class CreateStar : FiguresFactory
    {
        public override AbstrFigure FactoryMethod(Point a, Point b)
        {
            Assembly asm = Assembly.Load("Star");
            Type t = asm.GetType("Star.Star");

            return Activator.CreateInstance(t, new Object[] { a, b }) as AbstrFigure;
        }
    }
}
