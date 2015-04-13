using BussinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public static class HtmlUIHelper
    {
        #region Color

        /// <summary>
        ///     获取BootStrap标准情景色
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="selectType"></param>
        /// <returns></returns>
        public static MvcHtmlString GetTableCellColorPick(string FieldName, WarningType selectType)
        {
            var html = string.Empty;
            html = "<table class=\"table\">" + Environment.NewLine;
            foreach (WarningType value in Enum.GetValues(typeof(WarningType)))
            {
                if (value != WarningType.primary)
                {
                    html += "<tr>" + Environment.NewLine;
                    if (value != WarningType.none)
                    {
                        html += "    <td class=\"" + value + "\">" + Environment.NewLine;
                    }
                    else
                    {
                        html += "    <td>" + Environment.NewLine;
                    }
                    html += "        <input type=\"radio\" id=\"" + FieldName + "\" name=\"" + FieldName + "\" " +
                            (selectType.GetHashCode() == value.GetHashCode() ? "checked" : "") + " value=\"" +
                            value.GetHashCode() + "\"/> " + Environment.NewLine;
                    html += value + Environment.NewLine;
                    html += "    </td>" + Environment.NewLine;
                    html += "</tr>" + Environment.NewLine;
                }
            }
            html += "</table>" + Environment.NewLine;
            return new MvcHtmlString(html);
        }

        #endregion

        #region Controller
        public static MvcHtmlString NoEncodeActionLink(this HtmlHelper htmlHelper,
                                     string text, string title, string action,
                                     string controller,
                                     object routeValues = null,
                                     object htmlAttributes = null)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("a");
            builder.InnerHtml = text;
            builder.Attributes["title"] = title;
            builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));

            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString NoEncodeActionLinkForIcon(this HtmlHelper htmlHelper,
                             string glyphiconName, string title, string action,
                             string controller,
                             object routeValues = null,
                             object htmlAttributes = null)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("a");
            builder.InnerHtml = "<span class=\"glyphicon glyphicon-" + glyphiconName + "\"></span>&nbsp;" + title;
            builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
            return MvcHtmlString.Create(builder.ToString());
        }
        /// <summary>
        /// GetInput TagBuilder
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="Type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetInput(string FieldName, string Type, string value)
        {
            var orgHtml =
                "<input class=\"form-control text-box single-line\"  id=\"%FieldName%\" name=\"%FieldName%\" type=\"%Type%\" value=\"%value%\" />";
            orgHtml = orgHtml.Replace("%FieldName%", FieldName);
            orgHtml = orgHtml.Replace("%Type%", Type);
            orgHtml = orgHtml.Replace("%value%", value);
            return orgHtml;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public static MvcHtmlString GetDatePicker(string FieldName)
        {
            string strDate = "<input style=\"width:80%;width:240px;\" class=\"form-control form_date\" type=\"text\" id=\"@FIELD@\" name=\"@FIELD@\" />";
            strDate = strDate.Replace("@FIELD@", FieldName) + System.Environment.NewLine;
            strDate = "<div class=\"input-group\">" + System.Environment.NewLine + strDate + "</div>" + System.Environment.NewLine;

            return new MvcHtmlString(strDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static MvcHtmlString GetDatePicker(string FieldName, DateTime Default)
        {
            var strDate = "<input style=\"width:80%;width:240px;\" class=\"form-control form_date\" type=\"text\" id=\"@FIELD@\" name=\"@FIELD@\" value=\"@VALUE@\" />";
            strDate = strDate.Replace("@FIELD@", FieldName);
            strDate = strDate.Replace("@VALUE@", Default.ToString("yyyy-MM-dd"));
            strDate = "<div class=\"input-group\">" + System.Environment.NewLine + strDate + "</div>" + System.Environment.NewLine;
            return new MvcHtmlString(strDate);
        }
        /// <summary>
        /// 这里是普通的CheckBox
        /// </summary>
        /// <param name="Display"></param>
        /// <param name="FieldName"></param>
        /// <param name="Ischecked"></param>
        /// <param name="WithBr"></param>
        /// <returns></returns>
        public static string GetCheckBox(string Display, string FieldName, bool Ischecked, bool WithBr = true)
        {
            var html = string.Empty;
            if (Ischecked)
            {
                html += "<input checked type=\"checkbox\" name=\"" + FieldName + "\" id=\"" + FieldName + "\" />" + Display +
                        (WithBr ? "<br />" : string.Empty) + Environment.NewLine;
            }
            else
            {
                html += "<input type=\"checkbox\" name=\"" + FieldName + "\" id=\"" + FieldName + "\" />" + Display +
                        (WithBr ? "<br />" : string.Empty) + Environment.NewLine;
            }
            return html;
        }
        /// <summary>
        /// 这里是MVC的CheckBox
        /// </summary>
        /// <param name="Display"></param>
        /// <param name="FieldName"></param>
        /// <param name="Ischecked"></param>
        /// <param name="WithBr"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMVCCheckBox(string Display, string FieldName, bool Ischecked, bool WithBr = true)
        {
            //CheckBox如果选中的话，则值是 on 
            //但是这样的话，MVC则认为 on 不是一个正确的值，在UpdateModel的时候会出错
            //MS的做法如下，一个CheckBox的值是true，同时还有一个hidden的值为false的项目

            var html = string.Empty;
            if (Ischecked)
            {
                html += "<input checked type=\"checkbox\" name=\"" + FieldName + "\" id=\"" + FieldName + "\" value=\"true\" />" + Display +
                        (WithBr ? "<br />" : string.Empty) + Environment.NewLine;
            }
            else
            {
                html += "<input type=\"checkbox\" name=\"" + FieldName + "\" id=\"" + FieldName + "\"  value=\"true\" />" + Display +
                        (WithBr ? "<br />" : string.Empty) + Environment.NewLine;
            }
            html += "<input name=\"" + FieldName + "\" type=\"hidden\" value=\"false\" />";
            return MvcHtmlString.Create(html);
        }

        /// <summary>
        /// 获得标题
        /// </summary>
        /// <param name="strTitle"></param>
        /// <returns></returns>
        public static MvcHtmlString GetTitle(string strTitle, string strType = "info")
        {
            var html = string.Empty;
            html += "<div class=\"alert alert-" + strType + "\" >" + Environment.NewLine;
            html += "<strong>" + strTitle + "</strong>" + Environment.NewLine;
            html += "</div>" + Environment.NewLine;
            return new MvcHtmlString(html);
        }
        /// <summary>
        /// 限制宽度的标题
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strType"></param>
        /// <param name="Width"></param>
        /// <returns></returns>
        public static MvcHtmlString GetTitleWidth(string strTitle, string strType = "info", int Width = 200)
        {
            var html = "<div style=\"width:" + Width.ToString() + "px;height:30px;\">" + Environment.NewLine;
            html += "<div class=\"alert alert-" + strType + "\" >" + Environment.NewLine;
            html += strTitle + Environment.NewLine;
            html += "</div>" + Environment.NewLine;
            html += "</div>" + Environment.NewLine;
            return new MvcHtmlString(html);
        }
        #endregion

        #region Filter

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="list"></param>
        /// <param name="SelectKey"></param>
        /// <param name="IsOrMode"></param>
        /// <returns></returns>
        public static MvcHtmlString GetFilterItemListUI<T>(FilterItemList filter, List<T> list, List<string> SelectKey,
            bool IsOrMode = false) where T : MasterTable
        {
            var html = string.Empty;
            html += GetCheckBox("启用", "IsActive." + filter.FieldName, filter.IsActive, false);
            if (!IsOrMode)
            {
                html += GetCheckBox("并且（同时满足条件）", "JoinWithAnd." + filter.FieldName, filter.JoinWithAnd);
            }
            else
            {
                html += "<br />" + Environment.NewLine;
            }
            html += "<br />" + Environment.NewLine;
            //Add Itemlist
            if (list != null && SelectKey != null)
            {
                if (SelectKey.Count != 0)
                {
                    html += GetMultiValueUI(filter.FieldName, list, SelectKey);
                }
                else
                {
                    html += GetMultiValueUI(filter.FieldName, list);
                }
            }
            return new MvcHtmlString(html);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="list"></param>
        /// <param name="SelectKey"></param>
        /// <param name="IsOrMode"></param>
        /// <returns></returns>
        public static MvcHtmlString GetFilterItemWithGradeListUI<T>(FilterItemWithGradeList filter, List<T> list, List<ItemWithGrade> SelectKey, bool IsOrMode = false) where T : MasterTable
        {
            var html = string.Empty;
            html += GetCheckBox("启用", "IsActive." + filter.FieldName, filter.IsActive, false);
            if (!IsOrMode)
            {
                html += GetCheckBox("并且（同时满足条件）", "JoinWithAnd." + filter.FieldName, filter.JoinWithAnd);
            }
            else
            {
                html += "<br />" + Environment.NewLine;
            }
            html += "<br />" + Environment.NewLine;
            if (SelectKey.Count != 0)
            {
                html += GetMultiValueWithGradeUI(filter.FieldName, list, SelectKey);
            }
            else
            {
                html += GetMultiValueWithGradeUI(filter.FieldName, list);
            }
            return new MvcHtmlString(html);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static MvcHtmlString GetFilterItemWithInDaysUI(FilterItemDateInDays filter)
        {
            var html = string.Empty;
            html += GetCheckBox("启用", "IsActive." + filter.FieldName, filter.IsActive, false);
            html += "<br />" + Environment.NewLine;
            html += "<br />" + Environment.NewLine;
            html += "距离天数：" + Environment.NewLine;
            html += GetInput(filter.FieldName + ".Days", "number", filter.Days.ToString()) + Environment.NewLine;
            html += "<br />" + Environment.NewLine;
            html += "基准日期：" + Environment.NewLine;
            html += GetDatePicker(filter.FieldName + ".BaseDate", filter.BaseDate) + Environment.NewLine;
            return new MvcHtmlString(html);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="Days"></param>
        /// <returns></returns>
        public static MvcHtmlString GetFilterItemDateFromToUI(FilterItemDateFromTo filter, int Days = 0)
        {
            var html = string.Empty;
            html += GetCheckBox("启用", "IsActive." + filter.FieldName, filter.IsActive, true);
            html += "<br />" + Environment.NewLine;
            html += "开始日期：";
            html += GetDatePicker(filter.FieldName + ".From", filter.From);
            html += "终了日期：";
            html += GetDatePicker(filter.FieldName + ".To", filter.To);
            return new MvcHtmlString(html);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static MvcHtmlString GetFilterItemBooleanUI(FilterItemBoolean filter)
        {
            var html = string.Empty;
            html += GetCheckBox("启用", "IsActive." + filter.FieldName, filter.IsActive, true);
            html += GetCheckBox("是/否", "YesOrNo." + filter.FieldName, filter.YesOrNo, true);
            return new MvcHtmlString(html);
        }

        #endregion

        #region Picker

        /// <summary>
        ///     获得用于单选的列表UI
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="dic"></param>
        /// <param name="SelectKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetSingleValueUI<T>(string FieldName, List<T> list, string SelectKey = "")
            where T : MasterTable
        {
            //List<MasterTable子类> 无法 变成List<MasterTable> 所以这里只能用泛型来过渡
            var html = string.Empty;
            if (typeof(T) != typeof(M_Skill))
            {
                list.Sort((x, y) => { return x.Rank - y.Rank; });
            }

            //TODO:如果这里没有下面的属性，自动检查功能将失效
            //html = "<select data-val=\"true\" data-val-required=\"xxxx 字段是必需的。\"  
            //         class = \"form-control\" name= \"" + FieldName + "\" id= \"" + FieldName + "\" >" + Environment.NewLine; 
            //html += "<option value=\"\" >未选择</option>" + Environment.NewLine;

            html = "<select class = \"form-control\" name= \"" + FieldName + "\" id= \"" + FieldName + "\" >" + Environment.NewLine;
            html += "<option value=\"" + MasterTable.UnKnownCode + "\">未选择</option>" + Environment.NewLine;
            foreach (var item in list)
            {
                if (item.Code == SelectKey)
                {
                    html += "<option selected value=\"" + item.Code + "\">" + item.Name +
                            ((string.IsNullOrEmpty(item.Description) || item.Name == item.Description) ? "" : "(" + item.Description + ")")
                            + "</option>" + Environment.NewLine;
                }
                else
                {
                    html += "<option value=\"" + item.Code + "\">" + item.Name +
                            ((string.IsNullOrEmpty(item.Description) || item.Name == item.Description) ? "" : "(" + item.Description + ")")
                            + "</option>" + Environment.NewLine;
                }
            }
            html += "</select>";
            return new MvcHtmlString(html);
        }

        /// <summary>
        /// 获得用于带有级别的多选列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FieldName"></param>
        /// <param name="MasterTableList"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMultiValueWithGradeUI<T>(string FieldName, List<T> MasterTableList) where T : MasterTable
        {
            return GetMultiValueWithGradeUI(FieldName, MasterTableList, new List<ItemWithGrade>());
        }

        /// <summary>
        ///     获得用于带有级别的多选列表
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="dic"></param>
        /// <param name="SelectItems"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMultiValueWithGradeUI<T>(string FieldName, List<T> MasterTableList, List<ItemWithGrade> SelectItems) where T : MasterTable
        {
            var html = string.Empty;
            var SelectDic = new Dictionary<string, CommonGrade>();
            foreach (var item in SelectItems)
            {
                SelectDic.Add(item.MasterCode, item.Grade);
            }
            foreach (var item in MasterTableList)
            {
                html += "<div class=\"input-group\">";
                html += "<span class=\"input-group-addon\" style=\"width:80px;\" >";

                if (SelectDic.ContainsKey(item.Code))
                {
                    html += GetCheckBox(item.Name + ((string.IsNullOrEmpty(item.Description) || item.Name == item.Description) ? "" : "(" + item.Description + ")"), FieldName + "." + item.Code, true, false);
                    html += "</span>";
                    html += GetCommonGrade(FieldName + "." + item.Code, SelectDic[item.Code]);
                }
                else
                {
                    html += GetCheckBox(item.Name + ((string.IsNullOrEmpty(item.Description) || item.Name == item.Description) ? "" : "(" + item.Description + ")"), FieldName + "." + item.Code, false, false);
                    html += "</span>";
                    html += GetCommonGrade(FieldName + "." + item.Code, CommonGrade.NotAvaliable);
                }
                html += "</div>";
            }


            return new MvcHtmlString(html);
        }

        private static MvcHtmlString GetCommonGrade(string FieldName, CommonGrade Grade)
        {
            var html = string.Empty;
            var enumType = typeof(CommonGrade);
            html = "<select class = \"form-control\" name= \"" + FieldName + ".Grade" + "\" id= \"" + FieldName + ".Grade" + "\" >" + Environment.NewLine;

            foreach (var value in Enum.GetValues(enumType))
            {
                var field = enumType.GetField(value.ToString());
                var display = field.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false).FirstOrDefault() as EnumDisplayNameAttribute;
                if (Grade.GetHashCode() == value.GetHashCode())
                {
                    html += "<option selected value=\"" + value.GetHashCode() + "\">" + display.DisplayName + "</option>" + Environment.NewLine;
                }
                else
                {
                    html += "<option  value=\"" + value.GetHashCode() + "\">" + display.DisplayName + "</option>" + Environment.NewLine;
                }

            }
            html += "</select>" + Environment.NewLine;
            return new MvcHtmlString(html);
        }

        /// <summary>
        ///     获得值列表
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<ItemWithGrade> GetMultiValueWithGradeFromUI(string FieldName, FormCollection collection)
        {
            var valueList = new List<ItemWithGrade>();
            foreach (var item in collection.AllKeys)
            {
                if (item.StartsWith(FieldName + "."))
                {
                    //LanguageList.00001.Grade NG
                    if (item.Split(".".ToCharArray()).Count() == 2)
                    {
                        //LanguageList.00001 OK
                        valueList.Add(new ItemWithGrade()
                        {
                            MasterCode = item.Substring(FieldName.Length + 1),
                            Grade = (CommonGrade)(int.Parse(collection.GetValue(item + ".Grade").AttemptedValue))
                        });
                    }
                }
            }
            return valueList;
        }
        /// <summary>
        ///     获得用于多选的列表UI（无选中内容）
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMultiValueUI<T>(string FieldName, List<T> list) where T : MasterTable
        {
            return GetMultiValueUI(FieldName, list, new List<string>());
        }

        /// <summary>
        ///     获得用于多选的列表UI
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="dic"></param>
        /// <param name="SelectKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMultiValueUI<T>(string FieldName, List<T> list, List<string> SelectKey)
            where T : MasterTable
        {
            var html = string.Empty;
            if (typeof(T) != typeof(M_Skill))
            {
                list.Sort((x, y) => { return x.Rank - y.Rank; });
            }
            foreach (var item in list)
            {
                if (SelectKey != null && SelectKey.Contains(item.Code))
                {
                    html += GetCheckBox(item.Name + ((string.IsNullOrEmpty(item.Description) || item.Name == item.Description) ? "" : "(" + item.Description + ")"), FieldName + "." + item.Code, true);
                }
                else
                {
                    html += GetCheckBox(item.Name + ((string.IsNullOrEmpty(item.Description) || item.Name == item.Description) ? "" : "(" + item.Description + ")"), FieldName + "." + item.Code, false);
                }
            }
            return new MvcHtmlString(html);
        }

        /// <summary>
        ///     获得值列表
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<string> GetMultiValueFromUI(string FieldName, FormCollection collection)
        {
            var valueList = new List<string>();
            foreach (var item in collection.AllKeys)
            {
                if (item.StartsWith(FieldName + "."))
                {
                    valueList.Add(item.Substring(FieldName.Length + 1));
                }
            }
            return valueList;
        }

        #endregion
    }
}