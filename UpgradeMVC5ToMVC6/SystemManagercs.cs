using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UpgradeMVC5ToMVC6
{
    public static class SystemManager
    {
        /// <summary>
        /// MVC5 Folder
        /// </summary>
        public static string mvc5Root = string.Empty;
        /// <summary>
        /// MVC6 Folder
        /// </summary>
        public static string mvc6Root = string.Empty;

        /// <summary>
        /// Report File Name
        /// </summary>
        public static string ReportName = "Report.txt";
        /// <summary>
        /// Report Full Path
        /// </summary>
        public static string ReportFullPath {
            get {
                return mvc6Root + @"\" + ReportName;
            }
        }
        /// <summary>
        /// Report
        /// </summary>
        public static StreamWriter report = null;

        /// <summary>
        /// Init SystemManager
        /// </summary>
        public static void Init() {
            //Create New Report
            report = new StreamWriter(ReportFullPath);
            Log("Start To Convert");
        }

        public static void Log(string Message) {
            report.WriteLine(Message);
        }

        public static void Terminate() {
            report.Close();
            System.Diagnostics.Process.Start(ReportFullPath);
        }
    }
}
