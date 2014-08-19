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

using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Services.Abstract;

namespace PKCodeProfiler.Views.Concrete
{
    public partial class TracesView : BaseChildView
    {
        public TracesView()
        {
            InitializeComponent();
        }
        public void SetServices(ITraceServices traceServices)
        {
            this.methodCallPathView1.SetServices(traceServices);
        }        
    }
}
