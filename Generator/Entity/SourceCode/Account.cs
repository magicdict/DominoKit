using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Account : CompanyTable
    {
        #region "model"

            /// <summary>
            /// 用户名
            /// </summary>
            [DisplayName("用户名")]
            [Required]
            public string User { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            [DisplayName("密码")]
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            /// 电子邮件
            /// </summary>
            [DisplayName("电子邮件")]
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            /// <summary>
            /// 公司编号
            /// </summary>
            [DisplayName("公司编号")]
            [Required]
            public string CompanyId { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "Account";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "Account";


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
            public static string MvcTitle = "";

        #endregion
    }
}
