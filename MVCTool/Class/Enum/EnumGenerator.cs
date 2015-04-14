using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;

namespace DevKit.MVCTool
{
    /// <summary>
    /// 枚举生成器(CSharp,MVC5)
    /// </summary>
    public static class EnumGenerator
    {
        /// <summary>
        /// 项目信息
        /// </summary>
        public static ProjectInfo proinfo;
        /// <summary>
        /// 从Excel读取Model
        /// </summary>
        /// <returns></returns>
        public static void Generate(string ExcelFilename, string SourceCodefilename)
        {
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(ExcelFilename);
            dynamic ExcelSheet = workbook.Sheets(1);
            GenerateEnum(ExcelSheet, SourceCodefilename);
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExcelSheet"></param>
        /// <param name="SourceCodefilename"></param>
        private static void GenerateEnum(dynamic ExcelSheet, string SourceCodefilename)
        {
            StreamWriter codeWriter = new StreamWriter(SourceCodefilename, false);
            StringBuilder code = new StringBuilder();
            //***Start***
            bool IsFlag = false;
            string EnumTypeName = string.Empty;
            EnumTypeName = ExcelSheet.Cells(3, 4).Text;
            IsFlag = !String.IsNullOrEmpty(ExcelSheet.Cells(4, 4).Text);
            int indent = 0;
            char space = " ".ToCharArray()[0];
            var nameSpace = ExcelSheet.Cells(5, 4).Text;
            if (string.IsNullOrEmpty(nameSpace)) nameSpace = proinfo.NameSpace;
            code.AppendLine(new string(space, indent) + "using " + nameSpace + ";");
            code.AppendLine(new string(space, indent) + "using System;");
            code.AppendLine(String.Empty);
            if (IsFlag)
            {
                code.AppendLine(new string(space, indent) + "[Flags]");
            }
            code.AppendLine(new string(space, indent) + "public enum " + EnumTypeName);
            code.AppendLine(new string(space, indent) + "{");

            int seekrow = 8;
            indent += 4;

            int itemOrder = 0;
            while (!String.IsNullOrEmpty(ExcelSheet.Cells(seekrow, 3).Text))
            {
                if (!String.IsNullOrEmpty(ExcelSheet.Cells(seekrow, 4).Text))
                {
                    code.AppendLine(new string(space, indent) + "/// <summary>");
                    code.AppendLine(new string(space, indent) + "/// " + ExcelSheet.Cells(seekrow, 4).Text);
                    code.AppendLine(new string(space, indent) + "/// </summary>");
                    // [EnumDisplayName("AAA")]
                    code.AppendLine(new string(space, indent) + "[EnumDisplayName(\"" + ExcelSheet.Cells(seekrow, 4).Text + "\")]");
                }
                if (IsFlag)
                {
                    //EN = 1,
                    code.AppendLine(new string(space, indent) + ExcelSheet.Cells(seekrow, 3).Text + " = " + Math.Pow(2, itemOrder).ToString() + " ,");
                }
                else
                {
                    code.AppendLine(new string(space, indent) + ExcelSheet.Cells(seekrow, 3).Text +
                                   (String.IsNullOrEmpty(ExcelSheet.Cells(seekrow, 5).Text) ? string.Empty : (" = " + ExcelSheet.Cells(seekrow, 5).Text)) + " ,");
                }
                itemOrder++;
                seekrow++;
                code.AppendLine(String.Empty);
            }
            indent -= 4;
            code.AppendLine(new string(space, indent) + "}");
            //***End***
            codeWriter.Write(code);
            codeWriter.Close();
        }
    }
}
