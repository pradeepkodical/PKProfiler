using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Themes.Abstract;
using PKCodeProfiler.Factory.Abstract;

namespace PKCodeProfiler.Views.Concrete
{
    public partial class ApplicationMainView : Form, IAppMainView
    {
        public IApplicationFactory Factory {get; set;}

        public ApplicationMainView()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var commandTreeNode = e.Node as CommandTreeNode;
            if (commandTreeNode != null && commandTreeNode.Command != null)
            {
                commandTreeNode.Command.Execute();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetMessage(e.Node.ToolTipText);            
        } 
        
        private void ApplicationMainView_Load(object sender, EventArgs e)
        {
            this.Text = string.Format(".NET Profiler - {0}", Application.ProductVersion);            
            treeView1.Nodes.Add(Factory.GetApplicationRootCommand(this));
            treeView1.ExpandAll();
        }        

        public void Add(IChildView view)
        {
            var page = new TabPage(view.TabHeader);
            page.Controls.Add(view.ChildControl);
            tabControl1.TabPages.Add(page);
            view.ChildControl.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = page;
            view.Theme = Factory.GetCurrentTheme();

            view.Close += new Action<IChildView>(view_Close);
            view.OnToggleFullScreen += new Action(view_OnToggleFullScreen);
            view.OnSetMessage += new Action<string>(SetMessage);
        }

        private void view_OnToggleFullScreen()
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void view_Close(IChildView view)
        {
            splitContainer1.Panel1Collapsed = false;
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page.Controls.Contains(view.ChildControl))
                {
                    tabControl1.TabPages.Remove(page);
                    return;
                }
            }
        }
        
        public void SetStatus(string statusMessage)
        {
            if (this.InvokeRequired)
            {
                lblServerStatus.BeginInvoke(new Action(() => SetStatus(statusMessage)));
            }
            else
            {
                lblServerStatus.Text = statusMessage;
            }
        }

        public void SetMessage(string strMessage)
        {
            if (this.InvokeRequired)
            {
                lblStatus.BeginInvoke(new Action(() => SetMessage(strMessage)));
            }
            else
            {
                lblStatus.Text = strMessage;
                lblStatus.Visible = true;
            }
        }                      
    }
}
