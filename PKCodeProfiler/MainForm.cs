using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeProfiler.Services;
using CodeProfiler.Model;
using CodeProfiler.Repository;
using CodeProfiler.Tree.ViewModel;

using Aga.Controls.Tree;
using System.Collections.ObjectModel;
using System.IO;

namespace CodeProfiler
{
    public partial class MainForm : Form
    {
        TraceGroupViewModel tg;
        TraceServices services;
        BackgroundWorker worker = new BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();           

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        
        public void SetServices(TraceServices services)
        {
            this.services = services;
            this.LoadData();
        }

        private void LoadData()
        {
            tg = new TraceGroupViewModel
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                UserKey = string.Empty,
                GroupKey = string.Empty                
            };

            this.comboBox1.DataBindings.Add(new Binding("Text", this.bsTraceGroup, "GroupKey", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.DataBindings.Add(new Binding("Text", this.bsTraceGroup, "ThresholdMilliseconds", true));            
            this.comboBox1.DataBindings.Add(new Binding("Enabled", this.bsTraceGroup, "IsNotRunning", true, DataSourceUpdateMode.Never));
            this.dateTimePicker1.DataBindings.Add(new Binding("Value", this.bsTraceGroup, "StartDate", true));
            this.dateTimePicker2.DataBindings.Add(new Binding("Value", this.bsTraceGroup, "EndDate", true));
            bsTraceGroup.DataSource = tg;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tg.IsNotRunning = true;            
            SetViewModel(e.Result as TreeNodeViewModel);
        }

        private void SetViewModel(TreeNodeViewModel treeNodeViewModel)
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
                    File.WriteAllText(saveFileDialog1.FileName, LogTracer.XmlUtil.SerializeObject(list));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
