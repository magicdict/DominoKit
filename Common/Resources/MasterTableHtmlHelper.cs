using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Enterprise;
using InfraStructure.DataBase;

namespace WebSite
{
    public class MasterTableHtmlHelper
    {
        /// <summary>
        /// 获得用于单选的列表UI
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="dic"></param>
        /// <param name="SelectKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetSingleValue(string FieldName, List<MasterTable> list, string SelectKey)
        {
            string html = string.Empty;
            html = "<select name= \"" + FieldName + "\">" + System.Environment.NewLine;
            foreach (var item in list)
            {
                html += "<option value=\"" + item.Code + "\">" + item.Name + "</option>" + System.Environment.NewLine;
            }
            html += "</select>";
            return new MvcHtmlString(html);
        }
        /// <summary>
        /// 获得用于多选的列表UI
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="dic"></param>
        /// <param name="SelectKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMultiValue(string FieldName, List<MasterTable> list, string[] SelectKey)
        {
            string html = string.Empty;
            foreach (var item in list)
            {
                html += "<input type=\"checkbox\" name=\"" + FieldName + "." + item.Code + "\" />" + item.Name + "<br />" + System.Environment.NewLine;
            }
            return new MvcHtmlString(html);
        }
        /// <summary>
        /// 获得值列表
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<string> GetValueList(string FieldName, FormCollection collection)
        {
            List<string> valueList = new List<string>();
            foreach (var item in collection.AllKeys)
            {
                if (item.StartsWith(FieldName + "."))
                {
                    valueList.Add(item.Substring(FieldName.Length + 1));
                }
            }
            return valueList;
        }
    }
}