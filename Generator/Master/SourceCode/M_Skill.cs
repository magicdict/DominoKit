using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 技能项目
    /// </summary>
    public partial class M_Skill : MasterTable
    {
        #region "model"

            /// <summary>
            /// 工作年限
            /// </summary>
            [DisplayName("工作年限")]
            [Required]
            [Range(1 , 50 , ErrorMessage = "请输入1-50的数字")]
            public int ExperienceYears { get; set; }

            /// <summary>
            /// 分类
            /// </summary>
            [DisplayName("分类")]
            public string CatalogCode { get; set; }

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
