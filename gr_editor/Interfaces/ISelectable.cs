using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr_editor.Interfaces
{
    public interface ISelectable
    {
       bool IsSelected(Point point);
       void ShowSelection(Graphics g);
    }
}
