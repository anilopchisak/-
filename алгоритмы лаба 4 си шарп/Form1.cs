using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace алгоритмы_лаба_4_си_шарп
{
    public partial class Form1 : Form
    {
        List<Circle> C = new List<Circle>();
        List<Edge> E = new List<Edge>();

        public Form1()
        {
            InitializeComponent();
        }

        Graph graph = new Graph();
        Circle circle = new Circle();
        Edge edge = new Edge();
        const int r = 20; //радиус круга
        int selected_items; //количество выделенных вершин
        int num = 0; //номер вершины
        int x1, y1; int x2, y2; //координаты выделенных вершин, необходимые для передачи в конструктор ребра
        int num1, num2; //для хранения номеров вершин, между которыми проложено ребро, для матрицы смежности
        int[][] matrix;
        bool[] visited;

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txtbx_Enter.Text != "")
            {
                txtbx_Search.Text = "";
                int init = Int32.Parse(txtbx_Enter.Text); //считываем текст из текстбокса, начальная вершина
                txtbx_Enter.Text = "";

                graph = new Graph(C, E);

                visited = new bool[num];
                for (int i = 0; i < num; i++) visited[i] = false;
                dfs(init - 1);
            }
        }
        private void dfs(int init)
        {
            string s = "";
            s += (init+1).ToString();
            s += " -> ";
            txtbx_Search.Text += s;
            visited[init] = true;
            for (int i = 0; i < num; i++)
            {
                if ((!visited[i]) && (matrix[init][i] == 1))
                    dfs(i);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e) //очистка
        {
            C.Clear();
            E.Clear(); 
            graph = new Graph(C, E);
            Refresh();
            dataGridView_Matrix.Rows.Clear();
            dataGridView_Matrix.Columns.Clear();
            txtbx_Enter.Text = "";
            txtbx_Search.Text = "";
            for (int i = 0; i < num; i++)
            {
                //if (visited[i])
                //    visited[i] = false;
                for (int j = 0; j < num; j++)
                    matrix[i][j] = 0;
            }
            num = 0;
            Array.Resize(ref matrix, num);
            Array.Resize(ref visited, num);
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //matrix = new int[num][];
                num = num + 1;
                Array.Resize(ref matrix, num); //ref - * в с++
                for (int i = 0; i < num; i++)
                    Array.Resize(ref matrix[i], num); 

                if (C != null)
                {
                    selected_items = 0; 
                    for (int j = 0; j < C.Count; j++) C[j].selected_false();
                }

                circle = new Circle(e.X, e.Y, r, num);
                C.Add(circle);
                graph = new Graph(C, E);
                Refresh(); //ручной вызов PaintEvent

                dataGridView_Matrix.ColumnCount = num;
                dataGridView_Matrix.RowCount = num;
                for (int i = 0; i < num; i++)
                {
                    dataGridView_Matrix.Columns[i].HeaderText = (i + 1).ToString();
                    dataGridView_Matrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    for (int j = 0; j < num; j++)
                    {
                        if (i == num - 1 || j == num - 1)
                            matrix[i][j] = 0;
                        dataGridView_Matrix.Rows[i].Cells[j].Value = matrix[i][j];
                    }
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < C.Count; i++) //перебираем все вершины и смотрим, ввыделили ли мы одну или нет
                {
                    if (C[i].selected(e.X, e.Y) == true) //если вершина выделена
                    {
                        if (selected_items <= 1) //чтобы соединялись только две вершины
                        {
                            Refresh();
                            selected_items = selected_items + 1;
                        }
                        else if (selected_items == 2)
                        {
                            bool count = false;
                            for (int j = 0; j < C.Count; j++) //передаем координаты выделенных вершин в конструктор ребра
                            {
                                if (C[j].selected(e.X, e.Y) == true)
                                {
                                    if (count == false)
                                    {
                                        x1 = C[j].get_x();
                                        y1 = C[j].get_y();
                                        num1 = C[j].get_num();
                                        count = true;
                                    }
                                    else
                                    {
                                        x2 = C[j].get_x();
                                        y2 = C[j].get_y();
                                        num2 = C[j].get_num();
                                    }
                                }
                            }
                            edge = new Edge(x1, y1, x2, y2);
                            E.Add(edge);
                            selected_items = 0;
                            for (int j = 0; j < C.Count; j++) C[j].selected_false();
                            graph = new Graph(C, E);
                            Refresh();

                            dataGridView_Matrix[num1 - 1, num2 - 1].Value = 1;
                            dataGridView_Matrix[num2 - 1, num1 - 1].Value = 1;
                            matrix[num1 - 1][num2 - 1] = 1;
                            matrix[num2 - 1][num1 - 1] = 1;
                        }
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graph.draw(e);
        }

    }
}
