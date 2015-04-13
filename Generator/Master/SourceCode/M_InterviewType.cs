using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 面试种类
    /// </summary>
    public partial class M_InterviewType : MasterTable
    {
        #region "model"

            /// <summary>
            /// 面试官
            /// </summary>
            [DisplayName("面试官")]
            public string Interviewer { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "M_InterviewType";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "M_InterviewType";


            /// <summary>
            /// 数据主键前缀
            /// </summary>
            public override string GetPrefix()
            {
                return string.Empty;
            }

            /// <summary>
            /// 数据主键前缀静态字段
            /// </summary>
            public static string Prefix = string.Empty;

            /// <summary>
            /// Mvc画面的标题
            /// </summary>
            [BsonIgnore]
            public static string MvcTitle = "面试种类";

        #endregion
    }
}
