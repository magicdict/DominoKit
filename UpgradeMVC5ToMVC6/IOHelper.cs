using System.IO;

namespace UpgradeMVC5ToMVC6
{
    public static class IOHelper
    {
        /// <summary>
        /// IsCopy judge by Name,Not FullName!!
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public delegate bool IsCopy(string filename);
        /// <summary>
        /// Copy Folder
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dist"></param>
        public static void CopyFolder(string srcFolder, string distFolder, IsCopy judgeFolder ,IsCopy judgeFile)
        {
            //CopyFile
            foreach (var filename in Directory.GetFiles(srcFolder))
            {
                if (judgeFile == null || judgeFile(new FileInfo(filename).Name)) 
                {
                    File.Copy(filename, distFolder + "\\" + new FileInfo(filename).Name, true);
                }
            }
            foreach (var directname in Directory.GetDirectories(srcFolder))
            {
                if (judgeFolder == null || judgeFolder(new DirectoryInfo(directname).Name))
                {
                    string subDistFolder = distFolder + "\\" + new DirectoryInfo(directname).Name;
                    if (!Directory.Exists(subDistFolder)) Directory.CreateDirectory(subDistFolder);
                    CopyFolder(directname, subDistFolder, judgeFolder, judgeFile);
                }
            }
        }
    }
}
