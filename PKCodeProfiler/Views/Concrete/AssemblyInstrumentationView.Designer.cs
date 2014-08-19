namespace PKCodeProfiler.Views.Concrete
{
    partial class AssemblyInstrumentationView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nodeUserKey = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcUserKey = new Aga.Controls.Tree.TreeColumn();
            this.nodeDepth = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcNodeCounts = new Aga.Controls.Tree.TreeColumn();
            this.nodeMemoryUsage = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcMemoryUseage = new Aga.Controls.Tree.TreeColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.nodeAssembly = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcAssembly = new Aga.Controls.Tree.TreeColumn();
            this.nodeTimeTaken = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcTimeTaken = new Aga.Controls.Tree.TreeColumn();
            this.tcMethodName = new Aga.Controls.Tree.TreeColumn();
            this.tcParameters = new Aga.Controls.Tree.TreeColumn();
            this.nodeIconA = new Aga.Controls.Tree.NodeControls.NodeIcon();
            this.nodeMethodCall = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeParameters = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.bsTraceGroup = new System.Windows.Forms.BindingSource(this.components);
            this.btnStartWeaving = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.instrumentationPanel = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.lblAssembly = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnAssemblyFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnKeyFile = new System.Windows.Forms.Button();
            this.bsParameters = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.bgCodeWeaverTask = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.bsTraceGroup)).BeginInit();
            this.instrumentationPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // nodeUserKey
            // 
            this.nodeUserKey.DataPropertyName = "UserKey";
            this.nodeUserKey.IncrementalSearchEnabled = true;
            this.nodeUserKey.LeftMargin = 3;
            this.nodeUserKey.ParentColumn = this.tcUserKey;
            // 
            // tcUserKey
            // 
            this.tcUserKey.Header = "User Key";
            this.tcUserKey.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcUserKey.TooltipText = null;
            // 
            // nodeDepth
            // 
            this.nodeDepth.DataPropertyName = "NodeCounts";
            this.nodeDepth.IncrementalSearchEnabled = true;
            this.nodeDepth.LeftMargin = 3;
            this.nodeDepth.ParentColumn = this.tcNodeCounts;
            this.nodeDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tcNodeCounts
            // 
            this.tcNodeCounts.Header = "Call Depth";
            this.tcNodeCounts.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcNodeCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcNodeCounts.TooltipText = null;
            this.tcNodeCounts.Width = 80;
            // 
            // nodeMemoryUsage
            // 
            this.nodeMemoryUsage.DataPropertyName = "MemoryUseage";
            this.nodeMemoryUsage.IncrementalSearchEnabled = true;
            this.nodeMemoryUsage.LeftMargin = 3;
            this.nodeMemoryUsage.ParentColumn = this.tcMemoryUseage;
            this.nodeMemoryUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tcMemoryUseage
            // 
            this.tcMemoryUseage.Header = "Approx Memory";
            this.tcMemoryUseage.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcMemoryUseage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tcMemoryUseage.TooltipText = null;
            this.tcMemoryUseage.Width = 80;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pktrc";
            this.saveFileDialog1.Filter = "PK Trace Files|*.pktrc";
            // 
            // nodeAssembly
            // 
            this.nodeAssembly.DataPropertyName = "AssemblyName";
            this.nodeAssembly.IncrementalSearchEnabled = true;
            this.nodeAssembly.LeftMargin = 3;
            this.nodeAssembly.ParentColumn = this.tcAssembly;
            this.nodeAssembly.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // tcAssembly
            // 
            this.tcAssembly.Header = "Assembly";
            this.tcAssembly.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcAssembly.TooltipText = null;
            this.tcAssembly.Width = 100;
            // 
            // nodeTimeTaken
            // 
            this.nodeTimeTaken.DataPropertyName = "TimeTakenMilliseconds";
            this.nodeTimeTaken.IncrementalSearchEnabled = true;
            this.nodeTimeTaken.LeftMargin = 3;
            this.nodeTimeTaken.ParentColumn = this.tcTimeTaken;
            this.nodeTimeTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tcTimeTaken
            // 
            this.tcTimeTaken.Header = "Time(ms)";
            this.tcTimeTaken.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcTimeTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tcTimeTaken.TooltipText = null;
            this.tcTimeTaken.Width = 80;
            // 
            // tcMethodName
            // 
            this.tcMethodName.Header = "Method Name";
            this.tcMethodName.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcMethodName.TooltipText = null;
            this.tcMethodName.Width = 300;
            // 
            // tcParameters
            // 
            this.tcParameters.Header = "Parameters";
            this.tcParameters.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcParameters.TooltipText = null;
            this.tcParameters.Width = 100;
            // 
            // nodeIconA
            // 
            this.nodeIconA.DataPropertyName = "Icon";
            this.nodeIconA.LeftMargin = 1;
            this.nodeIconA.ParentColumn = this.tcMethodName;
            this.nodeIconA.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // nodeMethodCall
            // 
            this.nodeMethodCall.DataPropertyName = "Description";
            this.nodeMethodCall.IncrementalSearchEnabled = true;
            this.nodeMethodCall.LeftMargin = 3;
            this.nodeMethodCall.ParentColumn = this.tcMethodName;
            this.nodeMethodCall.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // nodeParameters
            // 
            this.nodeParameters.DataPropertyName = "Parameters";
            this.nodeParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeParameters.IncrementalSearchEnabled = true;
            this.nodeParameters.LeftMargin = 3;
            this.nodeParameters.ParentColumn = this.tcParameters;
            this.nodeParameters.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // bsTraceGroup
            // 
            this.bsTraceGroup.DataSource = typeof(PKCodeProfiler.ViewModel.TraceGroupViewModel);
            // 
            // btnStartWeaving
            // 
            this.btnStartWeaving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartWeaving.Image = global::PKCodeProfiler.Properties.Resources.instrument;
            this.btnStartWeaving.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartWeaving.Location = new System.Drawing.Point(660, 74);
            this.btnStartWeaving.Name = "btnStartWeaving";
            this.btnStartWeaving.Size = new System.Drawing.Size(78, 23);
            this.btnStartWeaving.TabIndex = 7;
            this.btnStartWeaving.Text = "&Instrument";
            this.btnStartWeaving.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartWeaving.UseVisualStyleBackColor = true;
            this.btnStartWeaving.Click += new System.EventHandler(this.btnStartWeaving_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Image = global::PKCodeProfiler.Properties.Resources.broom;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(744, 74);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "&Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // instrumentationPanel
            // 
            this.instrumentationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.instrumentationPanel.Controls.Add(this.checkBox2);
            this.instrumentationPanel.Controls.Add(this.lblAssembly);
            this.instrumentationPanel.Controls.Add(this.groupBox2);
            this.instrumentationPanel.Controls.Add(this.btnClear);
            this.instrumentationPanel.Controls.Add(this.btnStartWeaving);
            this.instrumentationPanel.Controls.Add(this.btnAssemblyFile);
            this.instrumentationPanel.Controls.Add(this.textBox1);
            this.instrumentationPanel.Controls.Add(this.textBox4);
            this.instrumentationPanel.Controls.Add(this.label2);
            this.instrumentationPanel.Controls.Add(this.checkBox1);
            this.instrumentationPanel.Controls.Add(this.btnKeyFile);
            this.instrumentationPanel.Location = new System.Drawing.Point(3, 40);
            this.instrumentationPanel.Name = "instrumentationPanel";
            this.instrumentationPanel.Size = new System.Drawing.Size(811, 430);
            this.instrumentationPanel.TabIndex = 0;
            this.instrumentationPanel.TabStop = false;
            this.instrumentationPanel.Text = "Instrument an Assembly";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(194, 71);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(70, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "IIS Reset";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // lblAssembly
            // 
            this.lblAssembly.AutoSize = true;
            this.lblAssembly.Location = new System.Drawing.Point(9, 22);
            this.lblAssembly.Name = "lblAssembly";
            this.lblAssembly.Size = new System.Drawing.Size(54, 13);
            this.lblAssembly.TabIndex = 0;
            this.lblAssembly.Text = "Assembly:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(6, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(799, 321);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Include These Classes";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(6, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(787, 286);
            this.treeView1.TabIndex = 0;
            // 
            // btnAssemblyFile
            // 
            this.btnAssemblyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssemblyFile.Location = new System.Drawing.Point(775, 17);
            this.btnAssemblyFile.Name = "btnAssemblyFile";
            this.btnAssemblyFile.Size = new System.Drawing.Size(24, 23);
            this.btnAssemblyFile.TabIndex = 2;
            this.btnAssemblyFile.Text = "...";
            this.btnAssemblyFile.UseVisualStyleBackColor = true;
            this.btnAssemblyFile.Click += new System.EventHandler(this.btnAssemblyFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(68, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(701, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(68, 45);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(701, 20);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(68, 71);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Decode Parameters";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnKeyFile
            // 
            this.btnKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeyFile.Location = new System.Drawing.Point(775, 46);
            this.btnKeyFile.Name = "btnKeyFile";
            this.btnKeyFile.Size = new System.Drawing.Size(24, 23);
            this.btnKeyFile.TabIndex = 5;
            this.btnKeyFile.Text = "...";
            this.btnKeyFile.UseVisualStyleBackColor = true;
            this.btnKeyFile.Click += new System.EventHandler(this.btnKeyFile_Click);
            // 
            // bsParameters
            // 
            this.bsParameters.DataSource = typeof(PKCodeProfiler.ViewModel.ParametersViewModel);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.DefaultExt = "pktrc";
            this.openFileDialog3.Filter = "PK Trace Files|*.pktrc";
            this.openFileDialog3.Title = "Select a PK Trace File";
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
            // bgCodeWeaverTask
            // 
            this.bgCodeWeaverTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCodeWeaverTask_DoWork);
            // 
            // AssemblyInstrumentationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.instrumentationPanel);
            this.Name = "AssemblyInstrumentationView";
            this.Controls.SetChildIndex(this.instrumentationPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsTraceGroup)).EndInit();
            this.instrumentationPanel.ResumeLayout(false);
            this.instrumentationPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeUserKey;
        private Aga.Controls.Tree.TreeColumn tcUserKey;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeDepth;
        private Aga.Controls.Tree.TreeColumn tcNodeCounts;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeMemoryUsage;
        private Aga.Controls.Tree.TreeColumn tcMemoryUseage;
        private System.Windows.Forms.BindingSource bsTraceGroup;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeAssembly;
        private Aga.Controls.Tree.TreeColumn tcAssembly;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTimeTaken;
        private Aga.Controls.Tree.TreeColumn tcTimeTaken;
        private Aga.Controls.Tree.TreeColumn tcMethodName;
        private Aga.Controls.Tree.TreeColumn tcParameters;
        private Aga.Controls.Tree.NodeControls.NodeIcon nodeIconA;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeMethodCall;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeParameters;
        private System.Windows.Forms.Button btnStartWeaving;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox instrumentationPanel;        
        private System.Windows.Forms.Button btnAssemblyFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource bsParameters;
        private System.Windows.Forms.Button btnKeyFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblAssembly;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.ComponentModel.BackgroundWorker bgCodeWeaverTask;
    }
}
