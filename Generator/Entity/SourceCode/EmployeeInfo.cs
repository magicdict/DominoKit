using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public partial class EmployeeInfo : TalentInfo
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
            /// 生日
            /// </summary>
            [DisplayName("生日")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime BirthDay { get; set; }

            /// <summary>
            /// 员工号
            /// </summary>
            [DisplayName("员工号")]
            [Required]
            public string SerialNumber { get; set; }

            /// <summary>
            /// Notes ID
            /// </summary>
            [DisplayName("Notes ID")]
            [Required]
            public string NotesID { get; set; }

            /// <summary>
            /// ReportManager
            /// </summary>
            [DisplayName("ReportManager")]
            [Required]
            public string ReportManager { get; set; }

            /// <summary>
            /// 英语名
            /// </summary>
            [DisplayName("英语名")]
            public string EnglishName { get; set; }

            /// <summary>
            /// 出生地
            /// </summary>
            [DisplayName("出生地")]
            public string BornIn { get; set; }

            /// <summary>
            /// 上一家公司
            /// </summary>
            [DisplayName("上一家公司")]
            public string PreEmp { get; set; }

            /// <summary>
            /// 上一家公司行业
            /// </summary>
            [DisplayName("上一家公司行业")]
            public string PerInd { get; set; }

            /// <summary>
            /// 学位
            /// </summary>
            [DisplayName("学位")]
            [UIHint("Enum")]
            [FilterItem(MetaType = typeof(AcademicType), MetaStructType = FilterItemAttribute.StructType.SingleEnum)]
            public AcademicType Academic { get; set; }

            /// <summary>
            /// 员工类型
            /// </summary>
            [DisplayName("员工类型")]
            [UIHint("Enum")]
            [FilterItem(MetaType = typeof(EmpolyeeType), MetaStructType = FilterItemAttribute.StructType.SingleEnum)]
            public EmpolyeeType EmpolyeeType { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "EmployeeInfo";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static new string CollectionName = "EmployeeInfo";


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
            public static new string MvcTitle = "员工信息";

        #endregion
    }
}
