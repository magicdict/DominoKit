using InfraStructure;
using InfraStructure.FilterSet;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 区域
    /// </summary>
    [DisplayName("区域")]
    public partial class M_EmployeeArea : MasterTable
    {
        #region "model"

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "M_EmployeeArea";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "M_EmployeeArea";


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
            public static string MvcTitle = "区域";

        #endregion
    }
}
