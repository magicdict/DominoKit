using InfraStructure;
using InfraStructure.FilterSet;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 职位信息
    /// </summary>
    [DisplayName("职位信息")]
    public partial class Position : Organization
    {
        #region "model"

            /// <summary>
            /// 招聘部门
            /// </summary>
            [DisplayName("招聘部门")]
            [Required]
            [FilterItem(MetaType = typeof(M_EmployeeDepartment), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string DepartmentCode { get; set; }

            /// <summary>
            /// 招聘职位
            /// </summary>
            [DisplayName("招聘职位")]
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// 雇佣类型
            /// </summary>
            [DisplayName("雇佣类型")]
            [Required]
            [FilterItem(MetaType = typeof(M_EmploymentType), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string EmploymentType { get; set; }

            /// <summary>
            /// 招聘数量
            /// </summary>
            [DisplayName("招聘数量")]
            [Required]
            [Range(1 , 99 )]
            public int Target { get; set; }

            /// <summary>
            /// 工作地点
            /// </summary>
            [DisplayName("工作地点")]
            [Required]
            [FilterItem(MetaType = typeof(M_WorkSite), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string Location { get; set; }

            /// <summary>
            /// 职位描述及要求
            /// </summary>
            [DisplayName("职位描述及要求")]
            [Required]
            public string JodDetails { get; set; }

            /// <summary>
            /// 技术类别
            /// </summary>
            [DisplayName("技术类别")]
            [Required]
            [FilterItem(MetaType = typeof(M_SkillCatalog), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string SkillCatalogCode { get; set; }

            /// <summary>
            /// 行业类别
            /// </summary>
            [DisplayName("行业类别")]
            [Required]
            [FilterItem(MetaType = typeof(M_IndustryBackground), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string IndustryBackgroundCode { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            [DisplayName("开始时间")]
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime OpenDate { get; set; }

            /// <summary>
            /// 批准时间
            /// </summary>
            [DisplayName("批准时间")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime WWApprovedDate { get; set; }

            /// <summary>
            /// 员工等级
            /// </summary>
            [DisplayName("员工等级")]
            [FilterItem(MetaType = typeof(M_EmployeeLevel), MetaStructType = FilterItemAttribute.StructType.MultiMasterTable)]
            public List<string> EmployeeLevelList { get; set; }

            /// <summary>
            /// 面试种类
            /// </summary>
            [DisplayName("面试种类")]
            [FilterItem(MetaType = typeof(M_InterviewType), MetaStructType = FilterItemAttribute.StructType.MultiMasterTable)]
            public List<string> InterviewList { get; set; }

            /// <summary>
            /// 优先级
            /// </summary>
            [DisplayName("优先级")]
            public int Priority { get; set; }

            /// <summary>
            /// 当前状态
            /// </summary>
            [DisplayName("当前状态")]
            [FilterItem(MetaType = typeof(M_PositionStatus), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string FinalStatus { get; set; }

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
                return "Position";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "Position";


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
            public static string MvcTitle = "职位信息";

        #endregion
    }
}
