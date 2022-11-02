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

namespace алгоритмы_лаба_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Circle> C = new List<Circle>();
        List<Edge> E = new List<Edge>();
        List<int> comp = new List<int>();
        Stack<int> temp = new Stack<int>();
        Stack<int> rez = new Stack<int>();

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

        private void dfs(int init)
        {
            visited[init] = true;
            comp.Add(init + 1);
            for (int i = 0; i < num; i++)
            {
                if ((!visited[i]) && (matrix[init][i] == 1))
                    dfs(i);
            }
        }
        private bool degree()
        {
            int count;
            for (int i = 0; i < num; i++)
            {
                count = 0;
                for (int j = 0; j < num; j++)
                {
                    if (matrix[i][j] != 0) count = count + 1;
                }
                if (count % 2 != 0) return false;
            }
            return true;  
        }
        private void euler_cycle()
        {
            temp.Clear();
            int v = 1;
            int U = 0;
            bool flg = false;
            temp.Push(v);
            while (temp.Count != 0) //пока стек не пустой
            {
                v = temp.Peek(); //достаем верхнее значение из стека (чтение элемента)
                for (int i = 0; i < num; i++)
                    if (matrix[v - 1][i] != 0) //если у вершины есть смежная вершина
                    {
                        flg = true;
                        break;
                    }
                if (flg == true) //если у вершины есть смежная
                {
                    for (int i = 0; i < num; i++)
                        if (matrix[v - 1][i] == 1)
                        {
                            U = i + 1;
                            matrix[v - 1][i] = 0; //удаляем ребро между вершиной и смежной с ней
                            matrix[i][v - 1] = 0;
                            break;
                        }
                    temp.Push(U); //кладем обратно в стек
                    flg = false;
                }
                else //если смежных больше нет, кладем в стек с результатом
                {
                    U = temp.Pop(); //(удаление элемента)
                    rez.Push(U);
                }
            }
        }

        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            graph = new Graph(C, E);
            visited = new bool[num];
            for (int i = 0; i < num; i++) visited[i] = false;

            dfs(0);
            if (comp.Count < num)
                richTextBox1.Text = "The graph does not contain an Euler cycle,\n since the graph is disconnected.";
            else
            {
                if (degree() == false) richTextBox1.Text = "The graph does not contain an Euler cycle,\n since not all vertices are of even degree.";
                else
                {
                    for (int i = 0; i < num; i++) visited[i] = false;
                            
                    euler_cycle();

                    string s = "Euler cycle:  ";
                    for (int i = rez.Count; i > 0; i--)
                    {
                        int tmp = rez.Pop();
                        s += tmp.ToString();
                        s += "  ";
                    }
                    richTextBox1.Text += s;
                }
            }
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

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            C.Clear();
            E.Clear();
            temp.Clear();
            rez.Clear();
            comp.Clear();
            graph = new Graph(C, E);
            Refresh();
            dataGridView_Matrix.Rows.Clear();
            dataGridView_Matrix.Columns.Clear();
            richTextBox1.Text = "";
            for (int i = 0; i < num; i++)
                for (int j = 0; j < num; j++)
                    matrix[i][j] = 0;
            num = 0;
            Array.Resize(ref matrix, num);
            Array.Resize(ref visited, num);
        }
    }
}
