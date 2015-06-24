using InfraStructure;
using InfraStructure.FilterSet;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 技能项目
    /// </summary>
    [DisplayName("技能项目")]
    public partial class M_Skill : MasterTable
    {
        #region "model"

            /// <summary>
            /// 工作年限
            /// </summary>
            [Range(50 , 0 )]
            public List<int> ExperienceYears { get; set; }

            /// <summary>
            /// 分类
            /// </summary>
            public List<string> CatalogCode { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "M_Skill";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "M_Skill";


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
            public static string MvcTitle = "技能项目";

        #endregion
    }
}
