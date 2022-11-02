using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace алгоритмы_лаба_5
{
    class Circle
    {
        private int x; //координаты центра круга
        private int y;
        private int r; //радиус
        private bool select;
        private int num;
        public Circle() { }
        public Circle(int _x, int _y, int _r, int _num)
        {
            this.x = _x;
            this.y = _y;
            this.r = _r;
            this.select = false;
            this.num = _num;
        }
        ~Circle() { }
        public void draw(PaintEventArgs e)
        {
            Pen pen;
            SolidBrush solidBrush;
            if (select == true)
            {
                pen = new Pen(Color.Green, 2); //цвет и толщина кисти
                solidBrush = new SolidBrush(Color.LightGreen);
            }
            else
            {
                pen = new Pen(Color.Black, 2);
                solidBrush = new SolidBrush(Color.White);
            }
            //-r чтобы центр круга оказывался в месте клика, тк эллипс рисуется из верхнего левого угла
            e.Graphics.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            e.Graphics.FillEllipse(solidBrush, x - r, y - r, 2 * r, 2 * r); //заполняем эллипс
            e.Graphics.DrawString(num.ToString(), new Font("Sergoe", 8), Brushes.Black, x - r / 3, y - r / 3); //номер
        }
        public bool selected(int _x, int _y)
        {
            if (Math.Pow((_x - x), 2) + Math.Pow((_y - y), 2) <= Math.Pow(this.r, 2))
                select = true;
            return select;
        }
        public void selected_false()
        {
            select = false;
        }
        public int get_x()
        {
            return x;
        }
        public int get_y()
        {
            return y;
        }
        public int get_num()
        {
            return num;
        }
    }
}
