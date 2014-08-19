namespace PKCodeProfiler.Views.Concrete
{
    partial class TracesView
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
            this.bsTraceGroup = new System.Windows.Forms.BindingSource(this.components);
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
            this.methodCallPathView1 = new PKCodeProfiler.Views.Concrete.MethodCallPathView();
            ((System.ComponentModel.ISupportInitialize)(this.bsTraceGroup)).BeginInit();
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
            // bsTraceGroup
            // 
            this.bsTraceGroup.DataSource = typeof(PKCodeProfiler.ViewModel.TraceGroupViewModel);
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
            // methodCallPathView1
            // 
            this.methodCallPathView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.methodCallPathView1.Location = new System.Drawing.Point(3, 32);
            this.methodCallPathView1.Name = "methodCallPathView1";
            this.methodCallPathView1.Size = new System.Drawing.Size(811, 438);
            this.methodCallPathView1.TabIndex = 2;
            // 
            // FileTracesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.methodCallPathView1);
            this.Name = "FileTracesView";
            this.Controls.SetChildIndex(this.methodCallPathView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsTraceGroup)).EndInit();
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
        private MethodCallPathView methodCallPathView1;
    }
}
