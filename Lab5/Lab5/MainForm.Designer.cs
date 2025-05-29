namespace Lab5
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
            picGraph = new PictureBox();
            groupBox1 = new GroupBox();
            cmbEquationType = new ComboBox();
            label1 = new Label();
            numA = new NumericUpDown();
            numB = new NumericUpDown();
            label2 = new Label();
            numC = new NumericUpDown();
            label3 = new Label();
            groupBox2 = new GroupBox();
            numX2 = new NumericUpDown();
            label5 = new Label();
            numX1 = new NumericUpDown();
            label4 = new Label();
            btnPlot = new Button();
            groupBox3 = new GroupBox();
            cmbIntegratorType = new ComboBox();
            label6 = new Label();
            numIntegralX1 = new NumericUpDown();
            label7 = new Label();
            numIntegralX2 = new NumericUpDown();
            label8 = new Label();
            numPartitions = new NumericUpDown();
            label9 = new Label();
            btnIntegrate = new Button();
            txtResult = new TextBox();
            label10 = new Label();
            txtFunctionInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picGraph).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numC).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numX2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numX1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIntegralX1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIntegralX2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPartitions).BeginInit();
            SuspendLayout();
            // 
            // picGraph
            // 
            picGraph.BackColor = Color.White;
            picGraph.BorderStyle = BorderStyle.FixedSingle;
            picGraph.Location = new Point(14, 14);
            picGraph.Margin = new Padding(4, 3, 4, 3);
            picGraph.Name = "picGraph";
            picGraph.Size = new Size(700, 461);
            picGraph.TabIndex = 0;
            picGraph.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbEquationType);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numA);
            groupBox1.Controls.Add(numB);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numC);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(721, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(292, 173);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Уравнение";
            // 
            // cmbEquationType
            // 
            cmbEquationType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquationType.FormattingEnabled = true;
            cmbEquationType.Location = new Point(7, 22);
            cmbEquationType.Margin = new Padding(4, 3, 4, 3);
            cmbEquationType.Name = "cmbEquationType";
            cmbEquationType.Size = new Size(277, 23);
            cmbEquationType.TabIndex = 0;
            cmbEquationType.SelectedIndexChanged += cmbEquationType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 54);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 1;
            label1.Text = "Коэффициент a:";
            // 
            // numA
            // 
            numA.DecimalPlaces = 2;
            numA.Location = new Point(97, 54);
            numA.Margin = new Padding(4, 3, 4, 3);
            numA.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numA.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numA.Name = "numA";
            numA.Size = new Size(188, 23);
            numA.TabIndex = 2;
            // 
            // numB
            // 
            numB.DecimalPlaces = 2;
            numB.Location = new Point(97, 82);
            numB.Margin = new Padding(4, 3, 4, 3);
            numB.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numB.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numB.Name = "numB";
            numB.Size = new Size(188, 23);
            numB.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 84);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 3;
            label2.Text = "Коэффициент b:";
            // 
            // numC
            // 
            numC.DecimalPlaces = 2;
            numC.Location = new Point(97, 112);
            numC.Margin = new Padding(4, 3, 4, 3);
            numC.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numC.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numC.Name = "numC";
            numC.Size = new Size(188, 23);
            numC.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 114);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 5;
            label3.Text = "Коэффициент c:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numX2);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(numX1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnPlot);
            groupBox2.Location = new Point(721, 194);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(292, 115);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Построение графика";
            // 
            // numX2
            // 
            numX2.DecimalPlaces = 2;
            numX2.Location = new Point(97, 52);
            numX2.Margin = new Padding(4, 3, 4, 3);
            numX2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numX2.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numX2.Name = "numX2";
            numX2.Size = new Size(188, 23);
            numX2.TabIndex = 4;
            numX2.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 54);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 3;
            label5.Text = "До X:";
            // 
            // numX1
            // 
            numX1.DecimalPlaces = 2;
            numX1.Location = new Point(97, 22);
            numX1.Margin = new Padding(4, 3, 4, 3);
            numX1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numX1.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numX1.Name = "numX1";
            numX1.Size = new Size(188, 23);
            numX1.TabIndex = 2;
            numX1.Value = new decimal(new int[] { 10, 0, 0, int.MinValue });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 24);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 1;
            label4.Text = "От X:";
            // 
            // btnPlot
            // 
            btnPlot.Location = new Point(7, 82);
            btnPlot.Margin = new Padding(4, 3, 4, 3);
            btnPlot.Name = "btnPlot";
            btnPlot.Size = new Size(278, 27);
            btnPlot.TabIndex = 0;
            btnPlot.Text = "Построить график";
            btnPlot.UseVisualStyleBackColor = true;
            btnPlot.Click += btnPlot_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbIntegratorType);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(numIntegralX1);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(numIntegralX2);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(numPartitions);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(btnIntegrate);
            groupBox3.Controls.Add(txtResult);
            groupBox3.Controls.Add(label10);
            groupBox3.Location = new Point(721, 316);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(292, 231);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Интегрирование";
            // 
            // cmbIntegratorType
            // 
            cmbIntegratorType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIntegratorType.FormattingEnabled = true;
            cmbIntegratorType.Location = new Point(7, 22);
            cmbIntegratorType.Margin = new Padding(4, 3, 4, 3);
            cmbIntegratorType.Name = "cmbIntegratorType";
            cmbIntegratorType.Size = new Size(277, 23);
            cmbIntegratorType.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 54);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 1;
            label6.Text = "От X:";
            // 
            // numIntegralX1
            // 
            numIntegralX1.DecimalPlaces = 2;
            numIntegralX1.Location = new Point(97, 52);
            numIntegralX1.Margin = new Padding(4, 3, 4, 3);
            numIntegralX1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numIntegralX1.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numIntegralX1.Name = "numIntegralX1";
            numIntegralX1.Size = new Size(188, 23);
            numIntegralX1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 84);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 3;
            label7.Text = "До X:";
            // 
            // numIntegralX2
            // 
            numIntegralX2.DecimalPlaces = 2;
            numIntegralX2.Location = new Point(97, 82);
            numIntegralX2.Margin = new Padding(4, 3, 4, 3);
            numIntegralX2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numIntegralX2.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numIntegralX2.Name = "numIntegralX2";
            numIntegralX2.Size = new Size(188, 23);
            numIntegralX2.TabIndex = 4;
            numIntegralX2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 114);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(107, 15);
            label8.TabIndex = 5;
            label8.Text = "Число разбиений:";
            // 
            // numPartitions
            // 
            numPartitions.Location = new Point(136, 112);
            numPartitions.Margin = new Padding(4, 3, 4, 3);
            numPartitions.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPartitions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartitions.Name = "numPartitions";
            numPartitions.Size = new Size(148, 23);
            numPartitions.TabIndex = 6;
            numPartitions.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 177);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 7;
            label9.Text = "Результат:";
            // 
            // btnIntegrate
            // 
            btnIntegrate.Location = new Point(7, 142);
            btnIntegrate.Margin = new Padding(4, 3, 4, 3);
            btnIntegrate.Name = "btnIntegrate";
            btnIntegrate.Size = new Size(278, 27);
            btnIntegrate.TabIndex = 8;
            btnIntegrate.Text = "Вычислить интеграл";
            btnIntegrate.UseVisualStyleBackColor = true;
            btnIntegrate.Click += btnIntegrate_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(86, 173);
            txtResult.Margin = new Padding(4, 3, 4, 3);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(198, 23);
            txtResult.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 203);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(0, 15);
            label10.TabIndex = 10;
            // 
            // txtFunctionInfo
            // 
            txtFunctionInfo.Location = new Point(14, 482);
            txtFunctionInfo.Margin = new Padding(4, 3, 4, 3);
            txtFunctionInfo.Multiline = true;
            txtFunctionInfo.Name = "txtFunctionInfo";
            txtFunctionInfo.ReadOnly = true;
            txtFunctionInfo.ScrollBars = ScrollBars.Vertical;
            txtFunctionInfo.Size = new Size(699, 64);
            txtFunctionInfo.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 561);
            Controls.Add(txtFunctionInfo);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(picGraph);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Анализатор функций";
            Resize += MainForm_Resize;
            ((System.ComponentModel.ISupportInitialize)picGraph).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numC).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numX2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numX1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIntegralX1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIntegralX2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPartitions).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.ComboBox cmbEquationType;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.NumericUpDown numA;
            private System.Windows.Forms.NumericUpDown numB;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.NumericUpDown numC;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.GroupBox groupBox2;
            private System.Windows.Forms.NumericUpDown numX2;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.NumericUpDown numX1;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.Button btnPlot;
            private System.Windows.Forms.GroupBox groupBox3;
            private System.Windows.Forms.ComboBox cmbIntegratorType;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.NumericUpDown numIntegralX1;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.NumericUpDown numIntegralX2;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.NumericUpDown numPartitions;
            private System.Windows.Forms.Label label9;
            private System.Windows.Forms.Button btnIntegrate;
            private System.Windows.Forms.TextBox txtResult;
            private System.Windows.Forms.Label label10;
            private System.Windows.Forms.TextBox txtFunctionInfo;
        }
    }

