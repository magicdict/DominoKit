using InfraStructure;
using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using InfraStructure.FilterSet;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 人才储备
    /// </summary>
    [DisplayName("人才储备")]
    public partial class TalentInfo : Organization
    {
        #region "model"

            /// <summary>
            /// 姓名
            /// </summary>
            [DisplayName("姓名")]
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 英语名
            /// </summary>
            [DisplayName("英语名")]
            public string EnglishName { get; set; }

            /// <summary>
            /// 生日
            /// </summary>
            [DisplayName("生日")]
            [Required]
            [DataType(DataType.Date)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime BirthDay { get; set; }

            /// <summary>
            /// 出生地
            /// </summary>
            [DisplayName("出生地")]
            public string BornIn { get; set; }

            /// <summary>
            /// 常住地
            /// </summary>
            [DisplayName("常住地")]
            [Required]
            public string Location { get; set; }

            /// <summary>
            /// 手机
            /// </summary>
            [DisplayName("手机")]
            [Required]
            [RegularExpression(@"^1[3458][0-9]{9}$" , ErrorMessage = "手机号格式不正确")]
            [DataType(DataType.PhoneNumber)]
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
            /// 学位
            /// </summary>
            [DisplayName("学位")]
            [UIHint("Enum")]
            [FilterItem(MetaType = typeof(AcademicType), MetaStructType = FilterItemAttribute.StructType.SingleEnum)]
            public AcademicType Academic { get; set; }

            /// <summary>
            /// 海外工作背景
            /// </summary>
            [DisplayName("海外工作背景")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool OverseaWork { get; set; }

            /// <summary>
            /// 海外教育背景
            /// </summary>
            [DisplayName("海外教育背景")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool OverseaEdu { get; set; }

            /// <summary>
            /// 行业背景
            /// </summary>
            [DisplayName("行业背景")]
            [FilterItem(MetaType = typeof(M_IndustryBackground), MetaStructType = FilterItemAttribute.StructType.MultiMasterTable)]
            public List<string> IndustryBackgroundList { get; set; }

            /// <summary>
            /// 上一家公司
            /// </summary>
            [DisplayName("上一家公司")]
            public string PreEmp { get; set; }

            /// <summary>
            /// 上一家公司行业
            /// </summary>
            [DisplayName("上一家公司行业")]
            [FilterItem(MetaType = typeof(M_IndustryBackground), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string PerInd { get; set; }

            /// <summary>
            /// 招聘渠道
            /// </summary>
            [DisplayName("招聘渠道")]
            [FilterItem(MetaType = typeof(M_Channel), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string Channel { get; set; }

            /// <summary>
            /// 语言
            /// </summary>
            [DisplayName("语言")]
            [FilterItem(MetaType = typeof(M_Language), MetaStructType = FilterItemAttribute.StructType.MultiMasterTableWithGrade)]
            public List<ItemWithGrade> LanguageList { get; set; }

            /// <summary>
            /// 技能
            /// </summary>
            [DisplayName("技能")]
            [FilterItem(MetaType = typeof(M_Skill), MetaStructType = FilterItemAttribute.StructType.MultiCatalogMasterTable)]
            public List<string> SkillList { get; set; }

            /// <summary>
            /// 等级
            /// </summary>
            [DisplayName("等级")]
            [UIHint("Enum")]
            [FilterItem(MetaType = typeof(CommonGrade), MetaStructType = FilterItemAttribute.StructType.SingleEnum)]
            public CommonGrade TalentRank { get; set; }

            /// <summary>
            /// 评价
            /// </summary>
            [DisplayName("评价")]
            public string Evaluate { get; set; }

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
