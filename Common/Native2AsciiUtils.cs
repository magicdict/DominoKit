using Microsoft.VisualBasic;
using System;
using System.Text;

namespace DevKit.Common
{
    public class Native2AsciiUtils
    {
        /// <summary>
        /// 
        /// </summary>
        private static string PREFIX = "\\u";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string native2Ascii(string str)
        {
            char[] chars = str.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append(char2Ascii(chars[i]));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string char2Ascii(char c)
        {
            if (c > 255)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(PREFIX);
                int code = (c >> 8);

                string tmp = Convert.ToString(code, 16);
                if (tmp.Length == 1)
                {
                    sb.Append("0");
                }
                sb.Append(tmp);
                code = (c & 0xFF);
                tmp = Convert.ToString(code, 16);
                if (tmp.Length == 1)
                {
                    sb.Append("0");
                }
                sb.Append(tmp);
                return sb.ToString();
            }
            else
            {
                return Char.ToString(c);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ascii2Native(string str)
        {
            StringBuilder sb = new StringBuilder();
            int begin = 0;
            int index = str.IndexOf(PREFIX);
            while (index != -1)
            {
                sb.Append(str.Substring(begin, index - begin));
                sb.Append(ascii2Char(str.Substring(index, 6)));
                begin = index + 6;
                index = str.IndexOf(PREFIX, begin);
            }
            sb.Append(str.Substring(begin));
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static char ascii2Char(string str)
        {
            if (str.Length != 6)
            {
                throw new ArgumentException(
                        "Ascii string of a native character must be 6 character.");
            }
            if (!PREFIX.Equals(str.Substring(0, 2)))
            {
                throw new ArgumentException(
                        "Ascii string of a native character must start with \"\\u\".");
            }
            string tmp = str.Substring(2, 2);
            int code = Convert.ToInt16(tmp, 16) << 8;
            tmp = str.Substring(4, 2);
            code += Convert.ToInt16(tmp, 16);
            return (char)code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public static void BatchConvert(string ExcelFilename)
        {
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(ExcelFilename);
            dynamic worksheet = workbook.Sheets(1);
            int row = 5;
            while (!string.IsNullOrEmpty(worksheet.Cells(row,2).Text))
            {
                if (!string.IsNullOrEmpty(worksheet.Cells(row, 3).Text))
                {
                    worksheet.Cells(row, 4).Value = Common.Native2AsciiUtils.native2Ascii(worksheet.Cells(row, 3).Text);
                }
                else
                {
                    worksheet.Cells(row, 3).Value = Common.Native2AsciiUtils.ascii2Native(worksheet.Cells(row, 4).Text);
                }
                row++;
            }
            workbook.Save();
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
        }
    }
}
