using System.Collections.Generic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static lab7.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.Remoting.Messaging;
using System.IO;
using static System.Collections.Specialized.BitVector32;
using lab7;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace lab7
{
    public partial class Form1 : Form
    {
        SavedData savedData = new SavedData();
        SaverLoader loader = new SaverLoader();
        private List<Figure> figures = new List<Figure>();
        public int objectSize = 30;
        private bool Cntrl;

        Color color = Color.Black;
        Color red = Color.Red;
        Color green = Color.Green;
        Color blue = Color.Blue;
        Color black = Color.Black;
        int colorIndex = 0;

        int selectedFigure = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Figure figure in figures)
            {
                figure.SelfDraw(e.Graphics); // Метод круга для отрисовки 
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (!Cntrl)
            {
                foreach (Figure figure in figures) // снятие выделения со всех объектов
                {
                    figure.setCondition(false);
                }

                switch (selectedFigure)
                {
                    case 0:
                        Circle newcircle = new Circle(e.X, e.Y, objectSize, color);
                        newcircle.setCondition(false);
                        figures.Add(newcircle);
                        break;
                    case 1:
                        Square newsquare = new Square(e.X, e.Y, objectSize, color);
                        newsquare.setCondition(false);
                        figures.Add((newsquare));
                        break;
                    case 2:
                        Triangle newtriangle = new Triangle(e.X, e.Y, objectSize, color);
                        newtriangle.setCondition(false);
                        figures.Add((newtriangle));
                        break;
                    case 3:
                        Line newline = new Line(e.X, e.Y, objectSize, color);
                        newline.setCondition(false);
                        figures.Add((newline));
                        break;
                }
                Refresh();
            }
            else if (Cntrl) // Выделение кругов, если зажат cntrl
            {
                foreach (Figure figure in figures)
                {
                    if (figure.MouseCheck(e))
                    {
                        figure.setCondition(true);
                        break;
                    }
                }
                Refresh();
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            objectSize = trackBar1.Value;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            checkBox_Cntrl.Checked = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                checkBox_Cntrl.Checked = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DelFigures();
            }
            else if (e.KeyCode == Keys.W)
            {
                foreach (Figure figure in figures)
                {
                    figure.MoveUp(this);
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.S)
            {
                foreach (Figure figure in figures)
                {
                    figure.MoveDown(this);
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.A)
            {
                foreach (Figure figure in figures)
                {
                    figure.MoveLeft(this);
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.D)
            {
                foreach (Figure figure in figures)
                {
                    figure.MoveRight(this);
                }
                Refresh();
            }

            else if (e.KeyCode == Keys.Oemplus)
            {
                foreach (Figure figure in figures)
                {
                    figure.DoBigger();
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                foreach (Figure figure in figures)
                {
                    figure.DoSmaller();
                }
                Refresh();
            }
        }

        private void checkBox_Cntrl_CheckedChanged(object sender, EventArgs e)
        {
            Cntrl = checkBox_Cntrl.Checked;
            foreach (Figure figure in figures)
            {
                figure.Cntrled(Cntrl);
            }
        }

        private void btn_doBigger_Click(object sender, EventArgs e)
        {
            DoBigger();
        }

        private void btn_doSmaller_Click(object sender, EventArgs e)
        {
            DoSmaller();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DelFigures();
        }

        public virtual void DoBigger()
        {
            foreach (Figure figure in figures)
            {
                if (figure.selected && figure.rad <= 95)
                {
                    figure.rad += 5;
                }
            }
            Refresh();
        }

        public virtual void DoSmaller()
        {
            foreach (Figure figure in figures)
            {
                if (figure.selected && figure.rad > 10)
                {
                    figure.rad -= 5;
                }
            }
            Refresh();
        }

        void DelFigures()
        {
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].selected == true)
                {
                    figures.Remove(figures[i]);
                    i--;
                }
            }
            Refresh();
        }

        private void btn_Select_Click(object sender, EventArgs e) // выделения всех объектов
        {
            foreach (Figure figure in figures)
            {
                figure.setCondition(true);
            }
            Refresh();
        }

        private void btn_unSelect_Click(object sender, EventArgs e) // снятие выделения 
        {
            foreach (Figure figure in figures)
            {
                figure.setCondition(false);
            }
            Refresh();
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            if (colorIndex < 3)
                colorIndex++;
            else
                colorIndex = 0;
            switch (colorIndex)
            {
                case 0:
                    color = red;
                    break;
                case 1:
                    color = green;
                    break;
                case 2:
                    color = blue;
                    break;
                case 3:
                    color = black;
                    break;
            }

            btn_Color.BackColor = color;
            foreach (Figure figure in figures)
            {
                if (figure.selected)
                    figure.colorF = color;
            }
        }

        private void btn_circle_Click(object sender, EventArgs e)
        {
            selectedFigure = 0;
        }

        private void btn_square_Click(object sender, EventArgs e)
        {
            selectedFigure = 1;
        }

        private void btn_triangle_Click(object sender, EventArgs e)
        {
            selectedFigure = 2;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            selectedFigure = 3;
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S || e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                e.IsInputKey = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            KeyPreview = true;
        }

        void Group()
        {
            Group newgroup = new Group();
            foreach (Figure figure in figures)
            {
                if (figure.selected)
                {
                    newgroup.Add(figure);
                }
            }
            newgroup.inGroup = true;
            foreach (Figure figure in newgroup.childrens)
            {
                figures.Remove(figure);
            }
            figures.Add(newgroup);
            Refresh();
        }
        private void UnGroup()
        {
            List<Figure> selectedFigures = new List<Figure>();

            // Находим выбранные фигуры в списке всех фигур
            foreach (Figure figure in figures)
            {
                if (figure.selected)
                {
                    selectedFigures.Add(figure);
                }
            }

            // Удаляем выбранные фигуры из списка группы и добавляем их в общий список фигур
            foreach (Figure figure in selectedFigures)
            {
                if (figure.inGroup && figure is Group group)
                {
                    figures.Remove(group);
                    figures.AddRange(group.childrens);
                }
            }

            foreach (Figure figure in selectedFigures)
            {
                if (figure.inGroup && figure is Group group)
                {
                    figures.Remove(group);
                    figures.AddRange(group.childrens);

                    // Изменить цвет разгруппированной фигуры на черный
                    foreach (Figure childFigure in group.childrens)
                    {
                        childFigure.colorF = Color.Black;
                    }
                }
            }

            Refresh();
        }

        private void saveMe()
        {
            foreach (Figure figure in figures)
            {
                figure.SelfSave(savedData);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveMe();
            File.Delete("D:\\figures.txt");
            loader.Save(savedData, "D:\\figures.txt");
            savedData = new SavedData();
        }

        Figure read(StreamReader sr)
        {
            string line = sr.ReadLine();
            string[] data = line.Split(';');
            switch (data[0])
            {
                case "Group":
                    {
                        int count = int.Parse(data[1]);
                        Group newfigure = new Group();
                        for (int i = 0; i < count; i++)
                        {
                            newfigure.Add(read(sr));
                        }
                        return newfigure;
                    }
                default:
                    {
                        int x = int.Parse(data[2]);
                        int y = int.Parse(data[3]);
                        int rad = int.Parse(data[4]);
                        bool selected = bool.Parse(data[5]);
                        Color color = Color.FromArgb(int.Parse(data[1]));
                        switch (data[0])
                        {
                            case "Circle":
                                {
                                    Circle newfigure = new Circle(x, y, rad, color);
                                    newfigure.setCondition(selected);
                                    return newfigure;
                                }
                            case "Square":
                                {
                                    Square newfigure = new Square(x, y, rad, color);
                                    newfigure.setCondition(selected);
                                    return newfigure;
                                }
                            case "Triangle":
                                {
                                    Triangle newfigure = new Triangle(x, y, rad, color);
                                    newfigure.setCondition(selected);
                                    return newfigure;
                                }
                            case "Line":
                                {
                                    Line newfigure = new Line(x, y, rad, color);
                                    newfigure.setCondition(selected);
                                    return newfigure;
                                }
                        }
                        return null;
                    }
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            foreach (Figure figure in figures)
            {
                figure.setCondition(true);
            }
            DelFigures();

            StreamReader sr = new StreamReader("D:\\figures.txt");

            while (!sr.EndOfStream)
            {
                figures.Add(read(sr));
            }
            sr.Close();
            Refresh();
        }

        private void btn_group_Click(object sender, EventArgs e)
        {
            Group();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnGroup();
        }
    }
}

public class Figure
{
    public List<Figure> childrens;
    public Point coords;
    public int rad;
    public bool selected = false;
    public bool fcntrl = false;
    public bool inGroup = false;

    public Color colorT = Color.Red;
    public Color colorF = Color.Yellow;
    public virtual void Cntrled(bool pressed)
    {
        fcntrl = pressed;
    }

    public virtual void setCondition(bool cond) // метод переключения выделения
    {
        selected = cond;
    }
    public virtual void SelfDraw(Graphics g) // Метод для отрисовки самого себя
    {

    }
    public virtual void SelfSave(SavedData savedData) // Метод для сохранения самого себя
    {
        StringBuilder line = new StringBuilder();
        line.Append(ToString()).Append(";");
        line.Append(colorF.ToArgb()).Append(";");
        line.Append(coords.X.ToString()).Append(";");
        line.Append(coords.Y.ToString()).Append(";");
        line.Append(rad.ToString()).Append(";");
        line.Append(selected.ToString()).Append(";");
        savedData.linesToWrite.Add(line.ToString());
    }
    public virtual bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
    {
        return false;
    }

    public virtual void DoSmaller()
    {
        if (selected && rad > 10)
        {
            rad -= 5;
        }
    }
    public virtual void DoBigger()
    {
        if (selected && rad <= 95)
        {
            rad += 5;
        }
    }

    public virtual bool CanMoveUp(Form form)
    {
        if (((coords.Y - rad) > 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool CanMoveDown(Form form)
    {
        if ((coords.Y + rad) < (int)form.ClientSize.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool CanMoveLeft(Form form)
    {
        if ((coords.X - rad) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool CanMoveRight(Form form)
    {
        if ((coords.X + rad) < (int)form.ClientSize.Width)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void MoveUp(Form form)
    {
        if (selected && CanMoveUp(form))
        {
            coords.Y -= 1;
        }
    }
    public virtual void MoveDown(Form form)
    {
        if (selected && CanMoveDown(form))
        {
            coords.Y += 1;
        }
    }
    public virtual void MoveLeft(Form form)
    {
        if (selected && CanMoveLeft(form))
        {
            coords.X -= 1;
        }
    }

    public virtual void MoveRight(Form form)
    {
        if (selected && CanMoveRight(form))
        {
            coords.X += 1;
        }
    }

}
public class Circle : Figure// класс круга
{
    public Circle(int x, int y, int radius, Color color) // конструктор по умолчанию
    {
        coords.X = x;
        coords.Y = y;
        rad = radius;
        colorF = color;
    }
    public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
    {
        if (selected == true)
            g.DrawEllipse(new Pen(colorT, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);
        else
            g.DrawEllipse(new Pen(colorF, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);
    }
    public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
    {
        if (fcntrl)
        {
            if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
            {
                setCondition(true);
                return true;
            }
        }
        return false;
    }

}

public class Square : Figure // класс квадрата
{
    public Square(int x, int y, int radius, Color color) // конструктор по умолчанию
    {
        coords.X = x;
        coords.Y = y;
        rad = radius;
        colorF = color;
    }
    public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
    {
        if (selected == true)
            g.DrawRectangle(new Pen(colorT, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);
        else
            g.DrawRectangle(new Pen(colorF, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);

    }
    public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
    {
        if (fcntrl)
        {
            if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
            {
                setCondition(true);
                return true;
            }
        }
        return false;
    }
}

public class Triangle : Figure // класс треугольника
{
    public Triangle(int x, int y, int radius, Color color) // конструктор по умолчанию
    {
        coords.X = x;
        coords.Y = y;
        rad = radius;
        colorF = color;
    }
    public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
    {
        Point point1 = new Point(coords.X, coords.Y - rad);
        Point point2 = new Point(coords.X + rad, coords.Y + rad);
        Point point3 = new Point(coords.X - rad, coords.Y + rad);
        Point[] curvePoints = { point1, point2, point3 };

        if (selected == true)
            g.DrawPolygon(new Pen(colorT, 3), curvePoints);
        else
            g.DrawPolygon(new Pen(colorF, 3), curvePoints);
    }
    public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
    {
        if (fcntrl)
        {
            if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
            {
                setCondition(true);
                return true;
            }
        }
        return false;
    }
}

public class Line : Figure // класс отрезка
{
    public Line(int x, int y, int radius, Color color) // конструктор по умолчанию
    {
        coords.X = x;
        coords.Y = y;
        rad = radius;
        colorF = color;
    }
    public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
    {
        Point point1 = new Point(coords.X - rad, coords.Y);
        Point point2 = new Point(coords.X + rad, coords.Y);
        Point[] curvePoints = { point1, point2 };

        if (selected == true)
            g.DrawPolygon(new Pen(colorT, 3), curvePoints);
        else
            g.DrawPolygon(new Pen(colorF, 3), curvePoints);
    }
    public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
    {
        if (fcntrl)
        {
            if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
            {
                setCondition(true);
                return true;
            }
        }
        return false;
    }
}


class Group : Figure
{
    public List<Figure> childrens = new List<Figure>();
    public Group()
    {
    }
    public void Add(Figure component)
    {
        component.colorF = Color.Blue;
        component.setCondition(false);
        childrens.Add(component);
    }

    public override void Cntrled(bool pressed)
    {
        foreach (Figure component in childrens)
        {
            component.fcntrl = pressed;
        }
        fcntrl = pressed;
    }

    public override void setCondition(bool cond)
    {
        foreach (Figure child in childrens)
        {
            child.setCondition(cond);
        }
        selected = cond;
    }

    public override void SelfDraw(Graphics g)
    {
        foreach (Figure child in childrens)
        {
            child.SelfDraw(g);
        }
    }
    public override void SelfSave(SavedData savedData)
    {
        StringBuilder tmp = new StringBuilder();
        tmp.Append(ToString()).Append(";");
        tmp.Append(childrens.Count().ToString()).Append(";");
        savedData.linesToWrite.Add(tmp.ToString());
        foreach (Figure figure in childrens)
        {
            figure.SelfSave(savedData);
        }
    }

    public override bool MouseCheck(MouseEventArgs e)
    {
        foreach (Figure child in childrens)
        {
            if (child.MouseCheck(e))
            {
                return true;
            }
        }
        return false;
    }

    public override void DoSmaller()
    {
        foreach (Figure child in childrens)
        {
            child.DoSmaller();
        }
    }
    public override void DoBigger()
    {
        foreach (Figure child in childrens)
        {
            child.DoBigger();
        }
    }

    public override bool CanMoveUp(Form form)
    {
        foreach (Figure child in childrens)
        {
            if (!child.CanMoveUp(form))
            {
                return false;
            }
        }
        return true;
    }
    public override bool CanMoveDown(Form form)
    {
        foreach (Figure child in childrens)
        {
            if (!child.CanMoveDown(form))
            {
                return false;
            }
        }
        return true;
    }
    public override bool CanMoveLeft(Form form)
    {
        foreach (Figure child in childrens)
        {
            if (!child.CanMoveLeft(form))
            {
                return false;
            }
        }
        return true;
    }
    public override bool CanMoveRight(Form form)
    {
        foreach (Figure child in childrens)
        {
            if (!child.CanMoveRight(form))
            {
                return false;
            }
        }
        return true;
    }

    public override void MoveUp(Form form)
    {
        if (CanMoveUp(form))
        {
            foreach (Figure child in childrens)
            {
                child.MoveUp(form);
            }
        }

    }
    public override void MoveDown(Form form)
    {
        if (CanMoveDown(form))
        {
            foreach (Figure child in childrens)
            {
                child.MoveDown(form);
            }
        }
    }
    public override void MoveLeft(Form form)
    {
        if (CanMoveLeft(form))
        {
            foreach (Figure child in childrens)
            {
                child.MoveLeft(form);
            }
        }
    }
    public override void MoveRight(Form form)
    {
        if (CanMoveRight(form))
        {
            foreach (Figure child in childrens)
            {
                child.MoveRight(form);
            }
        }

    }
}

public class SavedData
{
    public List<string> linesToWrite = new List<string>();
    public void Add(string line)
    {
        linesToWrite.Add(line);
    }
}

public class SaverLoader
{
    public void Save(SavedData savedData, string way)
    {
        File.WriteAllLines(way, savedData.linesToWrite);
    }
}