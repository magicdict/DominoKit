using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;
using System.Web.Mvc;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 简历
    /// </summary>
    public partial class Resume : CompanyTable
    {
        #region "model"

            /// <summary>
            /// 人才编号
            /// </summary>
            [HiddenInput]
            [DisplayName("人才编号")]
            public string TalentCode { get; set; }

            /// <summary>
            /// 文件名
            /// </summary>
            [HiddenInput]
            [DisplayName("文件名")]
            public string FileName { get; set; }

            /// <summary>
            /// 数据库文件名
            /// </summary>
            [HiddenInput]
            [DisplayName("数据库文件名")]
            public string DBFileName { get; set; }

            /// <summary>
            /// 文件类型
            /// </summary>
            [HiddenInput]
            [DisplayName("文件类型")]
            public string ContentType { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            [DisplayName("备注")]
            public string Comment { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "Resume";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "Resume";


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
            public static string MvcTitle = "简历";

        #endregion
    }
}
