using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using PKCodeProfiler.Services.Abstract;

namespace PKCodeProfiler.Services.Concrete
{
    public class AssemblyServices : IAssemblyServices
    {
        public List<TreeNode> CreateClassNamesNodes(string assembly)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            tempPath += Path.GetExtension(assembly);
            File.Copy(assembly, tempPath);
            var asm = Assembly.LoadFile(tempPath);
            var retList = new List<TreeNode>();
            asm.GetTypes()
                .OrderBy(x => x.Namespace)
                .Select(x => x.Namespace)
                .Distinct()
                .Select(x => new TreeNode(x) { Tag = "Namespace"})
                .ToList()
                .ForEach(x => retList.Add(x));
            foreach (TreeNode node in retList)
            {
                asm.GetTypes()
                    .Where(x => x.Namespace == node.Text)
                    .OrderBy(x => x.FullName)
                    .ToList()
                    .ForEach(x => {
                        node.Nodes.Add(new TreeNode(x.FullName) { Tag = "Class"});
                });           
            }
            return retList;
        }

        private bool IsClass(object className)
        {
            return className == "Class";
        }

        public List<string> GetSelectedClasses(TreeNodeCollection treeNodeCollection)
        {
            var list = new List<string>();
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Checked && IsClass(node.Tag))
                {
                    list.Add(node.Text);
                }
                if (node.Nodes.Count > 0)
                {
                    var childList = GetSelectedClasses(node.Nodes);
                    list.AddRange(childList);
                }
            }
            return list;
        }
    }
}
