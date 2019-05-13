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
using gr_editor.Interfaces;

namespace gr_editor
{
    public partial class Form1 : Form
    { 
	    Color color = Color.Black; 
        bool isPressed = false; 
        Graphics g; 
        Point leftUpVert;
        Point rightBotVert;
        FiguresList figures = new FiguresList();
        FiguresList undoList = new FiguresList();
        Bitmap bmp;
        bool isToolChosen=false;
        bool isSelectionToolChosen = false;
        String tool;
        bool isMoving = false;

        static void SelectFigure(ISelectable figure)
        {

        }

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            this.KeyPreview = true;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            
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
            if (isToolChosen)
            {
                SearchForFigure(e.Location);
                leftUpVert = e.Location;
                AbstrFigure rect = null;
                Type TestType = Type.GetType("gr_editor.Figures." + tool, false, false);
                if (TestType != null)
                {
                    System.Reflection.ConstructorInfo ci = TestType.GetConstructor(new Type[] { typeof(Point), typeof(Point) });
                    rect = (AbstrFigure)ci.Invoke(new object[] { leftUpVert, leftUpVert });
                }
                figures.Add(rect);
                isPressed = true;
            }else if ((isSelectionToolChosen)&&(figures.Count() > 0) )
            {
               Point point=e.Location;
                SearchForFigure(point);
            }
        }

        private void SearchForFigure(Point point)//проходим по списку фигур, ищем ту, в которой находитс точка клика
        {
            for(int i=figures.list.Count-1;i>=0;i--)
            {
                if(figures.list[i] is ISelectable)
                {
                    Type type=figures.list[i].GetType();// temp = new figures.list[i].GetType();
                    if ((figures.list[i].IsSelected(point))&&(!isToolChosen)&&(!figures.list[i].isSelected))
                    {
                        figures.list[i].isSelected = true;
                        Console.WriteLine(i + "Is selected");
                    }else if((figures.list[i].isSelected)&& (figures.list[i].IsSelected(point))&&(figures.list[i] is IMovable))
                    {
                        isMoving = true;
                        leftUpVert = point;
                    }else if ((figures.list[i].isSelected)||((isToolChosen)&&(figures.list[i].isSelected)))
                    {
                        figures.list[i].isSelected = false;
                    }
                    Draw();
                }
            }
            
        }

        private void OnPanelMouseReleased(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                undoList.Clear();
                isPressed = false;
            }else if (isMoving)
            {
                isMoving = false;
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void OnPanelMouseMove(object sender, MouseEventArgs e)
        {
           if(isPressed)
            {
                rightBotVert = e.Location;
                rightBotVert=CheckPosition(rightBotVert); 
                figures.list[figures.Count() - 1].Resize(CheckPosition(rightBotVert));
                Draw();
            }else if (isMoving)
            {
                bool found = false;
                int i = 0;
                while((!found)&&(i< figures.list.Count))
                {
                    if ((figures.list[i].isSelected))
                    {
                        //this.Cursor = Cursor.Cross;
                        Cursor.Current = Cursors.Cross;
                        rightBotVert = e.Location;
                        figures.list[i].Move(leftUpVert, rightBotVert);
                        Draw();
                        leftUpVert = rightBotVert;
                        found = true;
                    }
                    i++;
                }
            }
        }

        public void Draw()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen myPen = GetPen();
            foreach (var item in figures.list)
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
            if(undoList.Count()>0)
            {
                figures.Add(undoList.list[undoList.Count() - 1]);
                undoList.RemoveAt(undoList.Count() - 1);
            }
            Draw();
        }

        private void Undo()
        {
            pictureBox1.Refresh();
            if(figures.Count()>0)
            {
                undoList.Add(figures.list[figures.Count() - 1]);
                figures.RemoveAt(figures.Count() - 1);
                Draw();
            }
            
        }

       

        private Point CheckPosition(Point vertex)
        {
            if(isPressed)
            {
                if (vertex.X <= 0)
                {
                    vertex = new Point(5, vertex.Y);
                }
                else if (vertex.X >= pictureBox1.Width)
                {
                    vertex = new Point(pictureBox1.Width-5, vertex.Y);
                }
                else if (vertex.Y <= 0)
                {
                    vertex = new Point(vertex.X, 5);
                }
                else if (vertex.Y >= pictureBox1.Height)
                {
                    vertex = new Point(vertex.X, pictureBox1.Height-5);
                }
            }
            return vertex;
            
        }

        private void RectButtonClicked(object sender, EventArgs e)
        {
            tool = RectButton.Text;
            isToolChosen = true;
        }

        private void OvalButtonClicked(object sender, EventArgs e)
        {
            tool = OvalButton.Text;
            isToolChosen = true;
        }

        private void LineButtonClicked(object sender, EventArgs e)
        {
            tool = LineButton.Text;
            isToolChosen = true;
        }

        private void RhombusButtonClicked(object sender, EventArgs e)
        {
            tool = RhombusButton.Text;
            isToolChosen = true;

        }

        private void TriButtonClicked(object sender, EventArgs e)
        {
            tool = TriButton.Text;
            isToolChosen = true;

        }

        private void CircleButtonClicked(object sender, EventArgs e)
        {
            tool = StarButton.Text;
            isToolChosen = true;
        }

        private void StarButtonClicked(object sender, EventArgs e)
        {
            tool = StarButton.Text;
            isToolChosen = true;
        }

        private void selectTool_Click(object sender, EventArgs e)
        {
            isSelectionToolChosen = true;
            isToolChosen = false;
        }

        
    }

}
