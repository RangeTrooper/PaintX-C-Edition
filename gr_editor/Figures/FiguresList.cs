using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    [Serializable]
    class FiguresList
    {
        public List<AbstrFigure> list;

        public FiguresList()
        {
           list = new List<AbstrFigure>();
        }

        public void Add(AbstrFigure fig)
        {
            list.Add(fig);
        }

        public void Clear()
        {
            list.Clear();
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public int Count()
        {
            return list.Count;
        }
    }
}
