using System.IO;

namespace UpgradeMVC5ToMVC6
{
    public static class MainUpgrade
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        public static void Upgrade() {
            SystemManager.Log("Start To Upgrade Areas");
            if (StructureAnalyze.HasAreas) TransformAreas();
        }

        /// <summary>
        /// Transform Areas
        /// </summary>
        static void TransformAreas()
        {
            //Rescure All File And Copy From MVC5 To MVC6
            //Exclude AreaRegistration Class
            string AreasFolderFullName = StructureAnalyze.RootFolder[StructureAnalyze.strAreas];
            string distAreasFolderFullName = SystemManager.mvc6Root + "\\" + StructureAnalyze.strAreas;
            if (!Directory.Exists(distAreasFolderFullName)) Directory.CreateDirectory(distAreasFolderFullName);
            IOHelper.IsCopy judgeFile = (string x) =>
            {
                //Rule:MVC6 Has No AreaRegistration Class
                bool IsN  = x.EndsWith("AreaRegistration.cs") || x.Equals("web.config");
                return !IsN;
            };
            IOHelper.CopyFolder(AreasFolderFullName, distAreasFolderFullName, null, judgeFile);
            //Modify Controller
            //Target:Areas/SomeArea/Controller/SomeController
            foreach (var SomeAreaFullName in Directory.GetDirectories(distAreasFolderFullName))
            {
                string AreaName = new DirectoryInfo(SomeAreaFullName).Name;
                string ControllerFolderName = SomeAreaFullName + "\\Controllers";
                foreach (var SomeControllerFullName in Directory.GetFiles(ControllerFolderName))
                {
                    ModifyController(SomeControllerFullName, AreaName);
                }
            }
        }

        /// <summary>
        /// Modify Controller
        /// </summary>
        static void ModifyController(string FullFileName,string AreaName) {
            File.Move(FullFileName, FullFileName + ".old"); 
            StreamReader oldFile = new StreamReader(FullFileName + ".old");
            StreamWriter newFile = new StreamWriter(FullFileName);

            //Rule: Add Namespace 
            //using Microsoft.AspNet.Mvc;
            //using Microsoft.AspNet.Http.Core.Collections;
            SystemManager.Log("Add@" + FullFileName + ": using Microsoft.AspNet");
            newFile.WriteLine("using Microsoft.AspNet.Mvc;");
            newFile.WriteLine("using Microsoft.AspNet.Http;");
            newFile.WriteLine("using Microsoft.AspNet.Http.Core.Collections;");
            newFile.WriteLine("using System.Threading.Tasks;");
            while (!oldFile.EndOfStream) {
                string x = oldFile.ReadLine();

                if (x.Contains("System.Web.HttpContext.Current.")) {
                    x = x.Replace("System.Web.HttpContext.Current.", "");
                }

                //AddSomeLines
                if (x.TrimStart().StartsWith("public class ")) {
                    newFile.WriteLine("[Area(\"" + AreaName + "\")]");
                    SystemManager.Log("Add@" + FullFileName + ": " + "[Area(\"" + AreaName + "\")]");
                }
                //SKipSomeLine
                if (x.Trim().Equals("using System.Web.Mvc;")) {
                    SystemManager.Log("Remove@" + FullFileName + ":using System.Web.Mvc;");
                    continue;
                }
                //ModifyLine
                //RULE:Session.Add => HttpContext.Session.SetString(
                if (x.Trim().StartsWith("Session.Add(")) {
                    newFile.WriteLine(@"//" + x);
                    newFile.WriteLine(x.Replace("Session.Add(", "HttpContext.Session.SetString("));
                    SystemManager.Log("Change@" + FullFileName + ":Session Set Mothod");
                    continue;
                }
                //collection
                if (x.Contains("collection.AllKeys")) {
                    newFile.WriteLine(@"//" + x);
                    newFile.WriteLine(x.Replace("AllKeys", "Keys"));
                    SystemManager.Log("Change@" + FullFileName + ":collection.AllKeys => collection.Keys");
                    continue;
                }
                //Files
                if (x.Contains("Request.Files"))
                {
                    newFile.WriteLine(@"//" + x);
                    newFile.WriteLine(x.Replace("Request.Files", "Request.Form.Files"));
                    SystemManager.Log("Change@" + FullFileName + ":Request.Files => Request.Form.Files");
                    continue;
                }

                //Reference Only 
                if (x.Contains("Session[")) {
                    newFile.WriteLine(@"//" + x);
                    newFile.WriteLine(x.Replace("Session[", "HttpContext.Session.GetString(").Replace("]",")"));
                    SystemManager.Log("Change@" + FullFileName + ":Session Get Mothod");
                    continue;
                }

                //TryUpdateModel
                if (x.Contains("TryUpdateModel"))
                {
                    newFile.WriteLine(@"//" + x);
                    newFile.WriteLine(x.Replace("TryUpdateModel(", "bool x = await TryUpdateModelAsync(").Replace(", collection", ""));
                    SystemManager.Log("Change@" + FullFileName + ":TryUpdateModel => TryUpdateModelAsync");
                    continue;
                }

                newFile.WriteLine(x);
            }
            oldFile.Close();
            newFile.Close();
            //File.Delete(FullFileName + ".old");
        }

    }
}
