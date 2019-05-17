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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace gr_editor
{
    public partial class Form1 : Form
    {
        FiguresFactory Factory;
	    Color color = Color.Black; 
        bool isPressed = false; 
        Graphics g; 
        Point leftUpVert;
        Point rightBotVert;
        FiguresList figures = FiguresList.GetInstance();
        FiguresList figures2 = FiguresList.GetInstance();
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
                AbstrFigure figure = Factory.FactoryMethod(leftUpVert, leftUpVert);
                this.figures.Add(figure);
                isPressed = true;
            }else if ((isSelectionToolChosen)&&(figures.Count() > 0) )
            {
               Point point=e.Location;
                SearchForFigure(point);
            }
        }

        private void SearchForFigure(Point point)//проходим по списку фигур, ищем ту, в которой находитс точка клика
        {
            bool found = false;
            int i = figures.list.Count - 1;
            while ((i>=0)&&(!found))
            {
                if(figures.list[i] is ISelectable)
                {
                   
                    if ((figures.list[i].IsSelected(point))&&(!isToolChosen)&&(!figures.list[i].isSelected))
                    {
                        for (int j = i - 1; j >= 0; j--)
                            figures.list[j].isSelected = false;
                        found = true;
                        figures.list[i].isSelected = true;
                        Console.WriteLine(i + "Is selected");
                    }else if((figures.list[i].isSelected)&& (figures.list[i].IsSelected(point))&&(figures.list[i] is IMovable))
                    {
                        found = true;
                        isMoving = true;
                        leftUpVert = point;
                    }else if ((figures.list[i].isSelected)||((isToolChosen)&&(figures.list[i].isSelected)))
                    {
                        figures.list[i].isSelected = false;
                    }
                    Draw();
                    
                }
                i--;
            }
            
        }

        private void OnPanelMouseReleased(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                figures.undoList.Clear();
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
                figures.list[figures.Count() - 1].Resize((rightBotVert));
                Draw();
            }else if (isMoving)
            {
                bool found = false;
                int i = 0;
                while((!found)&&(i< figures.list.Count))
                {
                    if ((figures.list[i].isSelected))
                    {
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
            if(figures.undoList.Count()>0)
            {
                figures.Add(figures.undoList[figures.undoList.Count() - 1]);
                figures.undoList.RemoveAt(figures.undoList.Count() - 1);
            }
            Draw();
        }

        private void Undo()
        {
            pictureBox1.Refresh();
            if(figures.Count()>0)
            {
               figures.undoList.Add(figures.list[figures.Count() - 1]);
                figures.RemoveAt(figures.Count() - 1);
                Draw();
            }
            
        }

        private void Deserialize()
        {
            if (!System.IO.File.Exists("figures.txt"))
            {
                MessageBox.Show("Не был найден файл figures.txt", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw new NotImplementedException();
            }
            StreamReader f = new StreamReader("figures.txt");
            figures.list.Clear();
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                string[] data = s.Split(new char[] { ',' });
                try
                {
                   
                    float x = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
                    float y = float.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat);
                    float w = float.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat);
                    float h = float.Parse(data[4], CultureInfo.InvariantCulture.NumberFormat);
                    Point a = new Point((int)x,(int) y);
                    Point b = new Point((int)w, (int)h);
                    String type = data[0];
                    switch (type)
                    {
                        case "Rect":
                            Factory = new CreateRect();
                            break;
                        case "Oval":
                            Factory = new CreateOval();
                            break;
                        case "Line":
                            Factory = new CreateLine();
                            break;
                        case "Triangle":
                            Factory = new CreateTriangle();
                            break;
                        case "Rhombus":
                            Factory = new CreateRhombus();
                            break;
                        case "Star":
                            Factory = new CreateStar();
                            break;
                        default:
                            Factory = null;
                            break;
                    }
                    AbstrFigure figure = Factory.FactoryMethod(a, b);
                    figures.list.Add(figure);
                }
                catch
                {
                    
                }
            }
            f.Close();
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

        public void Serialize()
        {
            StreamWriter f = new StreamWriter("figures.txt");
            foreach (AbstrFigure fig in figures.list)
            {
                String type = fig.GetType().ToString().Substring(18);
                f.WriteLine(type + "," + fig.leftUpVert.X.ToString() + "," + fig.leftUpVert.Y.ToString() + "," + fig.rightBotVert.X.ToString() + "," + fig.rightBotVert.Y.ToString() + ",");
            }
            f.Close();
        }

        private void RectButtonClicked(object sender, EventArgs e)
        {
            tool = RectButton.Text;
            Factory = new CreateRect();
            isToolChosen = true;
        }

        private void OvalButtonClicked(object sender, EventArgs e)
        {
            tool = OvalButton.Text;
            Factory = new CreateOval();
            isToolChosen = true;
        }

        private void LineButtonClicked(object sender, EventArgs e)
        {
            tool = LineButton.Text;
            Factory = new CreateLine();
            isToolChosen = true;
        }

        private void RhombusButtonClicked(object sender, EventArgs e)
        {
            tool = RhombusButton.Text;
            Factory = new CreateRhombus();
            isToolChosen = true;

        }

        private void TriButtonClicked(object sender, EventArgs e)
        {
            tool = TriButton.Text;
            Factory = new CreateTriangle();
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
            Factory = new CreateStar();
            isToolChosen = true;
        }

        private void selectTool_Click(object sender, EventArgs e)
        {
            isSelectionToolChosen = true;
            isToolChosen = false;
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            
            Serialize();
        }

        private void LoadButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Deserialize();
                Draw();
            }
            catch 
            {
               
            }
        }
    }

}
