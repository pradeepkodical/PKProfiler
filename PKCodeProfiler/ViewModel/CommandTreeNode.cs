using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Commands.Abstract;
using System.Windows.Forms;

namespace PKCodeProfiler.ViewModel
{
    public class CommandTreeNode: TreeNode
    {
        public ICommand Command { get; set; }
    }
}
