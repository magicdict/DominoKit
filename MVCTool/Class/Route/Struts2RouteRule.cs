using Microsoft.VisualBasic;
using System;
using System.Xml;

namespace DevKit.MVCTool
{
    /// <summary>
    /// Route (Struts2)
    /// </summary>
    internal static class Struts2RouteRule
    {
        internal static void GenerateRouteXml(string ExcelFilename, string XMLfilename, string PackageName)
        {
            if (String.IsNullOrEmpty(ExcelFilename))
            {
                ExcelFilename = Common.Utility.PickFile(Common.Utility.FileDialogMode.Open, Common.Utility.XlsxFilter);
            }
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Open(ExcelFilename);
            dynamic worksheet = workbook.Sheets(1);
            int seekrow = 8;
            XmlDocument struts = new XmlDocument();
            XmlNode strutsRoot = struts.CreateElement("struts");
            XmlNode package = struts.CreateElement("package");
            ((XmlElement)package).SetAttribute("name", PackageName);
            ((XmlElement)package).SetAttribute("extends", "struts-default");
            XmlNode action = null;
            while (!String.IsNullOrEmpty(worksheet.Cells(seekrow, 3).Text) || !String.IsNullOrEmpty(worksheet.Cells(seekrow, 5).Text))
            {
                //ActionName或者Result不为空
                if (!String.IsNullOrEmpty(worksheet.Cells(seekrow, 3).Text))
                {
                    if (action != null)
                    {
                        package.AppendChild(action);
                    }
                    action = struts.CreateElement("action");
                    ((XmlElement)action).SetAttribute("name", (worksheet.Cells(seekrow, 3).Text));
                    ((XmlElement)action).SetAttribute("class", (worksheet.Cells(seekrow, 4).Text));
                }
                else
                {
                    XmlNode result = struts.CreateElement("result");
                    ((XmlElement)action).SetAttribute("name", (worksheet.Cells(seekrow, 5).Text));
                    result.InnerText = worksheet.Cells(seekrow, 6).Text;
                    action.AppendChild(result);
                }
                seekrow++;
            }
            package.AppendChild(action);
            strutsRoot.AppendChild(package);
            struts.AppendChild(strutsRoot);
            struts.Save(XMLfilename);
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
        }
    }
}
