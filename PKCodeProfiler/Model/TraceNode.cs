using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKTracer.Framework.Model;

namespace PKCodeProfiler.Model
{
    public class TraceNode
    {
        public TraceItem Begin { get; set; }
        public TraceItem End { get; set; }
        public string Description
        {
            get
            {
                return GetName(Begin);
            }
        }

        public double TimeTakenMilliseconds
        {
            get
            {
                return End.EventDate.Subtract(Begin.EventDate).TotalMilliseconds;
            }
        }

        public string TimeTaken
        {
            get
            {
                DateTime time = DateTime.Today.Add(End.EventDate.Subtract(Begin.EventDate));
                return time.ToString("mm:ss:fff");
            }
        }

        private string GetName(TraceItem item)
        {
            if (item != null)
            {
                var items = item.EventDescription.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length > 1)
                {
                    return string.Format("{0}.{1}",
                    items[0].Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault(),
                    items[1].Split(new char[] { '(' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault());
                }
                return item.EventDescription;
            }
            return string.Empty;
        }
    }
}
