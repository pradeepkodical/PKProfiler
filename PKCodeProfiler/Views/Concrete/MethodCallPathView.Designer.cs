namespace PKCodeProfiler.Views.Concrete
{
    partial class MethodCallPathView
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.nodeUserKey = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcUserKey = new Aga.Controls.Tree.TreeColumn();
            this.nodeDepth = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcNodeCounts = new Aga.Controls.Tree.TreeColumn();
            this.nodeMemoryUsage = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcMemoryUseage = new Aga.Controls.Tree.TreeColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.bsTraceGroup = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.nodeAssembly = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcAssembly = new Aga.Controls.Tree.TreeColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeTimeTaken = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.tcTimeTaken = new Aga.Controls.Tree.TreeColumn();
            this.treeView = new Aga.Controls.Tree.TreeViewAdv();
            this.tcMethodName = new Aga.Controls.Tree.TreeColumn();
            this.tcParameters = new Aga.Controls.Tree.TreeColumn();
            this.tcHostName = new Aga.Controls.Tree.TreeColumn();
            this.nodeIconA = new Aga.Controls.Tree.NodeControls.NodeIcon();
            this.nodeMethodCall = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeParameters = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeHostName = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTraceGroup)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(63, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(365, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(84, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(230, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(140, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // nodeUserKey
            // 
            this.nodeUserKey.DataPropertyName = "UserKey";
            this.nodeUserKey.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.nodeUserKey.IncrementalSearchEnabled = true;
            this.nodeUserKey.LeftMargin = 3;
            this.nodeUserKey.ParentColumn = this.tcUserKey;
            // 
            // tcUserKey
            // 
            this.tcUserKey.Header = "User Key";
            this.tcUserKey.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcUserKey.TooltipText = null;
            this.tcUserKey.Width = 80;
            // 
            // nodeDepth
            // 
            this.nodeDepth.DataPropertyName = "NodeCounts";
            this.nodeDepth.Font = new System.Drawing.Font("Courier New", 9.75F);
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
            this.nodeMemoryUsage.Font = new System.Drawing.Font("Courier New", 9.75F);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "User/Host:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Call Path Search Criteria";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTraceGroup, "HostName", true));
            this.textBox3.Location = new System.Drawing.Point(230, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 20);
            this.textBox3.TabIndex = 5;
            // 
            // bsTraceGroup
            // 
            this.bsTraceGroup.DataSource = typeof(PKCodeProfiler.ViewModel.TraceGroupViewModel);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Date Range:";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PKCodeProfiler.Properties.Resources.binocular;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(376, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pktrc";
            this.saveFileDialog1.Filter = "PK Trace Files|*.pktrc";
            // 
            // nodeAssembly
            // 
            this.nodeAssembly.DataPropertyName = "AssemblyName";
            this.nodeAssembly.Font = new System.Drawing.Font("Courier New", 9.75F);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Call Paths";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = global::PKCodeProfiler.Properties.Resources.document_export;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.Location = new System.Drawing.Point(705, 21);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(59, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "E&xport";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PKCodeProfiler.Properties.Resources.funnel__arrow;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(640, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "&Filter";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thread:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(539, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Show Greater than:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ms";
            // 
            // nodeTimeTaken
            // 
            this.nodeTimeTaken.DataPropertyName = "TimeTakenMilliseconds";
            this.nodeTimeTaken.Font = new System.Drawing.Font("Courier New", 9.75F);
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
            // treeView
            // 
            this.treeView.AllowColumnReorder = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.AutoRowHeight = true;
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.Columns.Add(this.tcMethodName);
            this.treeView.Columns.Add(this.tcParameters);
            this.treeView.Columns.Add(this.tcTimeTaken);
            this.treeView.Columns.Add(this.tcAssembly);
            this.treeView.Columns.Add(this.tcMemoryUseage);
            this.treeView.Columns.Add(this.tcNodeCounts);
            this.treeView.Columns.Add(this.tcUserKey);
            this.treeView.Columns.Add(this.tcHostName);
            this.treeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView.DefaultToolTipProvider = null;
            this.treeView.DragDropMarkColor = System.Drawing.Color.Black;
            this.treeView.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.FullRowSelect = true;
            this.treeView.GridLineStyle = ((Aga.Controls.Tree.GridLineStyle)((Aga.Controls.Tree.GridLineStyle.Horizontal | Aga.Controls.Tree.GridLineStyle.Vertical)));
            this.treeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this.treeView.LoadOnDemand = true;
            this.treeView.Location = new System.Drawing.Point(3, 146);
            this.treeView.Model = null;
            this.treeView.Name = "treeView";
            this.treeView.NodeControls.Add(this.nodeIconA);
            this.treeView.NodeControls.Add(this.nodeMethodCall);
            this.treeView.NodeControls.Add(this.nodeParameters);
            this.treeView.NodeControls.Add(this.nodeTimeTaken);
            this.treeView.NodeControls.Add(this.nodeAssembly);
            this.treeView.NodeControls.Add(this.nodeMemoryUsage);
            this.treeView.NodeControls.Add(this.nodeDepth);
            this.treeView.NodeControls.Add(this.nodeUserKey);
            this.treeView.NodeControls.Add(this.nodeHostName);
            this.treeView.SelectedNode = null;
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(770, 300);
            this.treeView.TabIndex = 2;
            this.treeView.UseColumns = true;
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
            // tcHostName
            // 
            this.tcHostName.Header = "Host";
            this.tcHostName.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tcHostName.TooltipText = null;
            this.tcHostName.Width = 70;
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
            this.nodeMethodCall.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeMethodCall.IncrementalSearchEnabled = true;
            this.nodeMethodCall.LeftMargin = 3;
            this.nodeMethodCall.ParentColumn = this.tcMethodName;
            this.nodeMethodCall.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // nodeParameters
            // 
            this.nodeParameters.DataPropertyName = "Parameters";
            this.nodeParameters.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.nodeParameters.IncrementalSearchEnabled = true;
            this.nodeParameters.LeftMargin = 3;
            this.nodeParameters.ParentColumn = this.tcParameters;
            this.nodeParameters.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // nodeHostName
            // 
            this.nodeHostName.DataPropertyName = "HostName";
            this.nodeHostName.IncrementalSearchEnabled = true;
            this.nodeHostName.LeftMargin = 3;
            this.nodeHostName.ParentColumn = this.tcHostName;
            // 
            // MethodCallPathView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.treeView);
            this.Name = "MethodCallPathView";
            this.Size = new System.Drawing.Size(776, 449);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTraceGroup)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeUserKey;
        private Aga.Controls.Tree.TreeColumn tcUserKey;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeDepth;
        private Aga.Controls.Tree.TreeColumn tcNodeCounts;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeMemoryUsage;
        private Aga.Controls.Tree.TreeColumn tcMemoryUseage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.BindingSource bsTraceGroup;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeAssembly;
        private Aga.Controls.Tree.TreeColumn tcAssembly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTimeTaken;
        private Aga.Controls.Tree.TreeColumn tcTimeTaken;
        private Aga.Controls.Tree.TreeViewAdv treeView;
        private Aga.Controls.Tree.TreeColumn tcMethodName;
        private Aga.Controls.Tree.TreeColumn tcParameters;
        private Aga.Controls.Tree.NodeControls.NodeIcon nodeIconA;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeMethodCall;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeParameters;
        private System.Windows.Forms.TextBox textBox3;
        private Aga.Controls.Tree.TreeColumn tcHostName;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeHostName;
    }
}
