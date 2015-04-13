using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Web.Mvc;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 面试结果
    /// </summary>
    public partial class InterviewResult : CompanyTable
    {
        #region "model"

            /// <summary>
            /// 候选人编号
            /// </summary>
            [DisplayName("候选人编号")]
            [Required]
            public string TalentCode { get; set; }

            /// <summary>
            /// 职位编号
            /// </summary>
            [HiddenInput]
            [DisplayName("职位编号")]
            public string PositionCode { get; set; }

            /// <summary>
            /// 招聘编号
            /// </summary>
            [HiddenInput]
            [DisplayName("招聘编号")]
            public string HiringTrackCode { get; set; }

            /// <summary>
            /// 面试类型
            /// </summary>
            [DisplayName("面试类型")]
            [Required]
            public string InterviewType { get; set; }

            /// <summary>
            /// 面试进程
            /// </summary>
            [DisplayName("面试进程")]
            [UIHint("Enum")]
            [FilterItem(MetaType = typeof(InterviewProcessType), MetaStructType = FilterItemAttribute.StructType.SingleEnum)]
            public InterviewProcessType Process { get; set; }

            /// <summary>
            /// 面试官
            /// </summary>
            [DisplayName("面试官")]
            [Required]
            public string Interviewer { get; set; }

            /// <summary>
            /// 面试时间
            /// </summary>
            [DisplayName("面试时间")]
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime RunDate { get; set; }

            /// <summary>
            /// 面试结果
            /// </summary>
            [DisplayName("面试结果")]
            [Required]
            public string Result { get; set; }

            /// <summary>
            /// 面试评价
            /// </summary>
            [DisplayName("面试评价")]
            [Required]
            public string Comment { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "InterviewResult";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "InterviewResult";


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
            public static string MvcTitle = "面试结果";

        #endregion
    }
}
