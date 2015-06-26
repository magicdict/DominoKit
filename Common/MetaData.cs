using System.Collections.Generic;
namespace DevKit.Common
{
    /// <summary>
    /// Dot Net
    /// </summary>
    public class CSharp
    {
        /// <summary>
        /// CSharp Keyword
        /// </summary>
        public const string strCSharp = "C#";
        /// <summary>
        /// C# MVC5.0
        /// </summary>
        public const string strCSharpMVC5 = "C# MVC5.0";
        /// <summary>
        /// 数据类型
        /// Key：中文数据类型说明
        /// Value：Net实际元数据类型
        /// </summary>
        public static Dictionary<string, string> MetaData = new Dictionary<string, string> { 
            {"整型","int"},
            {"字符串","string"},
            {"布尔值","bool"},
            {"日期","DateTime"}
        };
    }
    /// <summary>
    /// Java
    /// </summary>
    public class Java
    {
        /// <summary>
        /// CSharp Keyword
        /// </summary>
        public const string strJava = "Java";
        /// <summary>
        /// Java Spring MVC
        /// </summary>
        public const string strJavaSpring = "Java Spring";
        /// <summary>
        /// Java Struts2
        /// </summary>
        public const string strJavaStruts2 = "Java Struts2";
        /// <summary>
        /// 数据类型
        /// Key：中文数据类型说明
        /// Value：Java实际元数据类型
        /// </summary>
        public static Dictionary<string, string> MetaData = new Dictionary<string, string> { 
            {"整型","int"},
            {"字符串","String"},
            {"布尔值","bool"},
            {"日期","DateTime"}
        };
    }
}
