namespace LagntonsAnt
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "White",
            "R"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "DarkGray",
            "L"}, -1);
            this.pb_gridDisplay = new System.Windows.Forms.PictureBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.pnl_controlPanel = new System.Windows.Forms.Panel();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.btn_swap = new System.Windows.Forms.Button();
            this.btn_saveImage = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_delColor = new System.Windows.Forms.Button();
            this.btn_addColor = new System.Windows.Forms.Button();
            this.list_ColorTurn = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txt_antY = new System.Windows.Forms.MaskedTextBox();
            this.txt_antX = new System.Windows.Forms.MaskedTextBox();
            this.btn_addAnt = new System.Windows.Forms.Button();
            this.pb_antColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_gridLineColor = new System.Windows.Forms.PictureBox();
            this.cb_gridLines = new System.Windows.Forms.CheckBox();
            this.lbl_cellSize = new System.Windows.Forms.Label();
            this.tb_Speed = new System.Windows.Forms.TrackBar();
            this.tb_cellSize = new System.Windows.Forms.TrackBar();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb_gridDisplay)).BeginInit();
            this.pnl_controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_antColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_gridLineColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cellSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_gridDisplay
            // 
            this.pb_gridDisplay.Location = new System.Drawing.Point(200, 0);
            this.pb_gridDisplay.Name = "pb_gridDisplay";
            this.pb_gridDisplay.Size = new System.Drawing.Size(600, 600);
            this.pb_gridDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_gridDisplay.TabIndex = 0;
            this.pb_gridDisplay.TabStop = false;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(17, 366);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(50, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // pnl_controlPanel
            // 
            this.pnl_controlPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_controlPanel.Controls.Add(this.lbl_speed);
            this.pnl_controlPanel.Controls.Add(this.btn_swap);
            this.pnl_controlPanel.Controls.Add(this.btn_saveImage);
            this.pnl_controlPanel.Controls.Add(this.btn_stop);
            this.pnl_controlPanel.Controls.Add(this.btn_restart);
            this.pnl_controlPanel.Controls.Add(this.btn_delColor);
            this.pnl_controlPanel.Controls.Add(this.btn_addColor);
            this.pnl_controlPanel.Controls.Add(this.list_ColorTurn);
            this.pnl_controlPanel.Controls.Add(this.label4);
            this.pnl_controlPanel.Controls.Add(this.txt_antY);
            this.pnl_controlPanel.Controls.Add(this.txt_antX);
            this.pnl_controlPanel.Controls.Add(this.btn_addAnt);
            this.pnl_controlPanel.Controls.Add(this.pb_antColor);
            this.pnl_controlPanel.Controls.Add(this.label2);
            this.pnl_controlPanel.Controls.Add(this.pb_gridLineColor);
            this.pnl_controlPanel.Controls.Add(this.cb_gridLines);
            this.pnl_controlPanel.Controls.Add(this.lbl_cellSize);
            this.pnl_controlPanel.Controls.Add(this.btn_run);
            this.pnl_controlPanel.Controls.Add(this.tb_Speed);
            this.pnl_controlPanel.Controls.Add(this.tb_cellSize);
            this.pnl_controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_controlPanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_controlPanel.Name = "pnl_controlPanel";
            this.pnl_controlPanel.Size = new System.Drawing.Size(200, 600);
            this.pnl_controlPanel.TabIndex = 2;
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoSize = true;
            this.lbl_speed.Location = new System.Drawing.Point(4, 16);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(59, 13);
            this.lbl_speed.TabIndex = 26;
            this.lbl_speed.Text = "Speed (60)";
            // 
            // btn_swap
            // 
            this.btn_swap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_swap.Location = new System.Drawing.Point(172, 245);
            this.btn_swap.Margin = new System.Windows.Forms.Padding(0);
            this.btn_swap.Name = "btn_swap";
            this.btn_swap.Size = new System.Drawing.Size(20, 20);
            this.btn_swap.TabIndex = 23;
            this.btn_swap.Text = "↔";
            this.btn_swap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_swap.UseVisualStyleBackColor = true;
            this.btn_swap.Click += new System.EventHandler(this.btn_swap_Click);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Enabled = false;
            this.btn_saveImage.Location = new System.Drawing.Point(135, 366);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.Size = new System.Drawing.Size(50, 23);
            this.btn_saveImage.TabIndex = 22;
            this.btn_saveImage.Text = "Save";
            this.btn_saveImage.UseVisualStyleBackColor = true;
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(78, 366);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(50, 23);
            this.btn_stop.TabIndex = 21;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(78, 58);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(50, 23);
            this.btn_restart.TabIndex = 20;
            this.btn_restart.Text = "Restart";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_delColor
            // 
            this.btn_delColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_delColor.Location = new System.Drawing.Point(172, 215);
            this.btn_delColor.Margin = new System.Windows.Forms.Padding(0);
            this.btn_delColor.Name = "btn_delColor";
            this.btn_delColor.Size = new System.Drawing.Size(20, 20);
            this.btn_delColor.TabIndex = 19;
            this.btn_delColor.Text = "-";
            this.btn_delColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_delColor.UseVisualStyleBackColor = true;
            this.btn_delColor.Click += new System.EventHandler(this.btn_delColor_Click);
            // 
            // btn_addColor
            // 
            this.btn_addColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_addColor.Location = new System.Drawing.Point(172, 195);
            this.btn_addColor.Margin = new System.Windows.Forms.Padding(0);
            this.btn_addColor.Name = "btn_addColor";
            this.btn_addColor.Size = new System.Drawing.Size(20, 20);
            this.btn_addColor.TabIndex = 18;
            this.btn_addColor.Text = "+";
            this.btn_addColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_addColor.UseVisualStyleBackColor = true;
            this.btn_addColor.Click += new System.EventHandler(this.btn_addColor_Click);
            // 
            // list_ColorTurn
            // 
            this.list_ColorTurn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list_ColorTurn.FullRowSelect = true;
            this.list_ColorTurn.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.list_ColorTurn.Location = new System.Drawing.Point(22, 195);
            this.list_ColorTurn.Name = "list_ColorTurn";
            this.list_ColorTurn.Size = new System.Drawing.Size(147, 160);
            this.list_ColorTurn.TabIndex = 16;
            this.list_ColorTurn.UseCompatibleStateImageBehavior = false;
            this.list_ColorTurn.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Color";
            this.columnHeader1.Width = 83;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Turn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Add Ant:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_antY
            // 
            this.txt_antY.Location = new System.Drawing.Point(105, 166);
            this.txt_antY.Mask = "###";
            this.txt_antY.Name = "txt_antY";
            this.txt_antY.PromptChar = ' ';
            this.txt_antY.Size = new System.Drawing.Size(29, 20);
            this.txt_antY.TabIndex = 14;
            this.txt_antY.Text = "3";
            this.txt_antY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_antX
            // 
            this.txt_antX.Location = new System.Drawing.Point(70, 166);
            this.txt_antX.Mask = "###";
            this.txt_antX.Name = "txt_antX";
            this.txt_antX.PromptChar = ' ';
            this.txt_antX.Size = new System.Drawing.Size(29, 20);
            this.txt_antX.TabIndex = 13;
            this.txt_antX.Text = "2";
            this.txt_antX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_addAnt
            // 
            this.btn_addAnt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_addAnt.Location = new System.Drawing.Point(137, 166);
            this.btn_addAnt.Margin = new System.Windows.Forms.Padding(0);
            this.btn_addAnt.Name = "btn_addAnt";
            this.btn_addAnt.Size = new System.Drawing.Size(20, 20);
            this.btn_addAnt.TabIndex = 12;
            this.btn_addAnt.Text = "+";
            this.btn_addAnt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_addAnt.UseVisualStyleBackColor = true;
            this.btn_addAnt.Click += new System.EventHandler(this.btn_addAnt_Click);
            // 
            // pb_antColor
            // 
            this.pb_antColor.BackColor = System.Drawing.Color.Red;
            this.pb_antColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_antColor.Location = new System.Drawing.Point(121, 141);
            this.pb_antColor.Name = "pb_antColor";
            this.pb_antColor.Size = new System.Drawing.Size(15, 15);
            this.pb_antColor.TabIndex = 11;
            this.pb_antColor.TabStop = false;
            this.pb_antColor.BackColorChanged += new System.EventHandler(this.pb_antColor_BackColorChanged);
            this.pb_antColor.Click += new System.EventHandler(this.pickColor);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ant Color";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pb_gridLineColor
            // 
            this.pb_gridLineColor.BackColor = System.Drawing.Color.Black;
            this.pb_gridLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_gridLineColor.Location = new System.Drawing.Point(121, 113);
            this.pb_gridLineColor.Name = "pb_gridLineColor";
            this.pb_gridLineColor.Size = new System.Drawing.Size(15, 15);
            this.pb_gridLineColor.TabIndex = 9;
            this.pb_gridLineColor.TabStop = false;
            this.pb_gridLineColor.BackColorChanged += new System.EventHandler(this.pb_gridLineColor_BackColorChanged);
            this.pb_gridLineColor.Click += new System.EventHandler(this.pickColor);
            // 
            // cb_gridLines
            // 
            this.cb_gridLines.AutoSize = true;
            this.cb_gridLines.Checked = true;
            this.cb_gridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gridLines.Location = new System.Drawing.Point(12, 112);
            this.cb_gridLines.Name = "cb_gridLines";
            this.cb_gridLines.Size = new System.Drawing.Size(103, 17);
            this.cb_gridLines.TabIndex = 8;
            this.cb_gridLines.Text = "Show Grid Lines";
            this.cb_gridLines.UseVisualStyleBackColor = true;
            this.cb_gridLines.CheckedChanged += new System.EventHandler(this.cb_gridLines_CheckedChanged);
            // 
            // lbl_cellSize
            // 
            this.lbl_cellSize.AutoSize = true;
            this.lbl_cellSize.Location = new System.Drawing.Point(4, 63);
            this.lbl_cellSize.Name = "lbl_cellSize";
            this.lbl_cellSize.Size = new System.Drawing.Size(68, 13);
            this.lbl_cellSize.TabIndex = 7;
            this.lbl_cellSize.Text = "Cell Size (15)";
            this.lbl_cellSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_Speed
            // 
            this.tb_Speed.LargeChange = 10;
            this.tb_Speed.Location = new System.Drawing.Point(1, 29);
            this.tb_Speed.Maximum = 100;
            this.tb_Speed.Minimum = 1;
            this.tb_Speed.Name = "tb_Speed";
            this.tb_Speed.Size = new System.Drawing.Size(199, 45);
            this.tb_Speed.TabIndex = 24;
            this.tb_Speed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_Speed.Value = 60;
            this.tb_Speed.ValueChanged += new System.EventHandler(this.tb_Speed_ValueChanged);
            // 
            // tb_cellSize
            // 
            this.tb_cellSize.LargeChange = 9;
            this.tb_cellSize.Location = new System.Drawing.Point(1, 79);
            this.tb_cellSize.Maximum = 50;
            this.tb_cellSize.Minimum = 1;
            this.tb_cellSize.Name = "tb_cellSize";
            this.tb_cellSize.Size = new System.Drawing.Size(199, 45);
            this.tb_cellSize.SmallChange = 3;
            this.tb_cellSize.TabIndex = 27;
            this.tb_cellSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_cellSize.Value = 15;
            this.tb_cellSize.ValueChanged += new System.EventHandler(this.tb_cellSize_ValueChanged);
            // 
            // SaveDialog
            // 
            this.SaveDialog.DefaultExt = "bmp";
            this.SaveDialog.Filter = "256 Color Bitmap|*.bmp;*.dib";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnl_controlPanel);
            this.Controls.Add(this.pb_gridDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Langton\'s Ant";
            ((System.ComponentModel.ISupportInitialize)(this.pb_gridDisplay)).EndInit();
            this.pnl_controlPanel.ResumeLayout(false);
            this.pnl_controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_antColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_gridLineColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cellSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_gridDisplay;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Panel pnl_controlPanel;
        private System.Windows.Forms.Label lbl_cellSize;
        private System.Windows.Forms.PictureBox pb_gridLineColor;
        private System.Windows.Forms.CheckBox cb_gridLines;
        private System.Windows.Forms.PictureBox pb_antColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txt_antY;
        private System.Windows.Forms.MaskedTextBox txt_antX;
        private System.Windows.Forms.Button btn_addAnt;
        private System.Windows.Forms.ListView list_ColorTurn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_delColor;
        private System.Windows.Forms.Button btn_addColor;
        private System.Windows.Forms.Button btn_saveImage;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Button btn_swap;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.TrackBar tb_Speed;
        private System.Windows.Forms.TrackBar tb_cellSize;
    }
}

