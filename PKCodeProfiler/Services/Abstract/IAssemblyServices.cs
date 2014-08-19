using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKCodeProfiler.Services.Abstract
{
    public interface IAssemblyServices
    {
        List<TreeNode> CreateClassNamesNodes(string assembly);        
        List<string> GetSelectedClasses(TreeNodeCollection treeNodeCollection);
    }
}
