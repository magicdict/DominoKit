using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 人才储备
    /// </summary>
    public partial class TalentInfo : CompanyTable
    {
        #region "model"

            /// <summary>
            /// ID
            /// </summary>
            [HiddenInput]
            [DisplayName("ID")]
            [Required]
            public string ID { get; set; }

            /// <summary>
            /// 生日
            /// </summary>
            [DisplayName("姓名")]
            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime BirthDay { get; set; }

            /// <summary>
            /// 手机
            /// </summary>
            [DisplayName("手机")]
            [Required]
            public string Mobile { get; set; }

            /// <summary>
            /// 电子邮件
            /// </summary>
            [DisplayName("电子邮件")]
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

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
            public List<辅助评价表> LanguageList { get; set; }

            /// <summary>
            /// 技能
            /// </summary>
            [DisplayName("技能")]
            public string SkillList { get; set; }

            /// <summary>
            /// 市场背景
            /// </summary>
            [DisplayName("市场背景")]
            [FilterItem(MetaType = typeof(M_MarketBG), MetaStructType = FilterItemAttribute.StructType.MultiMasterTable)]
            public M_MarketBG MarketBGList { get; set; }

            /// <summary>
            /// 技术背景
            /// </summary>
            [DisplayName("技术背景")]
            [FilterItem(MetaType = typeof(M_TechniqueBG), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public M_TechniqueBG TechniqueBG { get; set; }

            /// <summary>
            /// 招聘渠道
            /// </summary>
            [DisplayName("招聘渠道")]
            public string Channel { get; set; }

            /// <summary>
            /// 检索关键字
            /// </summary>
            [DisplayName("检索关键字")]
            public string SearchKey { get; set; }

            /// <summary>
            /// 访问权限
            /// </summary>
            [DisplayName("公开给好友")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool AccessRight { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "TalentInfo";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "TalentInfo";


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
