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

namespace алгоритмы_лаба_4_си_шарп
{
    class Edge
    {
        private int x1, y1;
        private int x2, y2;
        public Edge() { }
        public Edge(int _x1, int _y1, int _x2, int _y2)
        {
            this.x1 = _x1;
            this.y1 = _y1;
            this.x2 = _x2;
            this.y2 = _y2;
        }
        public void draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            e.Graphics.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}
