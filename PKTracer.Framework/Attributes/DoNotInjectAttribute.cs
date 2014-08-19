using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKTracer.Framework.Attributes
{
    public class DoNotInjectAttribute: Attribute
    {
    }
    public class DoNotTraceAttribute : DoNotInjectAttribute
    {
    }
    public class DoNotPropChangeAttribute : DoNotInjectAttribute
    {
    }
}
