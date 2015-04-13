using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public partial class FilterSetTalent : CompanyTable
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
            /// 过滤项目
            /// </summary>
            [DisplayName("过滤项目")]
            public List<FilterItemList> FilterList { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "FilterSetTalent";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "FilterSetTalent";


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
            public static string MvcTitle = "过滤器";

        #endregion
    }
}
