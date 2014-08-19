using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Reflection;

using PKTracer.Framework.Model;
using PKTracer.Framework.Client;

namespace PKTracer.Framework.Tracer
{
    public class ItemTracer: IDisposable
    {
        private long memUseage;
        private long sequenceId;
        private string methodName;
        private string key;
        private string userKey;
        private string methodParameters = string.Empty;

        private static string commandLine;
        private string GetUniqueKey()
        {
            if (commandLine == null)
            {
                var process = Process.GetCurrentProcess();
                commandLine = string.Format("PID: {0}) {1}", process.Id, 
                    Environment.CommandLine);
            }

            return string.Format("ThreadId: {0}-{1}",
                    Thread.CurrentThread.ManagedThreadId,
                    commandLine);
        }

        private string GetParameters(IEnumerable parameters, bool decode)
        {
            string strParameters = string.Empty;
            if (!TraceClient.FailedToConnect)
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        if (param != null)
                        {
                            if (IsPrimitive(param.GetType()))
                            {
                                strParameters += param.ToString() + ", ";
                            }
                            else if (IsEnumerable(param.GetType()))
                            {
                                strParameters += "[" + GetParameters(param as IEnumerable, decode) + "], ";
                            }
                            else
                            {
                                if (decode)
                                {
                                    strParameters += GetJson(param) + ", ";
                                }
                                else
                                {
                                    strParameters += param.ToString() + ", ";
                                }
                            }
                        }
                    }
                }
            }
            return strParameters;
        }

        private string GetJson(object param)
        {
            var sb = new StringBuilder();
            try
            {
                sb.Append("{ ");                
                foreach (var prop in param.GetType().GetProperties())
                {
                    if (sb.Length < 255)
                    {
                        if (prop.CanRead)
                        {
                            var gm = prop.GetGetMethod();
                            if (gm != null)
                            {
                                var obj = gm.Invoke(param, new object[0]);
                                sb.AppendFormat("{0} = {1} ,", prop.Name, obj);
                            }
                        }
                    }
                }
                sb.Append(" }");
            }
            catch
            {                
            }
            return sb.ToString();            
        }

        private bool IsPrimitive(Type type)
        {
            return (
                    type.IsPrimitive ||
                    type == typeof(DateTime) ||
                    type == typeof(string));            
        }

        private bool IsEnumerable(Type type)
        {
            if (type != typeof(string))
            {
                return (type.GetInterface("IEnumerable") != null);
            }
            return false;
        }

        public ItemTracer(string assemblyName, string methodName)
        {
            if (!TraceClient.FailedToConnect)
            {
                memUseage = GC.GetTotalMemory(false);
                var ticket = this.GetTicket();

                sequenceId = TraceClient.GetNextId();
                
                key = GetUniqueKey();
                userKey = GetUserKey();
                
                this.methodName = methodName;
                TraceClient.PostAsync(FixBeginTraceItem(new TraceItem
                {
                    AssemblyName = assemblyName,                    
                    TraceOrderBy = TraceClient.GetNextUid(),
                    TraceKey = sequenceId,
                    UserKey = userKey,
                    GroupKey = key,
                    EventType = "Begin",
                    EventDate = DateTime.Now,
                    CurrentTick = DateTime.Now.Ticks,
                    HostName = Environment.MachineName,
                    EventDescription = this.methodName,
                    Ticket = ticket
                }));
            }
        }        

        protected virtual TraceItem FixBeginTraceItem(TraceItem item)
        {
            return item;
        }

        protected virtual TraceItem FixEndTraceItem(TraceItem item)
        {
            return item;
        }

        public void SetParameters(object[] parameters)
        {
            methodParameters = this.GetParameters(parameters, false);            
        }

        public void SetParametersWithDecode(object[] parameters)
        {
            methodParameters = this.GetParameters(parameters, true);
        }

        private string GetTicket()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if(identity.IsAuthenticated)
            {
                var prop = identity.GetType().GetProperty("Ticket");
                if (prop != null)
                {
                    var method = prop.GetGetMethod();
                    if (method != null)
                    {
                        var ticket = method.Invoke(identity, new object[0]);
                        if (ticket != null)
                        {
                            var str = ticket.ToString();
                            if (str.Length > 255)
                            {
                                return str.Substring(0, 255);
                            }
                            return str;
                        }
                    }
                }
            }
            return "TICKET";
        }

        private string GetUserKey()
        {
            return Thread.CurrentPrincipal.Identity.IsAuthenticated ? Thread.CurrentPrincipal.Identity.Name : Environment.UserName;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (!TraceClient.FailedToConnect)
            {
                memUseage = GC.GetTotalMemory(false) - memUseage;

                TraceClient.PostAsync(FixEndTraceItem(new TraceItem
                {
                    TraceOrderBy = TraceClient.GetNextUid(),
                    TraceKey = sequenceId,
                    UserKey = userKey,
                    GroupKey = key,
                    EventType = "End",
                    EventDate = DateTime.Now,
                    CurrentTick = DateTime.Now.Ticks,
                    EventDescription = this.methodName,
                    Parameters = methodParameters,
                    MemoryUsage = memUseage
                }));
            }
        }

        #endregion
    }
}
