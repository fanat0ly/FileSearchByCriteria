namespace FilesSearch
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tviewSFiles = new System.Windows.Forms.TreeView();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdSelectFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFContentPattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFNPattern = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSCriteria = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSelectedFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlSCriteria.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tviewSFiles
            // 
            this.tviewSFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tviewSFiles.Location = new System.Drawing.Point(3, 3);
            this.tviewSFiles.Name = "tviewSFiles";
            this.tviewSFiles.Size = new System.Drawing.Size(425, 396);
            this.tviewSFiles.TabIndex = 1;
            // 
            // cmdPause
            // 
            this.cmdPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPause.Location = new System.Drawing.Point(24, 368);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(104, 23);
            this.cmdPause.TabIndex = 5;
            this.cmdPause.Tag = "true";
            this.cmdPause.Text = "Пауза";
            this.cmdPause.UseVisualStyleBackColor = true;
            this.cmdPause.Visible = false;
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.Location = new System.Drawing.Point(134, 368);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(104, 23);
            this.cmdSearch.TabIndex = 4;
            this.cmdSearch.Tag = "true";
            this.cmdSearch.Text = "Поиск";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdSelectFolder
            // 
            this.cmdSelectFolder.Location = new System.Drawing.Point(124, 44);
            this.cmdSelectFolder.Name = "cmdSelectFolder";
            this.cmdSelectFolder.Size = new System.Drawing.Size(100, 23);
            this.cmdSelectFolder.TabIndex = 1;
            this.cmdSelectFolder.Text = "Выбрать";
            this.cmdSelectFolder.UseVisualStyleBackColor = true;
            this.cmdSelectFolder.Click += new System.EventHandler(this.cmdSelectFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Слово/фраза в файле:";
            // 
            // txtFContentPattern
            // 
            this.txtFContentPattern.Location = new System.Drawing.Point(6, 207);
            this.txtFContentPattern.Name = "txtFContentPattern";
            this.txtFContentPattern.Size = new System.Drawing.Size(231, 20);
            this.txtFContentPattern.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Шаблон имени файла:";
            // 
            // txtFNPattern
            // 
            this.txtFNPattern.Location = new System.Drawing.Point(6, 149);
            this.txtFNPattern.Name = "txtFNPattern";
            this.txtFNPattern.Size = new System.Drawing.Size(231, 20);
            this.txtFNPattern.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 514);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblCurrentFile);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.lblPCount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 411);
            this.groupBox2.MinimumSize = new System.Drawing.Size(500, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация";
            // 
            // lblSCount
            // 
            this.lblSCount.AutoSize = true;
            this.lblSCount.Location = new System.Drawing.Point(282, 60);
            this.lblSCount.Name = "lblSCount";
            this.lblSCount.Size = new System.Drawing.Size(13, 13);
            this.lblSCount.TabIndex = 8;
            this.lblSCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Файлов найдено:";
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Location = new System.Drawing.Point(176, 32);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentFile.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Обрабатывается файл:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(441, 60);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "00:00:00";
            // 
            // lblPCount
            // 
            this.lblPCount.AutoSize = true;
            this.lblPCount.Location = new System.Drawing.Point(131, 60);
            this.lblPCount.Name = "lblPCount";
            this.lblPCount.Size = new System.Drawing.Size(13, 13);
            this.lblPCount.TabIndex = 3;
            this.lblPCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Время поиска:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файлов обработано:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tviewSFiles, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlSCriteria, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(680, 402);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pnlSCriteria
            // 
            this.pnlSCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSCriteria.Controls.Add(this.groupBox1);
            this.pnlSCriteria.Controls.Add(this.label5);
            this.pnlSCriteria.Controls.Add(this.cmdPause);
            this.pnlSCriteria.Controls.Add(this.cmdSearch);
            this.pnlSCriteria.Controls.Add(this.txtFContentPattern);
            this.pnlSCriteria.Controls.Add(this.label3);
            this.pnlSCriteria.Controls.Add(this.label2);
            this.pnlSCriteria.Controls.Add(this.txtFNPattern);
            this.pnlSCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSCriteria.Location = new System.Drawing.Point(434, 3);
            this.pnlSCriteria.MinimumSize = new System.Drawing.Size(2, 300);
            this.pnlSCriteria.Name = "pnlSCriteria";
            this.pnlSCriteria.Size = new System.Drawing.Size(243, 396);
            this.pnlSCriteria.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSelectedFolder);
            this.groupBox1.Controls.Add(this.cmdSelectFolder);
            this.groupBox1.Location = new System.Drawing.Point(7, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск в папке";
            // 
            // txtSelectedFolder
            // 
            this.txtSelectedFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSelectedFolder.Location = new System.Drawing.Point(6, 20);
            this.txtSelectedFolder.Name = "txtSelectedFolder";
            this.txtSelectedFolder.ReadOnly = true;
            this.txtSelectedFolder.Size = new System.Drawing.Size(218, 13);
            this.txtSelectedFolder.TabIndex = 0;
            this.txtSelectedFolder.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Критерии поиска файлов";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "iconfinder_folder.png");
            // 
            // worker
            // 
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 514);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(523, 477);
            this.Name = "mainForm";
            this.Text = "Поиск файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlSCriteria.ResumeLayout(false);
            this.pnlSCriteria.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tviewSFiles;
        private System.Windows.Forms.Button cmdSelectFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFContentPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFNPattern;
        private System.Windows.Forms.Button cmdPause;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlSCriteria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSelectedFolder;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker worker;
    }
}

