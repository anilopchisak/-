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
    class Graph
    {
        private List<Circle> C;
        private List<Edge> E;

        public Graph() { }
        public Graph(List<Circle> _C, List<Edge> _E)
        {
            C = _C;
            E = _E;
        }
        public void draw(PaintEventArgs e)
        {
            if (E != null)
                for (int i = 0; i < E.Count; i++) E[i].draw(e);
            if (C != null)
                for (int i = 0; i < C.Count; i++) C[i].draw(e);
        }
    }
}
