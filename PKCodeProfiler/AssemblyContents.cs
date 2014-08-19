using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeProfiler.Services;

namespace CodeProfiler
{
    public partial class AssemblyContents : Form
    {
        public event Action<List<string>> SelectedClasses;
        public AssemblyContents()
        {
            InitializeComponent();
            treeView1.AfterCheck += new TreeViewEventHandler(treeView1_AfterCheck);
        }

        void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode tn in e.Node.Nodes)
            {
                tn.Checked = e.Node.Checked;
            }
        }

        public void SetAssemblyPath(string assembly)
        {
            treeView1.Nodes.Add(AssemblyServices.CreateClassNamesNode(assembly));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var retList = new List<string>();
            PopulateSelected(treeView1.Nodes, retList);
            if (SelectedClasses != null)
            {
                SelectedClasses(retList);
            }
            this.Close();
        }

        private void PopulateSelected(TreeNodeCollection treeNodeCollection, List<string> retList)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Checked && AssemblyServices.IsClass(node.Tag))
                {
                    retList.Add(node.Text);
                }
                PopulateSelected(node.Nodes, retList);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
