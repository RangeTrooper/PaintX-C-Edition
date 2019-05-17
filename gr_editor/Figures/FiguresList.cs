using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Figures
{
    [Serializable]
    public class FiguresList
    {
        private static FiguresList instance ;

      
        public List<AbstrFigure> list;
        public List<AbstrFigure> undoList;
        private FiguresList()
        {
           list = new List<AbstrFigure>();
           undoList = new List<AbstrFigure>();
        }


        public static FiguresList GetInstance()
        {
          

            // Если экземпляр еще не инициализирован - выполняем инициализацию. 
            // Иначе возвращаем имеющийся экземпляр.
            if (instance == null)
            {
                
                    if (instance == null)
                    {
                        instance = new FiguresList();
                    }
                
            }

            return instance;
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
