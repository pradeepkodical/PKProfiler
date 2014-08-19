using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PKCodeProfiler.Model
{
    public class NodeModel
    {
        public int Depth { get; set; }
        public List<NodeModel> Children { get; set; }
        public TraceNode TraceNode { get; set; }        
    }    
}
