using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace IISLogManager
{
    class ErrorHandler
    {
        //private static readonly log4net.ILog ErrorLog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog ErrorLog = LogManager.GetLogger("LogFileAppender");
        private static readonly ILog IISLogs = LogManager.GetLogger("IISCleanup");
        private static bool debug = true;
        public static void logError(string t, string e, string c, bool exe = false, Exception ex = null)
        {
            System.Diagnostics.StackFrame callStack = new System.Diagnostics.StackFrame(1, true);
            if (exe && debug)
                ErrorLog.Error(t + " - " + e + " (" + c + ") [" + callStack.GetFileName() + ":" + callStack.GetFileLineNumber() + "]", ex);
            else
                ErrorLog.Error(t + " - " + e + " (" + c + ") [" + callStack.GetFileName() + ":" + callStack.GetFileLineNumber() + "]");
        }
        public static void logInfo(string t, string e, string c, bool exe = false, Exception ex = null)
        {
            System.Diagnostics.StackFrame callStack = new System.Diagnostics.StackFrame(1, true);
            ErrorLog.Info(t + " - " + e + " (" + c + ") [" + callStack.GetFileName() + ":" + callStack.GetFileLineNumber() + "]", ex);
        }
        public static void logDebug(string t, string e, string c, bool exe = false, Exception ex = null)
        {
            if (debug)
            {
                System.Diagnostics.StackFrame callStack = new System.Diagnostics.StackFrame(1, true);
                ErrorLog.Debug(t + " - " + e + " (" + c + ") [" + callStack.GetFileName() + ":" + callStack.GetFileLineNumber() + "]", ex);
            }
        }
        public static void logIISCleanupInfo(string t, string e, bool exe = false, Exception ex = null)
        {
            System.Diagnostics.StackFrame callStack = new System.Diagnostics.StackFrame(1, true);
            IISLogs.Info(t + " - " + e, ex);
        }
        public static void logIISCleanupError(string t, string e, bool exe = false, Exception ex = null)
        {
            System.Diagnostics.StackFrame callStack = new System.Diagnostics.StackFrame(1, true);
            IISLogs.Error(t + " - " + e + " [" + callStack.GetFileName() + ":" + callStack.GetFileLineNumber() + "]", ex);
        }
    }
}
