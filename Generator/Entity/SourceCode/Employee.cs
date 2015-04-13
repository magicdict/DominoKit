using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 员工
    /// </summary>
    public partial class Employee : TalentPool
    {
        #region "model"

            /// <summary>
            /// 技术领域
            /// </summary>
            [DisplayName("技术领域")]
            public string SkillCode { get; set; }

            /// <summary>
            /// 工作地域
            /// </summary>
            [DisplayName("工作地域")]
            public string AreaCode { get; set; }

            /// <summary>
            /// 业务范围
            /// </summary>
            [DisplayName("业务范围")]
            public string BussinessCode { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "Employee";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static new string CollectionName = "Employee";


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
            public static new string Prefix = string.Empty;

            /// <summary>
            /// Mvc画面的标题
            /// </summary>
            [BsonIgnore]
            public static new string MvcTitle = "员工";

        #endregion
    }
}
