using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevKit.MVCTool
{
    public static class ViewerGenerator
    {
        /// <summary>
        /// 生成C#Viewer
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        public static void GenerateCSharp(string filename, ModelInfo model,List<ModelItem> ModelItems)
        {
            StreamWriter codeWriter = new StreamWriter(filename, false,Encoding.Unicode);
            StringBuilder code = new StringBuilder();
            code.Append(GernerateHeader(model.CollectionName));
            code.AppendLine("@using (Html.BeginForm())");
            //nest open @1
            code.AppendLine("{");
            code.AppendLine("@Html.AntiForgeryToken()");
            //nest open @2
            code.AppendLine("<div class=\"form-horizontal\">");
            foreach (ModelItem item in ModelItems)
            {
                code.AppendLine("<div class=\"form-group\">");
                code.AppendLine("@Html.LabelFor(model => model." + item.VarName + ", new { @class = \"control-label col-md-2\" })");
                code.AppendLine("<div class=\"col-md-10\">");

                //根据不同类型生成不同控件
                switch (item.MetaType)
                {
                    case "日期":
                        code.Append(GenerateDateTime(item.VarName));
                        break;
                    case "辅助表":
                        code.Append(GenerateMaster(item.VarName, item.EnumOrMasterType, item.IsList));
                        break;
                    case "辅助评价表":
                        if (item.IsList)
                        {
                            code.Append(GenerateMultiGradeItem(item.VarName));
                        }
                        break;
                    case "布尔值":
                        code.Append(GenerateBoolean(item.VarName));
                        break;
                    default:
                        code.Append(GenerateEditor(item.VarName));
                        break;
                }
                code.AppendLine("@Html.ValidationMessageFor(model => model." + item.VarName + ", \"\", new { @class = \"text-danger\" })");
                code.AppendLine("</div>");
                code.AppendLine("</div>");
                code.AppendLine(string.Empty);
            }
            //SaveArea
            code.Append(SaveArea());
            //nest close @2
            code.AppendLine("</div>");
            //nest close @1
            code.AppendLine("}");
            codeWriter.Write(code);
            codeWriter.Close();
        }

        /// <summary>
        /// 标题
        /// </summary>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        private static StringBuilder GernerateHeader(string ModelName)
        {
            StringBuilder cshtml = new StringBuilder();
            cshtml.AppendLine("@model " + ModelName);
            cshtml.AppendLine("@{");
            cshtml.AppendLine("if (Model.Code == ConstHelper.NewRecordCode)");
            cshtml.AppendLine("{");
            cshtml.AppendLine("ViewBag.Title = \"创建\" + " + ModelName + ".MvcTitle;");
            cshtml.AppendLine("}");
            cshtml.AppendLine("else");
            cshtml.AppendLine("{");
            cshtml.AppendLine("ViewBag.Title = \"编辑\" + " + ModelName + ".MvcTitle;");
            cshtml.AppendLine("}");
            cshtml.AppendLine("Layout = \"~/Views/Shared/_DashBoardForMin.cshtml\";");
            cshtml.AppendLine("}");
            return cshtml;
        }

        /// <summary>
        /// 生成日期控件
        /// </summary>
        /// <returns></returns>
        private static StringBuilder GenerateDateTime(string ItemName)
        {
            StringBuilder cshtml = new StringBuilder();
            cshtml.AppendLine("@HtmlUIHelper.GetDatePicker(\"" + ItemName + "\", Model." + ItemName + ")");
            return cshtml;
        }

        /// <summary>
        /// 生成布尔值控件
        /// </summary>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        private static StringBuilder GenerateBoolean(string ItemName)
        {
            StringBuilder cshtml = new StringBuilder();
            cshtml.AppendLine("@HtmlUIHelper.GetMVCCheckBox(\"\",\"" + ItemName + "\", Model." + ItemName + ")");
            return cshtml;
        }

        /// <summary>
        /// 生成MasterTableWithGrade
        /// </summary>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        private static StringBuilder GenerateMultiGradeItem(string ModelName)
        {
            StringBuilder cshtml = new StringBuilder();
            string ViewBag = "ViewBag." + ModelName;
            cshtml.AppendLine("@HtmlUIHelper.GetMultiValueWithGradeUI(\"" + ModelName + "\", " + ViewBag + ", Model." + ModelName + ")");
            return cshtml;
        }

        /// <summary>
        /// 生成MasterTable
        /// </summary>
        /// <param name="ModelName"></param>
        /// <param name="MasterTableName"></param>
        /// <param name="IsList"></param>
        /// <returns></returns>
        private static StringBuilder GenerateMaster(string ModelName, string MasterTableName, bool IsList)
        {
            StringBuilder cshtml = new StringBuilder();
            string ViewBag = "ViewBag." + MasterTableName.Substring(2) + "List";
            if (IsList)
            {
                cshtml.AppendLine("@(HtmlUIHelper.GetMultiValueUI<" + MasterTableName + ">(\"" + ModelName + "\", " + ViewBag + ", Model." + ModelName + "))");
            }
            else
            {
                cshtml.AppendLine("@(HtmlUIHelper.GetSingleValueUI<" + MasterTableName + ">(\"" + ModelName + "\", " + ViewBag + ", Model." + ModelName + "))");
            }
            return cshtml;
        }

        /// <summary>
        /// 生成日期控件
        /// </summary>
        /// <returns></returns>
        private static StringBuilder GenerateEditor(string ItemName)
        {
            StringBuilder cshtml = new StringBuilder();
            cshtml.AppendLine("@Html.EditorFor(model => model." + ItemName + ", new { htmlAttributes = new { @class = \"form-control\" } })");
            return cshtml;
        }

        /// <summary>
        /// 保存区域
        /// </summary>
        /// <returns></returns>
        private static StringBuilder SaveArea()
        {
            StringBuilder cshtml = new StringBuilder();
            cshtml.AppendLine("<div class=\"form-group\">");
            cshtml.AppendLine("<div class=\"col-md-offset-2 col-md-10\">");
            cshtml.AppendLine(" @if (Model.Code == ConstHelper.NewRecordCode)");
            cshtml.AppendLine("{");
            cshtml.AppendLine("<input type=\"submit\" value=\"创建\" class=\"btn btn-success\" style=\"width:120px\"/>");
            cshtml.AppendLine("}");
            cshtml.AppendLine("else");
            cshtml.AppendLine("{");
            cshtml.AppendLine("<input type=\"submit\" value=\"保存\" class=\"btn btn-success\" style=\"width:120px\" />");
            cshtml.AppendLine("}");
            cshtml.AppendLine("@Html.ActionLink(\"返回列表\", \"Index\", new { }, new { @class = \"btn btn-default\", style = \"width:120px\" })");
            cshtml.AppendLine("</div>");
            cshtml.AppendLine("</div>");
            return cshtml;
        }
    }
}
