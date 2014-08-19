using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeProfiler.Model;
using System.Threading;
using CodeProfiler.Services;
using CodeProfiler.Repository;
using LogTracer;

namespace CodeProfiler
{
    public partial class MainProfiler : Form
    {
        ParametersViewModel parameter = new ParametersViewModel();
        IWritableRepository repository;
        TraceServices traceServices;
        TraceServer traceServer;
        public MainProfiler()
        {
            InitializeComponent();
            this.InitializeBindings();

            traceServer = null;

            var repository = new MemoryRepository();
            this.traceServices = new TraceServices(repository);
            this.repository = repository;
            commandParametersBindingSource.DataSource = parameter;

            parameter.ServerStatusChanged += new Action<bool>(parameter_ServerStatusChanged);
        }

        void parameter_ServerStatusChanged(bool serverStatus)
        {
            if (serverStatus)
            {
                StartTheServer();
            }
            else 
            {
                StopTheServer();
            }            
        }

        private void InitializeBindings()
        {
            this.textBox1.DataBindings.Add(new Binding("Text", this.commandParametersBindingSource, "FileName", true));
            this.textBox2.DataBindings.Add(new Binding("Text", this.commandParametersBindingSource, "IncludeClasses", true));
            
            this.textBox4.DataBindings.Add(new Binding("Text", this.commandParametersBindingSource, "StrongKeyFileName", true));

            this.btnStartWeaving.DataBindings.Add(new Binding("Enabled", this.commandParametersBindingSource, "IsFileSelected", true));
            this.btnInclude.DataBindings.Add(new Binding("Enabled", this.commandParametersBindingSource, "IsFileSelected", true));
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                parameter.FileName = openFileDialog1.FileName;
            }
        }

        private void btnKeyFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                parameter.StrongKeyFileName = openFileDialog2.FileName;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            parameter.DecodeParameters = false;            
            parameter.FileName = string.Empty;
            parameter.StrongKeyFileName = string.Empty;
            parameter.IncludeClasses = string.Empty;
            parameter.ExcludeClasses = string.Empty;
            parameter.IsFileSelected = false;            
        }

        private void btnInstrument_Click(object sender, EventArgs e)
        {
            SetMessage("Instrumenting the code...", true, false);

            this.btnStartWeaving.Enabled = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                WeaveTheFile();
                SetMessage("Instrumentation Completed. Re-Start the App", false, false);
            }));
        }

        private void StopTheServer()
        {
            if (traceServer != null)
            {
                using (new ItemTracer("Terminator", "Terminator"))
                {
                    traceServer.StopServer = true;
                }
                traceServer = null;
            }
        }

        private void StartTheServer()
        {
            if (traceServer == null)
            {
                traceServer = new TraceServer();
                traceServer.Received += new Action<LogTracer.TraceItem>((arr) =>
                {
                    this.repository.Add(arr);
                });
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    traceServer.Listen();
                }));
            }               
        }        
                
        private void WeaveTheFile()
        {
            var weaver = new PostWeaverLib.TraceInjector(parameter.GetWeaveParameters());
            weaver.Process();
        }

        private void btnViewTraces_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.SetServices(traceServices);
            form.ShowDialog();            
        }

        private void btnViewTestTraces_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                var testTraceServices = new TraceServices(new TestRepository(openFileDialog3.FileName));
                var form = new MainForm();
                form.SetServices(testTraceServices);
                form.ShowDialog();
            }
        }

        private void btnInclude_Click(object sender, EventArgs e)
        {
            var form = new AssemblyContents();
            form.SetAssemblyPath(parameter.FileName);
            form.SelectedClasses += new Action<List<string>>((list) =>
            {
                parameter.IncludeClasses = String.Join(",", list.ToArray());
            });
            form.ShowDialog();
        }
        
        private void btnExclude_Click(object sender, EventArgs e)
        {
            var form = new AssemblyContents();
            form.SetAssemblyPath(parameter.FileName);
            form.SelectedClasses += new Action<List<string>>((list) =>
            {
                parameter.ExcludeClasses = String.Join(",", list.ToArray());
            });
            form.ShowDialog();
        }

        private void btnClearProfile_Click(object sender, EventArgs e)
        {
            repository.Clear();
            SetMessage("All Trace items in memory cache has been removed", false, true);            
        }
        
        private void MainProfiler_Load(object sender, EventArgs e)
        {            
        }

        private void SetMessage(string strMessage, bool isInstrumenting, bool isClearing)
        {
            if (this.InvokeRequired)
            {
                label1.BeginInvoke(new Action(() => SetMessage(strMessage, isInstrumenting, isClearing)));
            }
            else
            {
                lblStatus.Text = strMessage;
                lblStatus.Visible = true;
                picInstrumentIcon.Visible = isInstrumenting;
                picCleared.Visible = isClearing;
                if (strMessage != "Ready")
                {
                    var worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler((a, b) => Thread.Sleep(5000));
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((a, b) => SetMessage("Ready", false, false));
                    worker.RunWorkerAsync();
                }
            }
        }

        private void btnDBTraces_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.SetServices(new TraceServices(new SQLRepository()));
            form.ShowDialog();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                parameter.ToggleServer();
                btnStartStop.Text = parameter.ServerStatus ? "Stop Profiling" : "Start Profiling";
                lblServerStatus.Text = parameter.ServerStatus ? "Profiling Running" : "Profiling Stopped";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server Status could not be set " + ex.Message);
            }
        }        
    }
}
