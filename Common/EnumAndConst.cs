using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevKit.Common
{

    public static class EnumAndConst
    {
        /// <summary>
        /// 
        /// </summary>
        public const string MasterPrefix = "M_";

        /// <summary>
        /// 开发语言枚举
        /// </summary>
        public enum Language
        {
            CSharp,
            Java,
            PHP
        }
        /// <summary>
        /// 数据库枚举
        /// </summary>
        public enum DataBase
        {
            MySql,
            Oracle,
            MSSql,
            MongoDB
        }
    }
}
