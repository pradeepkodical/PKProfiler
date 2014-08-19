namespace CodeProfiler
{
    partial class MainProfiler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProfiler));
            this.btnFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKeyFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnInclude = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblServerStatus = new System.Windows.Forms.ToolStripLabel();
            this.btnStartWeaving = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnViewTraces = new System.Windows.Forms.ToolStripButton();
            this.btnClearProfile = new System.Windows.Forms.ToolStripButton();
            this.btnDBTraces = new System.Windows.Forms.ToolStripButton();
            this.btnViewTestTraces = new System.Windows.Forms.ToolStripButton();
            this.btnStartStop = new System.Windows.Forms.ToolStripButton();
            this.commandParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.picCleared = new System.Windows.Forms.PictureBox();
            this.picInstrumentIcon = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commandParametersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCleared)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstrumentIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(397, 16);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(24, 23);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(323, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assembly:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(475, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(289, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(68, 45);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(323, 20);
            this.textBox4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key File:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Include:";
            // 
            // btnKeyFile
            // 
            this.btnKeyFile.Location = new System.Drawing.Point(397, 42);
            this.btnKeyFile.Name = "btnKeyFile";
            this.btnKeyFile.Size = new System.Drawing.Size(24, 23);
            this.btnKeyFile.TabIndex = 5;
            this.btnKeyFile.Text = "...";
            this.btnKeyFile.UseVisualStyleBackColor = true;
            this.btnKeyFile.Click += new System.EventHandler(this.btnKeyFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "EXE|*.exe|DLL|*.dll";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "Strong Key|*.snk";
            // 
            // btnInclude
            // 
            this.btnInclude.Location = new System.Drawing.Point(770, 17);
            this.btnInclude.Name = "btnInclude";
            this.btnInclude.Size = new System.Drawing.Size(24, 23);
            this.btnInclude.TabIndex = 8;
            this.btnInclude.Text = "...";
            this.btnInclude.UseVisualStyleBackColor = true;
            this.btnInclude.Click += new System.EventHandler(this.btnInclude_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.commandParametersBindingSource, "DecodeParameters", true));
            this.checkBox1.Location = new System.Drawing.Point(427, 46);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Decode Parameters";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(30, 109);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Ready";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.DefaultExt = "pktrc";
            this.openFileDialog3.Filter = "PK Trace Files|*.pktrc";
            this.openFileDialog3.Title = "Select a PK Trace File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnStartWeaving);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFile);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnKeyFile);
            this.groupBox1.Controls.Add(this.btnInclude);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 75);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instrument an Assembly";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.btnViewTraces,
            this.btnClearProfile,
            this.toolStripSeparator4,
            this.btnDBTraces,
            this.btnViewTestTraces,
            this.toolStripSeparator1,
            this.btnStartStop,
            this.toolStripSeparator2,
            this.lblServerStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(829, 25);
            this.toolStrip1.TabIndex = 23;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(32, 22);
            this.lblServerStatus.Text = "_____";
            // 
            // btnStartWeaving
            // 
            this.btnStartWeaving.Image = global::CodeProfiler.Properties.Resources.instrument;
            this.btnStartWeaving.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartWeaving.Location = new System.Drawing.Point(655, 43);
            this.btnStartWeaving.Name = "btnStartWeaving";
            this.btnStartWeaving.Size = new System.Drawing.Size(78, 23);
            this.btnStartWeaving.TabIndex = 13;
            this.btnStartWeaving.Text = "&Instrument";
            this.btnStartWeaving.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartWeaving.UseVisualStyleBackColor = true;
            this.btnStartWeaving.Click += new System.EventHandler(this.btnInstrument_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Image = global::CodeProfiler.Properties.Resources.broom;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(739, 43);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "&Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnViewTraces
            // 
            this.btnViewTraces.Image = global::CodeProfiler.Properties.Resources.memory;
            this.btnViewTraces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewTraces.Name = "btnViewTraces";
            this.btnViewTraces.Size = new System.Drawing.Size(89, 22);
            this.btnViewTraces.Text = "View Traces";
            this.btnViewTraces.Click += new System.EventHandler(this.btnViewTraces_Click);
            // 
            // btnClearProfile
            // 
            this.btnClearProfile.Image = global::CodeProfiler.Properties.Resources.eraser__arrow;
            this.btnClearProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearProfile.Name = "btnClearProfile";
            this.btnClearProfile.Size = new System.Drawing.Size(91, 22);
            this.btnClearProfile.Text = "Clear Traces";
            this.btnClearProfile.Click += new System.EventHandler(this.btnClearProfile_Click);
            // 
            // btnDBTraces
            // 
            this.btnDBTraces.Image = ((System.Drawing.Image)(resources.GetObject("btnDBTraces.Image")));
            this.btnDBTraces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDBTraces.Name = "btnDBTraces";
            this.btnDBTraces.Size = new System.Drawing.Size(107, 22);
            this.btnDBTraces.Text = "View DB Traces";
            this.btnDBTraces.Click += new System.EventHandler(this.btnDBTraces_Click);
            // 
            // btnViewTestTraces
            // 
            this.btnViewTestTraces.Image = global::CodeProfiler.Properties.Resources.blue_folder_open_document;
            this.btnViewTestTraces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewTestTraces.Name = "btnViewTestTraces";
            this.btnViewTestTraces.Size = new System.Drawing.Size(105, 22);
            this.btnViewTestTraces.Text = "View Trace File";
            this.btnViewTestTraces.Click += new System.EventHandler(this.btnViewTestTraces_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Image = global::CodeProfiler.Properties.Resources.compile;
            this.btnStartStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(99, 22);
            this.btnStartStop.Text = "Start Profiling";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // commandParametersBindingSource
            // 
            this.commandParametersBindingSource.DataSource = typeof(CodeProfiler.Model.ParametersViewModel);
            // 
            // picCleared
            // 
            this.picCleared.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picCleared.BackgroundImage = global::CodeProfiler.Properties.Resources.gear;
            this.picCleared.Location = new System.Drawing.Point(11, 106);
            this.picCleared.Name = "picCleared";
            this.picCleared.Size = new System.Drawing.Size(16, 16);
            this.picCleared.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCleared.TabIndex = 19;
            this.picCleared.TabStop = false;
            this.picCleared.Visible = false;
            // 
            // picInstrumentIcon
            // 
            this.picInstrumentIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picInstrumentIcon.BackgroundImage = global::CodeProfiler.Properties.Resources.instrument;
            this.picInstrumentIcon.Location = new System.Drawing.Point(11, 106);
            this.picInstrumentIcon.Name = "picInstrumentIcon";
            this.picInstrumentIcon.Size = new System.Drawing.Size(16, 16);
            this.picInstrumentIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picInstrumentIcon.TabIndex = 18;
            this.picInstrumentIcon.TabStop = false;
            this.picInstrumentIcon.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // MainProfiler
            // 
            this.AcceptButton = this.btnStartWeaving;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(829, 131);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picCleared);
            this.Controls.Add(this.picInstrumentIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainProfiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PK Profiler";
            this.Load += new System.EventHandler(this.MainProfiler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commandParametersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCleared)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstrumentIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKeyFile;
        private System.Windows.Forms.BindingSource commandParametersBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnInclude;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox picInstrumentIcon;
        private System.Windows.Forms.PictureBox picCleared;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnViewTraces;
        private System.Windows.Forms.ToolStripButton btnClearProfile;
        private System.Windows.Forms.ToolStripButton btnDBTraces;
        private System.Windows.Forms.ToolStripButton btnViewTestTraces;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnStartStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.Button btnStartWeaving;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripLabel lblServerStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}