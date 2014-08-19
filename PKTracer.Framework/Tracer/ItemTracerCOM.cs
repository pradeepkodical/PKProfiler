using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PKTracer.Framework.Tracer
{
    [ComVisible(true), Guid("A8BFC115-DD83-452a-A903-3E0E85302DA7")]
    public interface _ItemTracerCOM
    {
        void Exception(string assemblyName, string message);
        void SetParameters(string strCSVParameters);
        void Trace(string assemblyName, string methodName);
        void Dispose();
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("7D4B97A7-5371-4a84-BBBC-B58A8A04335A")]
    public class ItemTraceCOM : _ItemTracerCOM, IDisposable
    {
        private ItemTracer internalTracer;
        public void Exception(string assemblyName, string message)
        {
            if (internalTracer != null)
            {
                throw new Exception("Item already in Trace");
            }
            internalTracer = new ExceptionTracer(assemblyName, message);
        }
        public void Trace(string assemblyName, string methodName)
        {
            if (internalTracer != null)
            {
                throw new Exception("Item already in Trace");
            }
            internalTracer = new ItemTracer(assemblyName, methodName);
        }
        public void SetParameters(string strCSVParameters)
        {
            if (internalTracer != null)
            {
                internalTracer.SetParameters(new object[] { strCSVParameters });
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (internalTracer != null)
            {
                internalTracer.Dispose();
            }
        }

        #endregion
    }
}
