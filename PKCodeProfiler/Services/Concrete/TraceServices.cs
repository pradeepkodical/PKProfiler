using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using PKCodeProfiler.Model;
using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.Services.Abstract;
using PKTracer.Framework.Tracer;
using PKTracer.Framework.Model;

namespace PKCodeProfiler.Services.Concrete
{
    public class TraceServices: ITraceServices
    {
        public IReadableRepository Repository { get; private set; }
        public TraceServices(IReadableRepository repository)
        {
            this.Repository = repository;
        }
        public List<string> GetTraceList(TraceGroupViewModel tg)
        {
            return this.Repository.GetTraceList(tg);
        }

        public TraceTreeNode GetTraceViewModel(TraceGroupViewModel tg)
        {
            TraceTreeNode vm = null;
            using (new DebugTracer("GetTraceViewModel"))
            {
                var items = this.Repository.GetTraceItems(tg);
                if (items.Count > 0)
                {
                    using (new DebugTracer("FixLooseEnds"))
                    {
                        FixLooseEnds(items);
                    }
                    using (new DebugTracer("CreateTreeNodeViewModel"))
                    {
                        vm = CreateTreeNodeViewModel(items);
                    }
                }
            }
            using (new DebugTracer("FilterThresholds"))
            {
                FilterThresholds(vm, tg);
            }            
            return vm;
        }

        public TraceGroupViewModel GetTraceGroupViewModel()
        {
            return new TraceGroupViewModel
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                HostName = string.Empty,
                UserKey = string.Empty,
                GroupKey = string.Empty
            };
        }

        private void FilterThresholds(TraceTreeNode vm, TraceGroupViewModel tg)
        {
            if (vm != null && tg.ThresholdMilliseconds > 0)
            {
                bool blnRet = false;

                if (vm.TraceNode.TimeTakenMilliseconds < tg.ThresholdMilliseconds)
                {
                    if (HasNoException(vm))
                    {
                        blnRet = vm.Remove();
                    }
                }
                if (!blnRet)
                {
                    for (var i = vm.Nodes.Count - 1; i >= 0; i--)
                    {
                        FilterThresholds(vm.Nodes[i] as TraceTreeNode, tg);
                    }                    
                }                
            }
        }

        private bool HasNoException(TraceTreeNode vm)
        {
            if (vm.TraceNode.Begin.IsException)
            {
                return false;
            }
            foreach (TraceTreeNode node in vm.Nodes)
            {
                if (!HasNoException(node))
                {
                    return false;
                }
            }
            return true;
        }

        private void FixLooseEnds(List<TraceItem> items)
        {
            try
            {
                var stack = new Stack<TraceItem>();
                for (var i = 0; i < items.Count; i++)
                {
                    if (items[i].EventType == "End")
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(items[i]);
                    }
                }

                while (stack.Count > 0)
                {
                    var startItem = stack.Pop();
                    var endItem = new TraceItem
                    {
                        EventDate = items.Max(x => x.EventDate),
                        EventDescription = startItem.EventDescription,
                        EventType = "End",
                        GroupKey = startItem.GroupKey,                        
                        TraceKey = startItem.TraceKey,
                        UserKey = startItem.UserKey,
                        IsException = startItem.IsException
                    };
                    items.Add(endItem);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private List<T> MoveAll<T>(List<T> list, Func<T, bool> where)
        {
            var retList = new List<T>();
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (where(list[i]))
                {
                    retList.Add(list[i]);
                    list.RemoveAt(i);
                }
            }
            retList.Reverse();
            return retList;
        }

        private TraceTreeNode CreateTreeNodeViewModel(List<TraceItem> items)
        {
            var list = new List<NodeModel>();
            var stack = new Stack<TraceItem>();
            int depth = 0;
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].EventType == "End")
                {
                    if (stack.Count > 0)
                    {
                        depth--;
                    
                        var startItem = stack.Pop();
                        var endItem = items[i];
                        var childItem = new NodeModel
                        {
                            Depth = depth,
                            TraceNode = new TraceNode
                            {
                                Begin = startItem,
                                End = endItem
                            }
                        };
                        childItem.Children = MoveAll<NodeModel>(list, x => x.Depth > depth);
                        list.Add(childItem);
                    }
                }
                else
                {
                    depth++;
                    stack.Push(items[i]);
                }
            }
            var itemRoot = list.FirstOrDefault();
            if (list.Count > 1)
            {
                itemRoot = new NodeModel
                {
                    Children = list,
                    TraceNode = new TraceNode
                    {
                        Begin = new TraceItem
                        {
                            EventDescription = "Root"
                        },
                        End = new TraceItem
                        {
                        }
                    }
                };
            }
            
            return ConvertToTreeNodeViewModel(itemRoot);
        }

        private TraceTreeNode ConvertToTreeNodeViewModel(NodeModel bNode)
        {
            var node = new TraceTreeNode
            {
                TraceNode = bNode.TraceNode,
                Text = bNode.TraceNode.Description
            };
            if (bNode.Children != null)
            {
                bNode.Children.ForEach(x =>
                {
                    node.Add(ConvertToTreeNodeViewModel(x));
                });
            }
            return node;
        }        
    }
}
