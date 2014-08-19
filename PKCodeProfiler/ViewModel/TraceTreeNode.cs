using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Model;
using Aga.Controls.Tree;
using System.Collections;
using System.Drawing;

namespace PKCodeProfiler.ViewModel
{
    public class TraceTreeNode : Node
    {
        public Image Icon
        {
            get 
            {
                return this.TraceNode.Begin.IsException ?
                    PKCodeProfiler.Properties.Resources.Exception :
                    PKCodeProfiler.Properties.Resources.Method;
            }
        }
        public string MemoryUseage 
        {
            get 
            {
                if (this.TraceNode.End.MemoryUsage > 0)
                {
                    return string.Format("{0} KB", this.TraceNode.End.MemoryUsage / 1000.0);
                }
                else
                {
                    return "GC";
                }
            }

        }
        public string AssemblyName 
        {
            get
            {
                return this.TraceNode.Begin.AssemblyName;
            }
        }

        public string Description
        {
            get
            {
                return this.TraceNode.Description;
            }
        }

        public string TimeTakenMilliseconds
        {
            get
            {
                return this.TraceNode.TimeTakenMilliseconds.ToString("F");
            }
        }

        public int NodeCounts 
        {
            get
            {
                return this.Nodes.Count;
            }
        }

        public string Exception
        {
            get
            {
                return this.TraceNode.Begin.IsException?"Exception":"";
            }
        }

        public string UserKey
        {
            get
            {
                return this.TraceNode.Begin.UserKey;
            }
        }        

        public string Parameters
        {
            get
            {
                return this.TraceNode.End.Parameters;
            }
        }

        public string HostName 
        {
            get
            {
                return this.TraceNode.Begin.HostName;
            }
        }

        public override bool IsLeaf
        {
            get
            {
                return this.Nodes.Count == 0;
            }
        }

        public TraceNode TraceNode { get; set; }
        
        internal void Add(TraceTreeNode child)
        {
            this.Nodes.Add(child);
            child.Parent = this;
        }

        internal bool Remove()
        {
            if (this.Parent != null)
            {
                this.Parent.Nodes.Remove(this);
                return true;
            }
            return false;
        }
    }
}
