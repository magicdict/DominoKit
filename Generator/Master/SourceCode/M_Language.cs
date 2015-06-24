using InfraStructure;
using InfraStructure.FilterSet;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 语言
    /// </summary>
    [DisplayName("语言")]
    public partial class M_Language : MasterTable
    {
        #region "model"

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "M_Language";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "M_Language";


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
            public static string MvcTitle = "语言";

        #endregion
    }
}
