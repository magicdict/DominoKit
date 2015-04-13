using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 渠道报表
    /// </summary>
    public partial class FilterSetReport : EntityBase
    {
        #region "model"

            /// <summary>
            /// 名称
            /// </summary>
            [DisplayName("名称")]
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            [DisplayName("描述")]
            public string Description { get; set; }

            /// <summary>
            /// 最终状态过滤
            /// </summary>
            [DisplayName("最终状态过滤")]
            public FilterItemList FinalStatusList { get; set; }

            /// <summary>
            /// OpenDate范围过滤
            /// </summary>
            [DisplayName("OpenDate范围过滤")]
            public FilterItemDate OpenDateDiff { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "FilterSetReport";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "FilterSetReport";


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
            public static string MvcTitle = "渠道报表";

        #endregion
    }
}
