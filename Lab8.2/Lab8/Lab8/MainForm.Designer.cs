namespace Lab8
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtFolderPath = new TextBox();
            btnSelectFolder = new Button();
            btnSearchDuplicates = new Button();
            lvDuplicates = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnDeleteSelected = new Button();
            btnDeleteAllDuplicates = new Button();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            btnSortByDate = new Button();
            cmbTimePeriod = new ComboBox();
            label1 = new Label();
            lblFileCount = new Label();
            btnShowLog = new Button();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFolderPath.Location = new Point(14, 14);
            txtFolderPath.Margin = new Padding(4, 3, 4, 3);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(653, 23);
            txtFolderPath.TabIndex = 0;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFolder.Location = new Point(674, 12);
            btnSelectFolder.Margin = new Padding(4, 3, 4, 3);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(117, 27);
            btnSelectFolder.TabIndex = 1;
            btnSelectFolder.Text = "Выбрать папку";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnSearchDuplicates
            // 
            btnSearchDuplicates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchDuplicates.Location = new Point(798, 12);
            btnSearchDuplicates.Margin = new Padding(4, 3, 4, 3);
            btnSearchDuplicates.Name = "btnSearchDuplicates";
            btnSearchDuplicates.Size = new Size(121, 27);
            btnSearchDuplicates.TabIndex = 2;
            btnSearchDuplicates.Text = "Найти дубликаты";
            btnSearchDuplicates.UseVisualStyleBackColor = true;
            btnSearchDuplicates.Click += btnSearchDuplicates_Click;
            // 
            // lvDuplicates
            // 
            lvDuplicates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvDuplicates.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvDuplicates.FullRowSelect = true;
            lvDuplicates.GridLines = true;
            lvDuplicates.Location = new Point(14, 44);
            lvDuplicates.Margin = new Padding(4, 3, 4, 3);
            lvDuplicates.Name = "lvDuplicates";
            lvDuplicates.Size = new Size(905, 403);
            lvDuplicates.TabIndex = 3;
            lvDuplicates.UseCompatibleStateImageBehavior = false;
            lvDuplicates.View = View.Details;
            lvDuplicates.SelectedIndexChanged += lvDuplicates_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Имя файла";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Размер";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Дата создания";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Путь";
            columnHeader4.Width = 350;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteSelected.Location = new Point(67, 457);
            btnDeleteSelected.Margin = new Padding(4, 3, 4, 3);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(175, 27);
            btnDeleteSelected.TabIndex = 4;
            btnDeleteSelected.Text = "Удалить выбранные";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnDeleteAllDuplicates
            // 
            btnDeleteAllDuplicates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteAllDuplicates.Location = new Point(250, 457);
            btnDeleteAllDuplicates.Margin = new Padding(4, 3, 4, 3);
            btnDeleteAllDuplicates.Name = "btnDeleteAllDuplicates";
            btnDeleteAllDuplicates.Size = new Size(175, 27);
            btnDeleteAllDuplicates.TabIndex = 5;
            btnDeleteAllDuplicates.Text = "Удалить все дубликаты";
            btnDeleteAllDuplicates.UseVisualStyleBackColor = true;
            btnDeleteAllDuplicates.Click += btnDeleteAllDuplicates_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(14, 488);
            progressBar.Margin = new Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(905, 27);
            progressBar.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(14, 518);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Готов";
            // 
            // btnSortByDate
            // 
            btnSortByDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSortByDate.Location = new Point(616, 457);
            btnSortByDate.Margin = new Padding(4, 3, 4, 3);
            btnSortByDate.Name = "btnSortByDate";
            btnSortByDate.Size = new Size(175, 27);
            btnSortByDate.TabIndex = 8;
            btnSortByDate.Text = "Сортировать по дате";
            btnSortByDate.UseVisualStyleBackColor = true;
            btnSortByDate.Click += btnSortByDate_Click;
            // 
            // cmbTimePeriod
            // 
            cmbTimePeriod.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimePeriod.FormattingEnabled = true;
            cmbTimePeriod.Items.AddRange(new object[] { "День", "Неделя", "Месяц" });
            cmbTimePeriod.Location = new Point(856, 457);
            cmbTimePeriod.Margin = new Padding(4, 3, 4, 3);
            cmbTimePeriod.Name = "cmbTimePeriod";
            cmbTimePeriod.Size = new Size(62, 23);
            cmbTimePeriod.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(798, 460);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 10;
            label1.Text = "Период";
            // 
            // lblFileCount
            // 
            lblFileCount.AutoSize = true;
            lblFileCount.Location = new Point(14, 460);
            lblFileCount.Margin = new Padding(4, 0, 4, 0);
            lblFileCount.Name = "lblFileCount";
            lblFileCount.Size = new Size(0, 15);
            lblFileCount.TabIndex = 11;
            // 
            // btnShowLog
            // 
            btnShowLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnShowLog.Location = new Point(433, 457);
            btnShowLog.Margin = new Padding(4, 3, 4, 3);
            btnShowLog.Name = "btnShowLog";
            btnShowLog.Size = new Size(175, 27);
            btnShowLog.TabIndex = 12;
            btnShowLog.Text = "Показать журнал";
            btnShowLog.UseVisualStyleBackColor = true;
            btnShowLog.Click += btnShowLog_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 543);
            Controls.Add(btnShowLog);
            Controls.Add(lblFileCount);
            Controls.Add(label1);
            Controls.Add(cmbTimePeriod);
            Controls.Add(btnSortByDate);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(btnDeleteAllDuplicates);
            Controls.Add(btnDeleteSelected);
            Controls.Add(lvDuplicates);
            Controls.Add(btnSearchDuplicates);
            Controls.Add(btnSelectFolder);
            Controls.Add(txtFolderPath);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Очистка и сортировка фотографий";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnSearchDuplicates;
        private System.Windows.Forms.ListView lvDuplicates;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnDeleteAllDuplicates;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnSortByDate;
        private System.Windows.Forms.ComboBox cmbTimePeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Button btnShowLog;

    #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Text = "Form1";
        }

        #endregion
    }


