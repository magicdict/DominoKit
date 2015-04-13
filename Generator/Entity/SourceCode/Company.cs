using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 公司
    /// </summary>
    public partial class Company : EntityBase
    {
        #region "model"

            /// <summary>
            /// 公司名称
            /// </summary>
            [DisplayName("公司名称")]
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 公司缩写
            /// </summary>
            [DisplayName("公司缩写")]
            [Required]
            [StringLength(10 , MinimumLength= 2 , ErrorMessage = "请输入2-10个字符")]
            public string Code { get; set; }

            /// <summary>
            /// 公司简介
            /// </summary>
            [DisplayName("公司简介")]
            [Required]
            public string Description { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "Company";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "Company";


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
            public static string MvcTitle = "公司";

        #endregion
    }
}
