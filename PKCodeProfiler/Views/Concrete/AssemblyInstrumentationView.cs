using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aga.Controls.Tree;
using System.Threading;


using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Services.Abstract;
using PKCodeProfiler.Commands.Abstract;

namespace PKCodeProfiler.Views.Concrete
{
    public partial class AssemblyInstrumentationView : BaseChildView
    {
        public IAssemblyServices AssemblyServices { get; set; }
        public ICommand WeaveCommand { get; set; }
        private ParametersViewModel parameter;
        public ParametersViewModel Parameter
        {
            private get
            {
                return parameter;
            }
            set
            {
                if (parameter != value)
                {
                    parameter = value;
                    parameter.PropertyChanged += new PropertyChangedEventHandler(parameter_PropertyChanged);
                    this.bsParameters.DataSource = parameter;
                }
            }
        }

        public AssemblyInstrumentationView()
        {
            InitializeComponent();
            this.InitializeBindings();            
            this.TabHeader = "Assembly Instrumentation";           
        }

        private void InitializeBindings()
        {
            this.checkBox2.DataBindings.Add(new Binding("Checked", this.bsParameters, "IISReset", true));
            this.checkBox1.DataBindings.Add(new Binding("Checked", this.bsParameters, "DecodeParameters", true));
            this.textBox1.DataBindings.Add(new Binding("Text", this.bsParameters, "FileName", true));
            this.textBox4.DataBindings.Add(new Binding("Text", this.bsParameters, "AssemblySignKeyFile", true));
            this.btnStartWeaving.DataBindings.Add(new Binding("Enabled", this.bsParameters, "IsFileSelected", true));
            this.treeView1.AfterCheck += new TreeViewEventHandler(treeView1_AfterCheck);            
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode tn in e.Node.Nodes)
            {
                tn.Checked = e.Node.Checked;
            }
        }

        private void parameter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FileName")
            {
                if (File.Exists(Parameter.FileName))
                {
                    treeView1.BeginUpdate();
                    treeView1.Nodes.Clear();
                    
                    this.AssemblyServices.CreateClassNamesNodes(Parameter.FileName).ForEach(node => treeView1.Nodes.Add(node));

                    treeView1.ExpandAll();
                    treeView1.EndUpdate();
                }
            }
        }

        private void btnKeyFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Parameter.AssemblySignKeyFile = openFileDialog2.FileName;
            }
        }

        private void btnStartWeaving_Click(object sender, EventArgs e)
        {
            if (!this.bgCodeWeaverTask.IsBusy)
            {
                this.Parameter.IncludeClasses = this.AssemblyServices.GetSelectedClasses(treeView1.Nodes);
                this.bgCodeWeaverTask.RunWorkerAsync();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Parameter.Clear();
        }

        private void btnAssemblyFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Parameter.FileName = openFileDialog1.FileName;
            }
        }

        private void bgCodeWeaverTask_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInstrumentation();            
            this.WeaveCommand.Execute();
            EndInstrumentation();
        }

        private void BeginInstrumentation()
        {
            if (this.InvokeRequired)
            {
                this.lblAssembly.BeginInvoke(new Action(BeginInstrumentation));
            }
            else
            {
                SetMessage("Instrumenting the code...");
                instrumentationPanel.Enabled = false;
            }
        }

        private void EndInstrumentation()
        {
            if (this.InvokeRequired)
            {
                this.lblAssembly.BeginInvoke(new Action(EndInstrumentation));
            }
            else
            {
                SetMessage("Instrumentation Completed. Re-Start the App");            
                instrumentationPanel.Enabled = true;
            }
        }
    }
}
