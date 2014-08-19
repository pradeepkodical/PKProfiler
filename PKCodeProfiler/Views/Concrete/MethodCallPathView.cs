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

using PKCodeProfiler.Model;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Services.Abstract;
using PKCodeProfiler.ViewModel;
using PKTracer.Framework.Utility;

namespace PKCodeProfiler.Views.Concrete
{
    public partial class MethodCallPathView : UserControl
    {
        private TraceGroupViewModel tg;
        private ITraceServices services;
        private BackgroundWorker worker = new BackgroundWorker();

        public MethodCallPathView()
        {
            InitializeComponent();

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public void SetServices(ITraceServices services)
        {
            this.services = services;
            this.LoadData();
        }

        private void LoadData()
        {
            this.tg = services.GetTraceGroupViewModel();                

            this.comboBox1.DataBindings.Add(new Binding("Text", this.bsTraceGroup, "GroupKey", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.DataBindings.Add(new Binding("Text", this.bsTraceGroup, "ThresholdMilliseconds", true));
            this.comboBox1.DataBindings.Add(new Binding("Enabled", this.bsTraceGroup, "IsNotRunning", true, DataSourceUpdateMode.Never));
            this.dateTimePicker1.DataBindings.Add(new Binding("Value", this.bsTraceGroup, "StartDate", true));
            this.dateTimePicker2.DataBindings.Add(new Binding("Value", this.bsTraceGroup, "EndDate", true));
            
            this.bsTraceGroup.DataSource = tg;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tg.IsNotRunning = true;
            SetViewModel(e.Result as TraceTreeNode);
        }

        private void SetViewModel(TraceTreeNode treeNodeViewModel)
        {
            if (treeNodeViewModel != null)
            {
                treeView.BeginUpdate();
                var root = new TreeModel();
                treeView.Model = root;
                root.Nodes.Add(treeNodeViewModel);
                treeView.ExpandAll();
                treeView.EndUpdate();
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var vm = services.GetTraceViewModel(tg);
            e.Result = vm;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
            {
                tg.IsNotRunning = false;
                worker.RunWorkerAsync();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = services.GetTraceList(tg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var list = services.Repository.GetTraceItems(tg);
                    File.WriteAllText(saveFileDialog1.FileName, XmlUtil.SerializeObject(list));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
