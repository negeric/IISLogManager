using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MetroFramework.Forms;

namespace IISLogManager
{
    static class Program
    {
        // defines for commandline output
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(ATTACH_PARENT_PROCESS);
            if (args.Length > 0)
            {
                //Called by TaskScheduler, only do command line
                switch(args[0].ToLower())
                {
                    case "logcleanup":
                        ConsoleCode.LogCleanup();
                        
                        break;

                }
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                Application.Exit();
                //Console.WriteLine("Command Line Running: Arg 1" + args[0]);
            }
            else
            {
                //Launch GUI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
