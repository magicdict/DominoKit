using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UpgradeMVC5ToMVC6
{
    /// <summary>
    /// Analyze MVC5 Sturecture
    /// </summary>
    static class StructureAnalyze
    {
        /// <summary>
        /// FolderName of Areas
        /// </summary>
        public const string strAreas = "Areas";

        public const string strFilter = "Filter";

        /// <summary>
        /// Top Level Folder
        /// </summary>
        public static Dictionary<string,string> RootFolder = new Dictionary<string, string>();
        /// <summary>
        /// Has Areas
        /// </summary>
        public static bool HasAreas {
            get {
                return RootFolder.ContainsKey(strAreas);
            }
        }
        /// <summary>
        /// Has Filter
        /// </summary>
        public static bool HasFilter {
            get
            {
                return RootFolder.ContainsKey(strFilter);
            }
        }

        /// <summary>
        /// Analyze 
        /// </summary>
        public static void Analyze() {
            //Get Top Level Folder List
            foreach (var topLevelFolder in Directory.GetDirectories(SystemManager.mvc5Root))
            {
                string folderName = new FileInfo(topLevelFolder).Name;
                RootFolder.Add(folderName, topLevelFolder);
                SystemManager.Log("topLevelFolder:" + folderName);
            }
            AppendReport();
        }
        /// <summary>
        /// Print Info 
        /// </summary>
        static void AppendReport() {
            SystemManager.Log("Areas:" + HasAreas);
            SystemManager.Log("Filter:" + HasFilter);
        }
    }
}
