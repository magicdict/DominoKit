using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 招聘状态
    /// </summary>
    public partial class M_FinalStatus : MasterTable
    {
        #region "model"

            /// <summary>
            /// 表示顺序
            /// </summary>
            [DisplayName("表示顺序")]
            [Range(1 , 99 , ErrorMessage = "请输入1-99的数字")]
            public int SortRank { get; set; }

            /// <summary>
            /// 背景颜色
            /// </summary>
            [DisplayName("背景颜色")]
            public int BGColor { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "M_FinalStatus";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "M_FinalStatus";


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
            public static string MvcTitle = "招聘状态";

        #endregion
    }
}
