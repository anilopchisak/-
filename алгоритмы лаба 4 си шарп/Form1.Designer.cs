
namespace алгоритмы_лаба_4_си_шарп
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView_Matrix = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_Enter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.txtbx_Search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(25, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(826, 536);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // dataGridView_Matrix
            // 
            this.dataGridView_Matrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Matrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Matrix.Location = new System.Drawing.Point(881, 65);
            this.dataGridView_Matrix.Name = "dataGridView_Matrix";
            this.dataGridView_Matrix.RowHeadersWidth = 51;
            this.dataGridView_Matrix.RowTemplate.Height = 24;
            this.dataGridView_Matrix.Size = new System.Drawing.Size(494, 339);
            this.dataGridView_Matrix.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(878, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "The adjacency matrix:";
            // 
            // txtbx_Enter
            // 
            this.txtbx_Enter.Location = new System.Drawing.Point(1028, 427);
            this.txtbx_Enter.Name = "txtbx_Enter";
            this.txtbx_Enter.Size = new System.Drawing.Size(118, 22);
            this.txtbx_Enter.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(878, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter the initial value:";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(881, 539);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(120, 25);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear all";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // txtbx_Search
            // 
            this.txtbx_Search.Location = new System.Drawing.Point(881, 468);
            this.txtbx_Search.Name = "txtbx_Search";
            this.txtbx_Search.Size = new System.Drawing.Size(367, 22);
            this.txtbx_Search.TabIndex = 7;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(1180, 418);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(178, 34);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "Depth-first search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 576);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txtbx_Search);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbx_Enter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Matrix);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Matrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView_Matrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbx_Enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.TextBox txtbx_Search;
        private System.Windows.Forms.Button btn_search;
    }
}

