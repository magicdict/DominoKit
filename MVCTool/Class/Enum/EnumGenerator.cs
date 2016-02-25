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
        /// 生成枚举
        /// </summary>
        /// <param name="ExcelSheet"></param>
        /// <param name="SourceCodefilename"></param>
        /// <param name="withAttr"></param>
        public static void GenerateEnum(dynamic ExcelSheet, string SourceCodefilename, bool withAttr = false)
        {
            if (ExcelSheet.Cells(1, 1).Text != "E") return;
            StreamWriter codeWriter = new StreamWriter(SourceCodefilename, false);
            StringBuilder code = new StringBuilder();
            //***Start***
            bool IsFlag = false;
            string EnumTypeName = string.Empty;
            EnumTypeName = ExcelSheet.Cells(3, 3).Text;
            IsFlag = !string.IsNullOrEmpty(ExcelSheet.Cells(4, 3).Text);
            int indent = 0;
            char space = " ".ToCharArray()[0];
            var nameSpace = ExcelSheet.Cells(5, 3).Text;
            if (string.IsNullOrEmpty(nameSpace)) nameSpace = proinfo.NameSpace;
            code.AppendLine(new string(space, indent) + "using " + nameSpace + ";");
            code.AppendLine(new string(space, indent) + "using System;");
            code.AppendLine(string.Empty);
            if (IsFlag)
            {
                code.AppendLine(new string(space, indent) + "[Flags]");
            }
            code.AppendLine(new string(space, indent) + "public enum " + EnumTypeName);
            code.AppendLine(new string(space, indent) + "{");

            int seekrow = 8;
            indent += 4;

            int itemOrder = 0;
            const int varname = 2;
            const int displaynameCol = 3;
            const int enumvalue = 4;
            while (!string.IsNullOrEmpty(ExcelSheet.Cells(seekrow, 2).Text))
            {
                if (!string.IsNullOrEmpty(ExcelSheet.Cells(seekrow, displaynameCol).Text))
                {
                    code.AppendLine(new string(space, indent) + "/// <summary>");
                    code.AppendLine(new string(space, indent) + "/// " + ExcelSheet.Cells(seekrow, displaynameCol).Text);
                    code.AppendLine(new string(space, indent) + "/// </summary>");
                    // [EnumDisplayName("AAA")]
                    if (withAttr) code.AppendLine(new string(space, indent) + "[EnumDisplayName(\"" + ExcelSheet.Cells(seekrow, displaynameCol).Text + "\")]");
                }
                if (IsFlag)
                {
                    //EN = 1,
                    code.AppendLine(new string(space, indent) + ExcelSheet.Cells(seekrow, varname).Text + " = " + Math.Pow(2, itemOrder).ToString() + " ,");
                }
                else
                {
                    code.AppendLine(new string(space, indent) + ExcelSheet.Cells(seekrow, varname).Text +
                                   (string.IsNullOrEmpty(ExcelSheet.Cells(seekrow, enumvalue).Text) ? string.Empty : (" = " + ExcelSheet.Cells(seekrow, enumvalue).Text)) + " ,");
                }
                itemOrder++;
                seekrow++;
                code.AppendLine(string.Empty);
            }
            indent -= 4;
            code.AppendLine(new string(space, indent) + "}");
            //***End***
            codeWriter.Write(code);
            codeWriter.Close();
        }
    }
}
