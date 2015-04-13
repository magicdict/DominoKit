using DevKit.CodeSnippetMgr;
using DevKit.MVCTool;
using System.Windows.Forms;

namespace DevKit
{
    internal static class SystemMonitor
    {
		/// <summary>
		/// 代码片断
		/// </summary>
		public static Common.XmlDataBase<codeSnippet> db = new Common.XmlDataBase<codeSnippet>(SystemMonitor.CodeSnapDBFile);
        /// <summary>
        /// 当前工程
        /// </summary>
        public static ProjectInfo CurrentProject;
        /// <summary>
        /// SnapDB
        /// </summary>
        public static string CodeSnapDBFile = Application.StartupPath + "\\CodeSnap.xml";
    }
}
