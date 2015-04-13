using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 人才储备
    /// </summary>
    public partial class TalentPool : CompanyTable
    {
        #region "model"

            /// <summary>
            /// 姓名
            /// </summary>
            [DisplayName("姓名")]
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 联系方式
            /// </summary>
            [DisplayName("联系方式")]
            [Required]
            public string Contact { get; set; }

            /// <summary>
            /// 大学
            /// </summary>
            [DisplayName("大学")]
            [Required]
            public string University { get; set; }

            /// <summary>
            /// 专业
            /// </summary>
            [DisplayName("专业")]
            [Required]
            public string Major { get; set; }

            /// <summary>
            /// 语言
            /// </summary>
            [DisplayName("语言")]
            public List<string> LanguageList { get; set; }

            /// <summary>
            /// 技能
            /// </summary>
            [DisplayName("技能")]
            public List<string> SkillList { get; set; }

            /// <summary>
            /// 市场背景
            /// </summary>
            [DisplayName("市场背景")]
            public bool MarketBG { get; set; }

            /// <summary>
            /// 技术背景
            /// </summary>
            [DisplayName("技术背景")]
            public bool techniqueBG { get; set; }

            /// <summary>
            /// 招聘渠道
            /// </summary>
            [DisplayName("招聘渠道")]
            public string Channel { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            [DisplayName("备注")]
            public string Comment { get; set; }

            /// <summary>
            /// 检索关键字
            /// </summary>
            [DisplayName("检索关键字")]
            public string SearchKey { get; set; }

            /// <summary>
            /// 访问权限
            /// </summary>
            [DisplayName("公开给好友")]
            public bool AccessRight { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "TalentPool";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "TalentPool";


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
            public static string MvcTitle = "人才储备";

        #endregion
    }
}
