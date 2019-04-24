using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gr_editor.Figures;

namespace gr_editor
{
    public partial class Form1 : Form
    { 
	    Color color = Color.Black; 
        bool isPressed = false; 
        Graphics g; 
        Point leftUpVert;
        Point rightBotVert;
        List<AbstrFigure> figures = new List<AbstrFigure>();
        List<AbstrFigure> undoList = new List<AbstrFigure>();
        Bitmap bmp;
        AbstrFigure Tool;
        Type type;
        bool flag;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            this.KeyPreview = true;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rect rect = new Rect();
            Oval oval = new Oval();
            ToolBox.Items.Add(rect);
            ToolBox.Items.Add(oval);
            flag = false;
        }



        private Pen GetPen()
        {
            return new Pen(color, 5);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnPanelMousePressed(object sender, MouseEventArgs e) 
        {
            leftUpVert = e.Location;
            Rect rect = new Rect
            {
                rightBotVert = leftUpVert,
                leftUpVert = leftUpVert
            };
            figures.Add(rect);
            isPressed = true;
        }

        private void OnPanelMouseReleased(object sender, MouseEventArgs e)
        {
            bmp.Save("D:\\Лабы_4сем\\ООТПиСП\\gr_editor\\gr_editor\\my.bmp");
            undoList.Clear();
            isPressed = false;
        }

        private void OnPanelMouseMove(object sender, MouseEventArgs e)
        {
           if(isPressed)
            {
                rightBotVert = e.Location;
                figures[figures.Count - 1].Resize(e.Location);
                Draw();
            }
        }

        public void Draw()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen myPen = GetPen();
            foreach (var item in figures)
            {
                item.Draw(g,myPen);
            }
            pictureBox1.Image = bmp;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
            }
            else if(e.Control&& e.KeyCode==Keys.Y)
            {
                Redo();
            }
        }

        private void Redo()
        {
            if(undoList.Count>0)
            {
                figures.Add(undoList[undoList.Count - 1]);
                undoList.RemoveAt(undoList.Count - 1);
            }
            Draw();
        }

        private void Undo()
        {
            pictureBox1.Refresh();
            if(figures.Count>0)
            {
                undoList.Add(figures[figures.Count - 1]);
                figures.RemoveAt(figures.Count - 1);
                Draw();
            }
            
        }

        private void ToolChosen(object sender, EventArgs e)
        {
            int tool= ToolBox.SelectedIndex;
            type= ToolBox.SelectedItem.GetType();
            switch(tool)
            {
                case 0:
                    Tool = new Rect();
                    break;
                case 2:
                    Tool = new Oval();
                    break;
            }
        }
    }
}
