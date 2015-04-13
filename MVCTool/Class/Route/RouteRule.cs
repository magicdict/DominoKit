using System;
using System.Collections.Generic;
using System.Text;

namespace DevKit.MVCTool
{
    /// <summary>
    /// 路由段
    /// </summary>
    [Serializable]
    internal class RouteSegment
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// 是否为变量
        /// </summary>
        public bool IsVal = false;
        /// <summary>
        /// 是否为可选
        /// </summary>
        public bool IsOptional = false;
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue = string.Empty;
    }

    /// <summary>
    /// 路由规则
    /// </summary>
    [Serializable]
    internal class RouteRule
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// 自定义URL
        /// </summary>
        public string CustomUrl = string.Empty;
        /// <summary>
        /// 路由段
        /// </summary>
        public List<RouteSegment> segments = new List<RouteSegment>();
        /// <summary>
        /// 获得代码
        /// </summary>
        /// <returns></returns>
        public string GetCode()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("routes.MapRoute(");
            //路由名称
            code.AppendLine("name:\"" + Name + "\", ");
            //注意顺序
            //url "{controller}/{action}/{id}",
            string strUrl = string.Empty;

            if (string.IsNullOrEmpty(CustomUrl))
            {
                for (int i = 0; i < segments.Count; i++)
                {
                    strUrl += (segments[i].IsVal ? "{" : string.Empty) +
                               segments[i].Name + (segments[i].IsVal ? "}" : string.Empty) +
                              (i == segments.Count - 1 ? string.Empty : "/");
                }
            }
            else
            {
                strUrl = CustomUrl;
            }
            strUrl = "url:\"" + strUrl + "\",";
            //默认值
            //new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
            string strDefault = string.Empty;
            for (int i = 0; i < segments.Count; i++)
            {
                if (segments[i].IsOptional)
                {
                    strDefault += segments[i].Name + " = UrlParameter.Optional" +
                                  (i == segments.Count - 1 ? string.Empty : ",");
                }
                else
                {
                    strDefault += segments[i].Name + " = \"" + segments[i].DefaultValue + "\"" +
                                  (i == segments.Count - 1 ? string.Empty : ",");
                }
            }
            strDefault = "default: new { " + strDefault + " }";
            code.AppendLine(")");
            return string.Empty;
        }
    }
}
