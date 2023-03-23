namespace Lab2Sample
{
    partial class MainForm
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
            this.matrixGrid1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.matrixGrid2 = new System.Windows.Forms.DataGridView();
            this.loadMatrix1Button = new System.Windows.Forms.Button();
            this.saveMatrix1Button = new System.Windows.Forms.Button();
            this.task1Button = new System.Windows.Forms.Button();
            this.task2Button = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadMatrix2Button = new System.Windows.Forms.Button();
            this.saveMatrix2Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // matrixGrid1
            // 
            this.matrixGrid1.AllowUserToAddRows = false;
            this.matrixGrid1.AllowUserToDeleteRows = false;
            this.matrixGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGrid1.Location = new System.Drawing.Point(23, 36);
            this.matrixGrid1.Name = "matrixGrid1";
            this.matrixGrid1.RowHeadersWidth = 51;
            this.matrixGrid1.RowTemplate.Height = 24;
            this.matrixGrid1.Size = new System.Drawing.Size(453, 240);
            this.matrixGrid1.TabIndex = 3;
            this.matrixGrid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrixGrid1_CellEndEdit);
            this.matrixGrid1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.matrixGrid1_CellValidating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrix 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Matrix 2";
            // 
            // matrixGrid2
            // 
            this.matrixGrid2.AllowUserToAddRows = false;
            this.matrixGrid2.AllowUserToDeleteRows = false;
            this.matrixGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGrid2.Location = new System.Drawing.Point(23, 313);
            this.matrixGrid2.Name = "matrixGrid2";
            this.matrixGrid2.RowHeadersWidth = 51;
            this.matrixGrid2.RowTemplate.Height = 24;
            this.matrixGrid2.Size = new System.Drawing.Size(453, 240);
            this.matrixGrid2.TabIndex = 4;
            this.matrixGrid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrixGrid1_CellEndEdit);
            this.matrixGrid2.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.matrixGrid1_CellValidating);
            // 
            // loadMatrix1Button
            // 
            this.loadMatrix1Button.Location = new System.Drawing.Point(550, 36);
            this.loadMatrix1Button.Name = "loadMatrix1Button";
            this.loadMatrix1Button.Size = new System.Drawing.Size(127, 34);
            this.loadMatrix1Button.TabIndex = 1;
            this.loadMatrix1Button.Text = "Load Matrix 1";
            this.loadMatrix1Button.UseVisualStyleBackColor = true;
            this.loadMatrix1Button.Click += new System.EventHandler(this.loadMatrix1Button_Click);
            // 
            // saveMatrix1Button
            // 
            this.saveMatrix1Button.Enabled = false;
            this.saveMatrix1Button.Location = new System.Drawing.Point(550, 81);
            this.saveMatrix1Button.Name = "saveMatrix1Button";
            this.saveMatrix1Button.Size = new System.Drawing.Size(127, 34);
            this.saveMatrix1Button.TabIndex = 5;
            this.saveMatrix1Button.Text = "Save Matrix 1";
            this.saveMatrix1Button.UseVisualStyleBackColor = true;
            this.saveMatrix1Button.Click += new System.EventHandler(this.saveMatrix1Button_Click);
            // 
            // task1Button
            // 
            this.task1Button.Enabled = false;
            this.task1Button.Location = new System.Drawing.Point(550, 479);
            this.task1Button.Name = "task1Button";
            this.task1Button.Size = new System.Drawing.Size(127, 34);
            this.task1Button.TabIndex = 6;
            this.task1Button.Text = "Task 1";
            this.task1Button.UseVisualStyleBackColor = true;
            this.task1Button.Click += new System.EventHandler(this.task1Button_Click);
            // 
            // task2Button
            // 
            this.task2Button.Enabled = false;
            this.task2Button.Location = new System.Drawing.Point(550, 519);
            this.task2Button.Name = "task2Button";
            this.task2Button.Size = new System.Drawing.Size(127, 34);
            this.task2Button.TabIndex = 7;
            this.task2Button.Text = "Task 2";
            this.task2Button.UseVisualStyleBackColor = true;
            this.task2Button.Click += new System.EventHandler(this.task2Button_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // loadMatrix2Button
            // 
            this.loadMatrix2Button.Location = new System.Drawing.Point(550, 313);
            this.loadMatrix2Button.Name = "loadMatrix2Button";
            this.loadMatrix2Button.Size = new System.Drawing.Size(127, 34);
            this.loadMatrix2Button.TabIndex = 2;
            this.loadMatrix2Button.Text = "Load Matrix 2";
            this.loadMatrix2Button.UseVisualStyleBackColor = true;
            this.loadMatrix2Button.Click += new System.EventHandler(this.loadMatrix2Button_Click);
            // 
            // saveMatrix2Button
            // 
            this.saveMatrix2Button.Enabled = false;
            this.saveMatrix2Button.Location = new System.Drawing.Point(550, 356);
            this.saveMatrix2Button.Name = "saveMatrix2Button";
            this.saveMatrix2Button.Size = new System.Drawing.Size(127, 34);
            this.saveMatrix2Button.TabIndex = 10;
            this.saveMatrix2Button.Text = "Save Matrix 2";
            this.saveMatrix2Button.UseVisualStyleBackColor = true;
            this.saveMatrix2Button.Click += new System.EventHandler(this.saveMatrix1Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 584);
            this.Controls.Add(this.saveMatrix2Button);
            this.Controls.Add(this.loadMatrix2Button);
            this.Controls.Add(this.task2Button);
            this.Controls.Add(this.task1Button);
            this.Controls.Add(this.saveMatrix1Button);
            this.Controls.Add(this.loadMatrix1Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.matrixGrid2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matrixGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.matrixGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView matrixGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView matrixGrid2;
        private System.Windows.Forms.Button loadMatrix1Button;
        private System.Windows.Forms.Button saveMatrix1Button;
        private System.Windows.Forms.Button task1Button;
        private System.Windows.Forms.Button task2Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button loadMatrix2Button;
        private System.Windows.Forms.Button saveMatrix2Button;
    }
}

